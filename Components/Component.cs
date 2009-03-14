using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace LogicPuzzle.Components
{
    // Handle generic logic component behaviours, such as drag and drop.
    public class Component : Control
    {
        // Default constructor needed so that Visual Studio doesn't fail
        // when attempting to open the components in design mode.
        public Component()
        {
            mMouseDown = false;
            mConnections = new Connection[0];
            mPreviousValues = new bool[0];
        }

        public Component(int inputs, int outputs)
        {
            mMouseDown = false;

            mConnections = new Connection[inputs + outputs];
            mPreviousValues = new bool[inputs + outputs];
            for (int i = 0; i < mConnections.Length; ++i)
            {
                mConnections[i] = new Connection(this);
                mPreviousValues[i] = false;
            }
        }

        public virtual void Dispose()
        {
            base.Dispose();

            for (int i = 0; i < mConnections.Length; ++i)
            {
                mConnections[i] = null;
            }

            mConnections = null;
        }

        ~Component()
        {
            Disconnect();
        }

        public virtual void Setup()
        {
        }

        // Calculate the outputs from the inputs.
        public virtual void Execute()
        {
            if (ValuesDiffer())
            {
                InvalidateEx();
            }
        }

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
        
        public virtual void ShowContextMenu(ContextMenuStrip menu, CancelEventArgs e)
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
            InvalidateEx();
        }

        protected virtual void OnConnect()
        {
            InvalidateEx();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //e.Graphics.SetClip(Parent.DisplayRectangle);
            base.OnPaint(e);
            DrawComponent(e.Graphics);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Start a drag
                mMouseDown = true;
                mMouseX = e.X;
                mMouseY = e.Y;
                this.BringToFront();
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mMouseDown = false;
                mCircuit.ConnectComponent(this);
            }
            base.OnMouseUp(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (mMouseDown)
            {
                this.SetBounds(Location.X + e.X - mMouseX, Location.Y + e.Y - mMouseY, Bounds.Width, Bounds.Height);
                base.OnMouseMove(e);
                InvalidateEx();
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020; //WS_EX_TRANSPARENT
                return cp;
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            //do not allow the background to be painted 
        }

        protected void InvalidateEx()
        {
            if (Parent == null)
                return;

            Rectangle rc = new Rectangle(this.Location, this.Size);
            Parent.Invalidate(rc, true);
        }

        private bool ValuesDiffer()
        {
            bool dirty = false;

            // Compare the current value of each connection with
            // the previously stored values.
            for (int i = 0; i < Connections.Length; ++i )
            {
                bool value = GetValue(i);
                if (mPreviousValues[i] != value)
                {
                    dirty = true;
                    mPreviousValues[i] = value;
                }
            }

            return dirty;
        }

        private bool mMouseDown;
        private int mMouseX;
        private int mMouseY;
        private Circuit mCircuit;
        private Connection[] mConnections;
        private bool[] mPreviousValues;
    }
}
