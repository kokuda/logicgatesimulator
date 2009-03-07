using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace LogicPuzzle.Components
{
    public class Strobe : Component
    {
        public Strobe(Control parent)
            : this(parent, 1000)
        {
        }

        public Strobe(Control parent, double interval)
            : base(0, 1)
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            this.Parent = parent;
            this.Bounds = new Rectangle(0, 0, 100, 50);

            Connections[0].Location = new Point(this.Width - 5, this.Height / 2);

            mTimer = new System.Timers.Timer(interval);
            mTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimerElapsed);
            mTimer.Enabled = true;
            mTimer.Start();
        }

        public override void Execute()
        {
            Invalidate();
        }

        public override void Serialize(System.Xml.XmlWriter writer)
        {
            writer.WriteElementString("interval", mTimer.Interval.ToString());
        }

        public override void Deserialize(System.Xml.XmlReader reader)
        {
            reader.ReadToDescendant("interval");
            if (reader.IsStartElement("interval"))
            {
                mTimer.Interval = reader.ReadElementContentAsDouble();
            }
        }

        void OnTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            // Toggle the value
            Connections[0].Value = !Connections[0].Value;
        }

        System.Timers.Timer mTimer;
    }
}
