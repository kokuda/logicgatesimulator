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
        public IC(Control parent, string name)
        {
            Bounds = new Rectangle(0, 0, 100, 50);
            mCircuit = new Circuit(parent);
            mName = name;
        }

        public void Deserialize(System.IO.Stream stream)
        {
            mCircuit.Deserialize(stream);
            List<Component> componentList = new List<Component>();

            // Find the inputs and outputs of the circuit.
            int inputCount = 0;
            int outputCount = 0;
            foreach (Component c in mCircuit.Components)
            {
                // Using On objects as input
                if (c.GetType() == typeof(On))
                {
                    inputCount++;
                    componentList.Add(c);
                }
                if (c.GetType() == typeof(Bulb))
                {
                    outputCount++;
                    componentList.Add(c);
                }
            }

            int inputOffset = Height / inputCount;
            int inputIndex = 0;
            int outputOffset = Height / outputCount;
            int outputIndex = 0;

            Reinitalize(inputCount, outputCount);

            for (int i = 0; i < componentList.Count; ++i)
            {
                // If it is an input point then add it to the left side.
                if (componentList[i].GetType() == typeof(On))
                {
                    // Replace the "On" component with an "Input" component.
                    Input input = new Input(componentList[i] as On, mConnections[i]);
                    mCircuit.Remove(componentList[i]);
                    mCircuit.Add(input);
                    mCircuit.ConnectComponent(input);

                    mConnections[i].Location = new Point(5, 5 + inputIndex * inputOffset);
                    ++inputIndex;
                }

                // If it is an output point then add it to the right side.
                if (componentList[i].GetType() == typeof(Bulb))
                {
                    // Replace the "Bulb" component with an "Output" component.
                    Output output = new Output(componentList[i] as Bulb, mConnections[i]);
                    mCircuit.Remove(componentList[i]);
                    mCircuit.Add(output);
                    mCircuit.ConnectComponent(output);

                    mConnections[i].Location = new Point(Width - 5, 5 + outputIndex * outputOffset);
                    ++outputIndex;
                }
            }
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
            public IOComponent(Component copy, Connection conn)
                : base(copy.Connections.Length,0)
            {
                mIOConnection = conn;
                Bounds = copy.Bounds;
                Connections[0].Location = copy.Connections[0].Location;
                Location = copy.Location;
            }

            protected Connection mIOConnection;
        }

        private class Input : IOComponent
        {
            public Input(On copy, Connection conn)
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
                bool result = false;
                foreach (Connection c in mIOConnection.Connections)
                {
                    result |= c.Value;
                }

                Connections[0].Value = result;
                base.Execute();
            }
        }

        private class Output : IOComponent
        {
            public Output(Bulb copy, Connection conn)
                : base(copy, conn)
            {
            }

            public override bool GetValue(int index)
            {
                bool result = false;
                foreach (Connection c in Connections[0].Connections)
                {
                    result |= c.Value;
                }

                return result;
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
