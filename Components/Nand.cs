﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace LogicPuzzle.Components
{
    public class Nand : Component
    {
        public Nand(Control parent)
            : base(2, 1)
        {
            Bounds = new Rectangle(0, 0, 100, 50);

            Connections[0].Location = new Point(5, 5);
            Connections[1].Location = new Point(5, Height - 5);
            Connections[2].Location = new Point(Width - 5, Height / 2);
        }

        public override void Execute()
        {
            SetValue(2, !(GetValue(0) && GetValue(1)));
            base.Execute();
        }

        public override void DrawComponent(Graphics g)
        {
            base.DrawComponent(g);
            g.DrawString("NAND", new Font("Courier", 10), Brushes.Black, this.Width / 2, this.Height / 2);
        }

        //protected override void DrawComponent(Graphics g)
        //{
        //    Pen p = new Pen(Color.Black);
        //    g.DrawEllipse(p, this.Width/3, this.Height/3, this.Width/3, this.Height/3);
        //    g.DrawEllipse(p, new Rectangle(InputLocations[0], new Size(4, 4)));
        //    g.DrawEllipse(p, new Rectangle(InputLocations[1], new Size(4, 4)));
        //    g.DrawEllipse(p, new Rectangle(OutputLocations[0], new Size(4, 4)));
        //}
    }
}
