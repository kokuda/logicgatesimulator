using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace LogicSim
{
    // Contains a set of components that, together, can make a circuit
    public class Circuit
    {
        public Circuit()
        {
            mComponentList = new List<Components.Component>();
        }

        public void Clear()
        {
            // Delete the current components.
            foreach (Components.Component c in mComponentList)
            {
                c.Dispose();
            }
            mComponentList.Clear();
        }

        public void Add(Components.Component c)
        {
            c.Circuit = this;
            mComponentList.Add(c);
        }

        public bool Remove(Components.Component c)
        {
            c.Disconnect();
            return mComponentList.Remove(c);
        }

        public void ConnectComponent(Components.Component component)
        {
            // Disconnect the component first
            component.Disconnect();

            foreach (Components.Component c in mComponentList)
            {
                if (c != component)
                {
                    for (int i = 0; i < c.Connections.Length; ++i)
                    {
                        Point p1 = c.Location;
                        p1.Offset(c.Connections[i].Location);
                        for (int j = 0; j < component.Connections.Length; ++j)
                        {
                            Point p2 = component.Location;
                            p2.Offset(component.Connections[j].Location);

                            Point diff = Point.Subtract(p1, new Size(p2));
                            if ((Math.Abs(diff.X) < 5) && (Math.Abs(diff.Y) < 5))
                            {
                                c.ConnectOutput(i, component.Connections[j]);
                                component.ConnectInput(j, c.Connections[i]);
                            }
                        }
                    }
                }
            }
        }

        public void Run()
        {
            foreach (Components.Component c in mComponentList)
            {
                c.Setup();
            }

            foreach (Components.Component c in mComponentList)
            {
                c.Execute();
            }
        }
            
        // Write the layout info to the stream

        public void Serialize(System.Xml.XmlWriter writer)
        {
            writer.WriteStartElement("circuit");
            foreach (Components.Component c in mComponentList)
            {
                writer.WriteStartElement("component");
                writer.WriteAttributeString("type", c.GetType().ToString());
                writer.WriteAttributeString("x", c.Location.X.ToString());
                writer.WriteAttributeString("y", c.Location.Y.ToString());
                c.Serialize(writer);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        public void Serialize(System.IO.Stream stream)
        {
            System.Xml.XmlWriterSettings settings = new System.Xml.XmlWriterSettings() { Indent = true };
            System.Xml.XmlWriter writer = System.Xml.XmlWriter.Create(stream, settings);

            writer.WriteStartDocument();
            Serialize(writer);
            writer.Close();
        }

        public void Deserialize(System.Xml.XmlReader reader)
        {
            //reader.ReadStartElement("circuit");

            // Delete the current components.
            Clear();

            while (reader.Read())
            {
                if (reader.IsStartElement("component"))
                {
                    string type = reader.GetAttribute("type");
                    int x = int.Parse(reader.GetAttribute("x"));
                    int y = int.Parse(reader.GetAttribute("y"));
                    Object[] param = new Object[0];
                    Type[] types = new Type[0];
                    System.Reflection.ConstructorInfo info = System.Reflection.Emit.TypeBuilder.GetType(type).GetConstructor(types);
                    Components.Component c = (Components.Component)info.Invoke(param);
                    c.Deserialize(reader.ReadSubtree());
                    c.Location = new Point(x, y);
                    Add(c);
                    ConnectComponent(c);
                }
            }
        }

        // Read in a layout from the stream
        public void Deserialize(System.IO.Stream stream)
        {
            System.Xml.XmlReader reader = System.Xml.XmlReader.Create(stream);
            Deserialize(reader);
        }

        public List<Components.Component> Components
        {
            get { return mComponentList; }
        }

        private List<Components.Component> mComponentList;
        //private Control mParent;
    }
}
