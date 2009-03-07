using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace LogicPuzzle.Components
{
    class On : Component
    {
        public On(Control parent)
            : base(0, 1)
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            this.Parent = parent;
            this.Bounds = new Rectangle(0, 0, 100, 50);

            Connections[0].Location = new Point(this.Width - 5, this.Height / 2);
        }

        public override void Execute()
        {
            // We are always on.
            SetValue(0, true);
            Invalidate();
        }

        protected override void DrawComponent(Graphics g)
        {
            int thickness = Connections[0].Connections.Count > 0 ? 2 : 1;
            Pen p = new Pen(Color.Red, thickness);
            g.DrawEllipse(p, this.Width / 3, this.Height / 3, this.Width / 3, this.Height / 3);
            g.DrawEllipse(p, new Rectangle(Point.Subtract(Connections[0].Location, new Size(2,2)), new Size(4, 4)));
            g.DrawLine(p, new Point(this.Width / 2, this.Height / 2), Connections[0].Location);
            g.DrawString("On", new Font("Courier", 10), Brushes.Black, this.Width / 2, this.Height / 2);
        }
    }
}
