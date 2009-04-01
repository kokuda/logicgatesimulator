using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace LogicSim.Components
{
    public class HorizontalWire : Wire
    {
        public HorizontalWire()
            : base(new Point(5, 5), new Point(95, 5))
        {
        }
    }
    public class ShortHorizontalWire : Wire
    {
        public ShortHorizontalWire()
            : base(new Point(5, 5), new Point(50, 5))
        {
        }
    }
}
