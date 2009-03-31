using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace LogicPuzzle.Components
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

        private class BulbControl : ComponentControl
        {
            public BulbControl(Bulb bulb)
                : base(bulb)
            {
                mBulb = bulb;
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                Graphics g = e.Graphics;

                Color c = mBulb.GetValue(0) ? Color.Red : Color.Black;
                int w = mBulb.Connections[0].Connections.Count > 0 ? 2 : 1;
                Pen pen = new Pen(c, w);

                g.DrawEllipse(pen, new Rectangle(Point.Subtract(mBulb.Connections[0].Location, new Size(2, 2)), new Size(4, 4)));
                g.DrawLine(pen, mBulb.Connections[0].Location, new Point(this.Width / 2, this.Height / 2));

                //g.DrawEllipse(pen, this.Width / 3, this.Height / 3, this.Width / 3, this.Height / 3);
                g.FillEllipse(mBulb.GetValue(0) ? Brushes.Red : Brushes.Black, this.Width / 3, this.Height / 3, this.Width / 3, this.Height / 3);
            }

            private Bulb mBulb;
        }
    }
}
