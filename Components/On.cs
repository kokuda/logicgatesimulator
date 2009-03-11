using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace LogicPuzzle.Components
{
    public class On : Component
    {
        public On(Control parent)
            : this(parent, 0)
        {
        }

        public On(Control parent, double interval)
            : base(0, 1)
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            this.Parent = parent;
            this.Bounds = new Rectangle(0, 0, 100, 50);

            Connections[0].Location = new Point(this.Width - 5, this.Height / 2);

            // Initialize the interval
            Interval = interval;
        }

        public override void Dispose()
        {
            base.Dispose();
            if (mTimer != null)
            {
                mTimer.Stop();
                mTimer.Dispose();
                mTimer = null;
            }
        }

        public override void Execute()
        {
            base.Execute();
        }

        public override void Serialize(System.Xml.XmlWriter writer)
        {
            writer.WriteElementString("interval", Interval.ToString());
        }

        public override void Deserialize(System.Xml.XmlReader reader)
        {
            reader.ReadToDescendant("interval");
            if (reader.IsStartElement("interval"))
            {
                Interval = reader.ReadElementContentAsDouble();
            }
        }

        public double Interval
        {
            get
            {
                return mInterval;
            }
            set
            {
                mInterval = value;
                if (mInterval > 0)
                {
                    if (mTimer == null)
                    {
                        mTimer = new System.Timers.Timer(mInterval);
                    }
                    mTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimerElapsed);
                    mTimer.Enabled = true;
                    mTimer.Start();
                }
                else
                {
                    mTimer = null;

                    // An interval of 0 means stay on
                    Connections[0].Value = true;
                }
            }
        }

        void OnTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            // Toggle the value
            Connections[0].Value = !Connections[0].Value;
        }

        System.Timers.Timer mTimer;
        double mInterval;
    }
}
