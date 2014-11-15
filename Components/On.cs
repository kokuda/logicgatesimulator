using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace LogicSim.Components
{
    public class On : Component
    {
        public On()
            : this(0)
        {
        }

        public On(double interval)
            : base(0, 1)
        {
            Bounds = new Rectangle(0, 0, 100, 50);

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

        protected override ComponentControl CreateComponentControl()
        {
            var control = new BitmapComponentControl(this, "LogicSim.Resources.On_0.png", "LogicSim.Resources.On_1.png");
            control.BitmapIndex = GetBitmapIndex();
            return control;
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
                    SetState(true);
                }
            }
        }

        void OnTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            // Toggle the value
            SetState(!GetState());
        }

        private int GetBitmapIndex()
        {
            return GetState() ? 1 : 0;
        }

        private void SetState(bool state)
        {
            Connections[0].Value = state;
            if (Control != null)
            {
                var control = (BitmapComponentControl)Control;
                control.BitmapIndex = GetBitmapIndex();
            }
        }

        private bool GetState()
        {
            return Connections[0].Value;
        }

        System.Timers.Timer mTimer;
        double mInterval;
    }
}
