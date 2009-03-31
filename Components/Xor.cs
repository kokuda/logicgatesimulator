using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace LogicPuzzle.Components
{
    class Xor : Component
    {
        public Xor()
            : base(2, 1)
        {
            Bounds = new Rectangle(0, 0, 100, 50);

            Connections[0].Location = new Point(5, 5);
            Connections[1].Location = new Point (5, this.Height - 5);
            Connections[2].Location = new Point(this.Width - 5, this.Height / 2);
        }

        public override void Execute()
        {
            SetValue(2, GetValue(0) ^ GetValue(1));
            base.Execute();
        }

        protected override ComponentControl CreateComponentControl()
        {
            return new BitmapControl(this, "LogicPuzzle.Resources.Xor.png");
        }
    }
}
