using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace LogicPuzzle.Components
{
    ///////////////////////////////////////////////////////////////////////
    // And : Component
    ///////////////////////////////////////////////////////////////////////
    class And : Component
    {
        public And()
            : base(2, 1)
        {
            Bounds = new Rectangle(0, 0, 100, 50);

            Connections[0].Location = new Point(5, 5);
            Connections[1].Location = new Point (5, this.Height - 5);
            Connections[2].Location = new Point(this.Width - 5, this.Height / 2);
        }

        public override void Execute()
        {
            SetValue(2, GetValue(0) && GetValue(1));
            base.Execute();
        }

        protected override ComponentControl CreateComponentControl()
        {
            return new BitmapControl(this, "LogicPuzzle.Resources.And.png");
        }
    }

    ///////////////////////////////////////////////////////////////////////
    // BitmapControl : ComponentControl
    ///////////////////////////////////////////////////////////////////////
    class BitmapControl : ComponentControl
    {
        public BitmapControl(Component and, string bitmapResource)
            : base(and)
        {
            mComponent = and;
            System.IO.Stream stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(bitmapResource);
            mBitmap = new Bitmap(stream);
        }

        ~BitmapControl()
        {
            mBitmap.Dispose();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < mComponent.Connections.Length; ++i)
            {
                Color c = mComponent.GetValue(i) ? Color.Red : Color.Black;
                int w = mComponent.Connections[i].Connections.Count > 0 ? 2 : 1;
                Pen pen = new Pen(c, w);

                g.DrawEllipse(pen, new Rectangle(Point.Subtract(mComponent.Connections[i].Location, new Size(2, 2)), new Size(4, 4)));
                g.DrawLine(pen, mComponent.Connections[i].Location, new Point(this.Width / 2, mComponent.Connections[i].Location.Y));
            }

            g.DrawImage(mBitmap, 0, 0);
        }

        private Component mComponent;
        private Bitmap mBitmap;
    }
}
