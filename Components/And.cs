using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace LogicPuzzle.Components
{
    class And : Component
    {
        public And()
            : base(2, 1)
        {
            Bounds = new Rectangle(0, 0, 100, 50);

            Connections[0].Location = new Point(5, 5);
            Connections[1].Location = new Point (5, this.Height - 5);
            Connections[2].Location = new Point(this.Width - 5, this.Height / 2);

            System.IO.Stream stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("LogicPuzzle.Resources.And.png");
            mBitmap = new Bitmap(stream);
        }

        ~And()
        {
            mBitmap.Dispose();
        }

        public override void Execute()
        {
            SetValue(2, GetValue(0) && GetValue(1));
            base.Execute();
        }

        public override void DrawComponent(Graphics g)
        {
            //base.DrawComponent(g);

            for (int i = 0; i < mConnections.Length; ++i)
            {
                Color c = GetValue(i) ? Color.Red : Color.Black;
                int w = mConnections[i].Connections.Count > 0 ? 2 : 1;
                Pen pen = new Pen(c, w);

                g.DrawEllipse(pen, new Rectangle(Point.Subtract(mConnections[i].Location, new Size(2, 2)), new Size(4, 4)));
                g.DrawLine(pen, mConnections[i].Location, new Point(this.Width / 2, mConnections[i].Location.Y));
            }

            g.DrawImage(mBitmap, 0, 0);
            //g.DrawString("AND", new Font("Courier", 10), Brushes.Black, this.Width / 2, this.Height / 2);
        }

        Bitmap mBitmap;
    }
}
