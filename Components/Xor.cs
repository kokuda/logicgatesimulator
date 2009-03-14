using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace LogicPuzzle.Components
{
    class Xor : Component
    {
        public Xor(Control parent)
            : base(2, 1)
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            this.Parent = parent;
            this.Bounds = new Rectangle(0, 0, 100, 50);

            Connections[0].Location = new Point(5, 5);
            Connections[1].Location = new Point (5, this.Height - 5);
            Connections[2].Location = new Point(this.Width - 5, this.Height / 2);
        }

        public override void Execute()
        {
            SetValue(2, GetValue(0) ^ GetValue(1));
            base.Execute();
        }

        protected override void DrawComponent(Graphics g)
        {
            base.DrawComponent(g);
            g.DrawString("XOR", new Font("Courier", 10), Brushes.Black, this.Width / 2, this.Height / 2);
        }
    }
}
