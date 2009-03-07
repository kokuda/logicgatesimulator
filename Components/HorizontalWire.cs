using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace LogicPuzzle.Components
{
    public class HorizontalWire : Wire
    {
        public HorizontalWire(Control parent)
            : base(parent, new Point(5, 5), new Point(95, 5))
        {
        }
    }
}
