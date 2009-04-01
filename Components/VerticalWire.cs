using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace LogicSim.Components
{
    public class VerticalWire : Wire
    {
        public VerticalWire()
            : base(new Point(5, 5), new Point(5, 45))
        {
        }
    }

    public class ShortVerticalWire : Wire
    {
        public ShortVerticalWire()
            : base(new Point(5, 5), new Point(5, 25))
        {
        }
    }
}
