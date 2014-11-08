using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace LogicSim.Components
{
    public class Switch : Component
    {
        private bool mSwitchState = false;

        public Switch() : base(1,1)
        {
            Bounds = new Rectangle(0, 0, 100, 50);
            Connections[0] = new SwitchConnection(this, 0);
            Connections[1] = new SwitchConnection(this, 1);
            Connections[0].Location = new Point(5, this.Height / 2);
            Connections[1].Location = new Point(this.Width - 5, this.Height / 2);
        }
        
        public bool SwitchState
        {
            get { return mSwitchState; }
            set { mSwitchState = value; }
        }

        protected override ComponentControl CreateComponentControl()
        {
            return new SwitchControl(this);
        }

        public override void OnMouseClick(MouseEventArgs e)
        {
            // Toggle the switch state
            SwitchState = !SwitchState;

            if (SwitchState)
            {
                var value0 = GetValue(0);
                var value1 = GetValue(1);
                SetValue(0, value0);
                SetValue(1, value1);
            }
            else
            {
                SetValue(0, false);
                SetValue(1, false);
            }
        }

        public override bool GetValue(int index)
        {
            // The value of at either end of the switch is the logical or of each of the inputs at that end
            // and the inputs at the other end if the switch is closed.
            // When closed, the switch should act like a wire.

            bool result = false;
            foreach (Connection c in Connections[index].Connections)
            {
                result |= c.Value;
            }

            // The power from the opposite connection only counts if the switch is closed.
            if (mSwitchState)
            {
                foreach (Connection c in Connections[1 - index].Connections)
                {
                    result |= c.Value;
                }
            }

            return result;
        }

        public override void Serialize(System.Xml.XmlWriter writer)
        {
            //writer.WriteElementString("switchstate", mSwitchState.ToString());
            writer.WriteStartElement("switchstate");
            writer.WriteValue(SwitchState);
            writer.WriteEndElement();
        }

        public override void Deserialize(System.Xml.XmlReader reader)
        {
            reader.ReadToFollowing("switchstate");
            if (reader.IsStartElement("switchstate"))
            {
                mSwitchState = reader.ReadElementContentAsBoolean();
            }
        }

        private class SwitchControl : ComponentControl
        {
            public SwitchControl(Switch s)
                : base(s)
            {
                mSwitch = s;
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                Graphics g = e.Graphics;

                Color c = mSwitch.GetValue(0) && mSwitch.SwitchState ? Color.Red : Color.Black;
                int w = mSwitch.Connections[0].Connections.Count > 0 ? 2 : 1;
                Pen pen = new Pen(c, w);

                // Draw input line
                g.DrawEllipse(pen, new Rectangle(Point.Subtract(mSwitch.Connections[0].Location, new Size(2, 2)), new Size(4, 4)));
                g.DrawLine(pen, mSwitch.Connections[0].Location, new Point(this.Width / 3, this.Height / 2));

                // Draw switch
                if (mSwitch.SwitchState)
                {
                    g.DrawLine(pen, new Point(this.Width / 3, this.Height / 2), new Point(this.Width / 3 * 2, this.Height / 2));
                }
                else
                {
                    g.DrawLine(pen, new Point(this.Width / 3, this.Height / 2), new Point(this.Width / 3 * 2, this.Height / 2 - 20));
                }

                // Draw output line
                g.DrawEllipse(pen, new Rectangle(Point.Subtract(mSwitch.Connections[1].Location, new Size(2, 2)), new Size(4, 4)));
                g.DrawLine(pen, mSwitch.Connections[1].Location, new Point(this.Width / 3 * 2, this.Height / 2));
            }

            private Switch mSwitch;
        }

        /// <summary>
        /// A connection that doesn't store its value, but rather calculates it as
        /// the sum of all the inputs.
        /// </summary>
        private class SwitchConnection : Connection
        {
            public SwitchConnection(Component parent, int index)
                : base(parent)
            {
                mProcessing = false;
                mIndex = index;
            }

            // The value of a wire is just the sum of all inputs.
            // Rather than calculate and store the value, we calculate the value
            // dynamically.
            public override bool Value
            {
                get
                {
                    // Avoid infinite recursion if the wire is attached to other wires.
                    if (!mProcessing)
                    {
                        // Instead of returning the value, we return the value of
                        // the parent at this index.
                        mProcessing = true;
                        bool value = Parent.GetValue(mIndex);
                        mProcessing = false;
                        return value;
                    }
                    else
                    {
                        // If we have already passed this node then do not contribute
                        // anything more.
                        return false;
                    }
                }
            }

            bool mProcessing;
            private int mIndex;
        }
    }
}
