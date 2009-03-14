using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace LogicPuzzle.Components
{
    public class VerticalWire : Wire
    {
        public VerticalWire(Control parent)
            : base(parent, new Point(5, 5), new Point(5, 45))
        {
        }
    }

    public class ShortVerticalWire : Wire
    {
        public ShortVerticalWire(Control parent)
            : base(parent, new Point(5, 5), new Point(5, 25))
        {
        }
    }
}
