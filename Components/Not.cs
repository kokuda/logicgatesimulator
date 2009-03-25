using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace LogicPuzzle.Components
{
    class Not : Component
    {
        public Not()
            : base(1, 1)
        {
            Bounds = new Rectangle(0, 0, 100, 50);

            Connections[0].Location = new Point(5, Height / 2);
            Connections[1].Location = new Point(Width - 5, Height / 2);
        }

        public override void Execute()
        {
            SetValue(1, !GetValue(0));
            base.Execute();
        }

        public override void DrawComponent(Graphics g)
        {
            base.DrawComponent(g);
            g.DrawString("NOT", new Font("Courier", 10), Brushes.Black, this.Width / 2, this.Height / 2);
        }
    }
}
