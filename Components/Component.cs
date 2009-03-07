using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace LogicPuzzle.Components
{
    // Handle generic logic component behaviours, such as drag and drop.
    [System.Xml.Serialization.XmlType("LogicPuzzle_Component")]
    [System.Xml.Serialization.XmlRoot(ElementName="LogicPuzzle_Component")]
    public class Component : Control
    {
        // Default constructor needed so that Visual Studio doesn't fail
        // when attempting to open the components in design mode.
        public Component()
        {
            mMouseDown = false;
            mConnections = new Connection[0];
        }

        public Component(int inputs, int outputs)
        {
            mMouseDown = false;

            mConnections = new Connection[inputs + outputs];
            for (int i = 0; i < mConnections.Length; ++i)
            {
                mConnections[i] = new Connection(this);
            }
        }

        // Calculate the outputs from the inputs.
        public virtual void Execute() { }

        public virtual Connection[] Connections { get { return mConnections; } }

        public virtual void ConnectInput(int index, Connection c)
        {
            mConnections[index].Connections.Add(c);
            OnConnect();
        }

        public virtual void ConnectOutput(int index, Connection c)
        {
            mConnections[index].Connections.Add(c);
            OnConnect();
        }

        public virtual void Disconnect()
        {
            for (int c = 0; c < mConnections.Length; ++c )
            {
                foreach (Connection comp in mConnections[c].Connections)
                {
                    if (comp.Connections.Remove(mConnections[c]))
                    {
                        // Notify the component that it has had a connection removed.
                        comp.Parent.OnDisconnect();
                    }
                }
                mConnections[c].Connections.Clear();
            }

            OnDisconnect();
        }

        public virtual Circuit Circuit
        {
            set { mCircuit = value; }
            get { return mCircuit; }
        }

        public virtual bool GetValue(int index)
        {
            bool result = mConnections[index].Value;
            foreach (Connection c in mConnections[index].Connections)
            {
                result |= c.Value;
            }
            return result;
        }

        public virtual void SetValue(int index, bool value)
        {
            // Set the output value, for polling.
            mConnections[index].Value = value;
        }


        public virtual void Serialize(System.Xml.XmlWriter writer)
        {
        }

        public virtual void Deserialize(System.Xml.XmlReader reader)
        {
        }

        protected virtual void DrawComponent(Graphics g)
        {
            Pen blackpen = new Pen(Color.Black, 1);

            for (int i = 0; i < mConnections.Length; ++i)
            {
                Color c = GetValue(i) ? Color.Red : Color.Black;
                int w = mConnections[i].Connections.Count > 0 ? 2 : 1;
                Pen pen = new Pen(c, w);

                g.DrawEllipse(pen, new Rectangle(Point.Subtract(mConnections[i].Location, new Size(2, 2)), new Size(4, 4)));
                g.DrawLine(pen, mConnections[i].Location, new Point(this.Width / 2, this.Height / 2));
            }
            g.DrawEllipse(blackpen, this.Width / 3, this.Height / 3, this.Width / 3, this.Height / 3);
        }

        protected virtual void OnDisconnect()
        {
        }

        protected virtual void OnConnect()
        {
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //e.Graphics.SetClip(Parent.DisplayRectangle);
            base.OnPaint(e);
            DrawComponent(e.Graphics);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            // Start a drag
            mMouseDown = true;
            mMouseX = e.X;
            mMouseY = e.Y;
            this.BringToFront();

            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            mMouseDown = false;
            mCircuit.ConnectComponent(this);
            base.OnMouseUp(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (mMouseDown)
            {
                this.SetBounds(Location.X + e.X - mMouseX, Location.Y + e.Y - mMouseY, Bounds.Width, Bounds.Height);
                base.OnMouseMove(e);
            }
        }

        private bool mMouseDown;
        private int mMouseX;
        private int mMouseY;
        private Circuit mCircuit;
        private Connection[] mConnections;
    }
}
