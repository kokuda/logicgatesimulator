using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace LogicPuzzle.Components
{
    // Dynamic component built from a circuit of multiple user defined components.
    class IC : Component
    {
        ///////////////////////////////////////////////////////////////////////
        // Public methods
        ///////////////////////////////////////////////////////////////////////
        public IC()
        {
            Bounds = new Rectangle(0, 0, 100, 50);
            mCircuit = new Circuit();
            mName = "unknown";
        }

        public IC(string name)
            : this()
        {
            mName = name;
        }

        public void LoadCircuit(System.Xml.XmlReader reader)
        {
            mCircuit.Deserialize(reader);
            InitializeFromCircuit();
        }

        public void LoadCircuit(System.IO.Stream stream)
        {
            System.Xml.XmlReader reader = System.Xml.XmlReader.Create(stream);
            LoadCircuit(reader);
        }

        ///////////////////////////////////////////////////////////////////////
        // Component implementation
        ///////////////////////////////////////////////////////////////////////
        public override void Execute()
        {
            mCircuit.Run();
            base.Execute();
        }

        public override void DrawComponent(Graphics g)
        {
            base.DrawComponent(g);
            g.DrawString(mName, new Font("Courier", 10), Brushes.Black, this.Width / 2, this.Height / 2);
        }

        protected override ComponentControl CreateComponentControl()
        {
            return new ICComponentControl(this);
        }

        public override void Serialize(System.Xml.XmlWriter writer)
        {
            writer.WriteElementString("name", mName);
            writer.WriteStartElement("subcircuit");
            mCircuit.Serialize(writer);
            writer.WriteEndElement();
        }

        public override void Deserialize(System.Xml.XmlReader reader)
        {
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case System.Xml.XmlNodeType.Element:
                        if (reader.Name == "name")
                        {
                            mName = reader.ReadElementContentAsString();
                        }
                        else if (reader.Name == "subcircuit")
                        {
                            System.Xml.XmlReader subreader = reader.ReadSubtree();
                            LoadCircuit(subreader);
                        }
                        break;
                }
            }

            //string content = reader.ReadElementContentAsString();
            //byte[] bytes = System.Text.ASCIIEncoding.ASCII.GetBytes(content);
            //System.IO.Stream s = new System.IO.MemoryStream(bytes);
            //LoadCircuit(s);
        }

        ///////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////

        public Circuit InternalCircuit
        {
            get { return mCircuit; }
        }

        public string Name
        {
            get { return mName; }
        }

        ///////////////////////////////////////////////////////////////////////
        // Private
        ///////////////////////////////////////////////////////////////////////

        private Circuit mCircuit;
        private string mName;

        private bool IsInput(Component c)
        {
            return (c.GetType() == typeof(On)) || (c.GetType() == typeof(Input));
        }

        private bool IsOutput(Component c)
        {
            return (c.GetType() == typeof(Bulb)) || (c.GetType() == typeof(Output));
        }

        private void InitializeFromCircuit()
        {
            List<Component> componentList = new List<Component>();

            // Find the inputs and outputs of the circuit.
            int inputCount = 0;
            int outputCount = 0;
            foreach (Component c in mCircuit.Components)
            {
                // Using On objects as input
                if (IsInput(c))
                {
                    inputCount++;
                    componentList.Add(c);
                }
                if (IsOutput(c))
                {
                    outputCount++;
                    componentList.Add(c);
                }
            }

            int inputOffset = inputCount > 1 ? (Height - 10) / (inputCount - 1) : Height - 5;
            int inputLocation = 5;
            int outputOffset = outputCount > 1 ? (Height - 10) / (outputCount - 1) : Height - 5;
            int outputLocation = 5;

            Reinitalize(inputCount, outputCount);

            for (int i = 0; i < componentList.Count; ++i)
            {
                // If it is an input point then add it to the left side.
                if (IsInput(componentList[i]))
                {
                    // Replace the "On" component with an "Input" component.
                    Input input = new Input(componentList[i], mConnections[i]);
                    mCircuit.Remove(componentList[i]);
                    mCircuit.Add(input);
                    mCircuit.ConnectComponent(input);

                    mConnections[i].Location = new Point(5, inputLocation);
                    inputLocation += inputOffset;
                }

                // If it is an output point then add it to the right side.
                if (IsOutput(componentList[i]))
                {
                    // Replace the "Bulb" component with an "Output" component.
                    Output output = new Output(componentList[i], mConnections[i]);
                    mCircuit.Remove(componentList[i]);
                    mCircuit.Add(output);
                    mCircuit.ConnectComponent(output);

                    mConnections[i].Location = new Point(Width - 5, outputLocation);
                    outputLocation += outputOffset;
                }
            }
        }

        private class ICComponentControl : ComponentControl
        {
            public ICComponentControl(IC component)
                : base(component)
            {
                mComponent = component;
            }

            // Open a modal window containing the contents of the internal
            // circuit.
            protected override void OnMouseDoubleClick(MouseEventArgs e)
            {
                base.OnMouseDoubleClick(e);

                Form f = new Form();

                // Show each Component on the new form.
                Rectangle boundingBox = new Rectangle();
                foreach (Component c in mComponent.InternalCircuit.Components)
                {
                    c.Show(f, null);

                    // Calculate the bounding box of all the components
                    // and resize the form to fit.
                    Rectangle controlBounds = c.Bounds;
                    controlBounds.Offset(c.Location);
                    if (boundingBox.IsEmpty)
                    {
                        boundingBox = controlBounds;
                    }
                    else
                    {
                        boundingBox = Rectangle.Union(boundingBox, controlBounds);
                    }
                }
                f.Width = boundingBox.Right + 50;
                f.Height = boundingBox.Bottom + 50;
                f.Text = mComponent.Name;
                f.ShowDialog();
                f.Dispose();
            }

            private IC mComponent;
        }

        private class IOComponent : Component
        {
            // Used by the deserializer
            public IOComponent()
                : base(1,0)
            {
                Connections[0] = new WireConnection(this);
            }

            public IOComponent(Component copy, Connection conn)
                : base(copy.Connections.Length,0)
            {
                mIOConnection = conn;
                Bounds = copy.Bounds;
                Connections[0] = new WireConnection(this);
                Connections[0].Location = copy.Connections[0].Location;
                Location = copy.Location;
            }

            protected Connection mIOConnection;
        }

        // Special IO components to interface between the internal
        // and external circuits.
        // We could make these more like wires, and make the values
        // dynamic.  That would propagate the values faster and avoid
        // possible loop conditions.
        private class Input : IOComponent
        {
            // Used by the deserializer
            public Input()
                : base()
            {
                // Since the serializer doesn't save the location of the connections
                // we have to initialize them to the default "input/on" locations.
                // In theory we should serialize all of this.
                Bounds = new Rectangle(0, 0, 100, 50);
                Connections[0].Location = new Point(this.Width - 5, this.Height / 2);
            }

            public Input(Component copy, Connection conn)
                : base(copy, conn)
            {
            }

            public override bool GetValue(int index)
            {
                bool result = false;
                foreach (Connection c in mIOConnection.Connections)
                {
                    result |= c.Value;
                }

                return result;
            }

            public override void Execute()
            {
                //bool result = false;
                //foreach (Connection c in mIOConnection.Connections)
                //{
                //    result |= c.Value;
                //}

                //SetValue(0, result);
                base.Execute();
            }
        }

        private class Output : IOComponent
        {
            // Used by the deserializer
            public Output()
                : base()
            {
                // Since the serializer doesn't save the location of the connections
                // we have to initialize them to the default "output/bulb" locations.
                // In theory we should serialize all of this.
                Bounds = new Rectangle(0, 0, 100, 50);
                Connections[0].Location = new Point(5, this.Height / 2);
            }

            public Output(Component copy, Connection conn)
                : base(copy, conn)
            {
            }

            public override void Execute()
            {
                bool result = false;
                foreach (Connection c in Connections[0].Connections)
                {
                    result |= c.Value;
                }

                mIOConnection.Value = result;
                base.Execute();
            }
        }
    }
}
