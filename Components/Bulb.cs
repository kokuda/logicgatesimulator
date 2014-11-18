using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace LogicSim.Components
{
    public class Bulb : Component
    {
        public Bulb()
            : base(1, 0)
        {
            Bounds = new Rectangle(0, 0, 100, 50);

            Connections[0].Location = new Point(5, this.Height / 2);
        }

        public override void Execute()
        {
            base.Execute();
        }

        protected override ComponentControl CreateComponentControl()
        {
            return new BulbControl(this);
        }

        private class BulbControl : BitmapComponentControl
        {
            public BulbControl(Bulb bulb)
                : base(bulb, "LogicSim.Resources.Bulb_0.png", "LogicSim.Resources.Bulb_1.png")
            {
                mBulb = bulb;
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                BitmapIndex = mBulb.GetValue(0) ? 1 : 0;
                base.OnPaint(e);
            }

            private Bulb mBulb;
        }
    }
}
