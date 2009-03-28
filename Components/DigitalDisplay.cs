using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace LogicPuzzle.Components
{
    class DigitalDisplay : Component
    {
        public DigitalDisplay()
            : base()
        {
            mNumberBase = 16;
        }

        public DigitalDisplay(int inputs)
            : this()
        {
            Initialize(inputs);
        }

        public void Initialize(int inputs)
        {
            Reinitalize(inputs, 1);

            mValue = 0;

            int inputCount = inputs;
            int inputOffset = 20;
            int inputLocation = 5;

            // Special case the case of 1 or two inputs
            if (inputs < 3)
            {
                inputOffset = 40;
            }

            int height = 10 + inputOffset * inputCount - 1;
            height = Math.Max(height, 50);
            Bounds = new Rectangle(0, 0, 55, height);

            for (int i = 0; i < inputs; ++i)
            {
                Connections[i].Location = new Point(5, inputLocation);
                inputLocation += inputOffset;
            }

            // Now add the latch input.
            Connections[Connections.Length-1].Location = new Point(Width - 5, 5);
        }

        public override void Execute()
        {
            // Only update the value if the latch input is true.
            if (GetValue(Connections.Length-1))
            {
                mValue = 0;
                // Calculate the value by shifting each of the input bits
                for (int i = Connections.Length - 2; i >= 0; --i)
                {
                    mValue = mValue << 1;
                    if (GetValue(i))
                    {
                        mValue += 1;
                    }
                }
            }

            base.Execute();
        }

        public override void DrawComponent(Graphics g)
        {
            Pen blackpen = new Pen(Color.Black, 1);

            Rectangle centerRect = new Rectangle(10, 5, Width - 20, Height - 10);

            for (int i = 0; i < mConnections.Length - 1; ++i)
            {
                Color c = GetValue(i) ? Color.Red : Color.Black;
                int w = mConnections[i].Connections.Count > 0 ? 2 : 1;
                Pen pen = new Pen(c, w);

                g.DrawEllipse(pen, new Rectangle(Point.Subtract(mConnections[i].Location, new Size(2, 2)), new Size(4, 4)));
                g.DrawLine(pen, mConnections[i].Location, new Point(centerRect.Left, mConnections[i].Location.Y));
            }

            // Draw the latch input differently
            {
                int latchInput = mConnections.Length - 1;
                Color c = GetValue(latchInput) ? Color.Red : Color.Black;
                int w = mConnections[latchInput].Connections.Count > 0 ? 2 : 1;
                Pen pen = new Pen(c, w);
                g.DrawEllipse(pen, new Rectangle(Point.Subtract(mConnections[latchInput].Location, new Size(2, 2)), new Size(4, 4)));
                g.DrawLine(pen, mConnections[latchInput].Location, new Point(centerRect.Right, mConnections[latchInput].Location.Y));
            }

            g.FillRectangle(Brushes.White, centerRect);
            g.DrawRectangle(blackpen, centerRect);

            centerRect.Inflate(-2, -2);
            g.DrawString(Convert.ToString(mValue, mNumberBase), new Font("Courier", 10), Brushes.Black, centerRect);
        }

        public override void Serialize(System.Xml.XmlWriter writer)
        {
            writer.WriteElementString("inputs", (mConnections.Length-1).ToString());
            writer.WriteElementString("base", (mNumberBase).ToString());
        }

        public override void Deserialize(System.Xml.XmlReader reader)
        {
            reader.ReadToDescendant("inputs");
            if (reader.IsStartElement("inputs"))
            {
                int inputs = reader.ReadElementContentAsInt();
                Initialize(inputs);
            }

            reader.ReadToFollowing("base");
            if (reader.IsStartElement("base"))
            {
                mNumberBase = reader.ReadElementContentAsInt();
            }
        }

        protected override ComponentControl CreateComponentControl()
        {
            return new DDComponentControl(this);
        }

        ///////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////
        public int NumberBase
        {
            get { return mNumberBase; }
            set { mNumberBase = value; }
        }

        ///////////////////////////////////////////////////////////////////////
        // Private
        ///////////////////////////////////////////////////////////////////////
        private int mValue;
        private int mNumberBase;


        ///////////////////////////////////////////////////////////////////////
        // DDComponentControl
        ///////////////////////////////////////////////////////////////////////
        class DDComponentControl : ComponentControl
        {
            public DDComponentControl(DigitalDisplay parent)
                : base(parent)
            {
                mParent = parent;
            }

            public override void ShowContextMenu(ContextMenuStrip menu, CancelEventArgs ce)
            {
                ToolStripItem hex = new ToolStripButton("Display Hexidecimal");
                hex.Click += new EventHandler(delegate(object sender, EventArgs e)
                {
                    mParent.NumberBase = 16;
                });
                menu.Items.Add(hex);

                ToolStripItem dec = new ToolStripButton("Display Decimal");
                dec.Click += new EventHandler(delegate(object sender, EventArgs e)
                {
                    mParent.NumberBase = 10;
                });
                menu.Items.Add(dec);
            }

            DigitalDisplay mParent;
        }
    }
}
