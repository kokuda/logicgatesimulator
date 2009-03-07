using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace LogicPuzzle.Components
{
    public class Connection
    {
        public Connection(Component parent)
        {
            mConnections = new List<Connection>();
            mValue = false;
            mParent = parent;
        }

        public Point Location
        {
            get { return mLocation; }
            set { mLocation = value; }
        }

        public virtual bool Value
        {
            get { return mValue; }
            set { mValue = value; }
        }

        public List<Connection> Connections
        {
            get { return mConnections; }
        }

        public Component Parent
        {
            get { return mParent; }
        }

        Point mLocation;
        bool mValue;
        List<Connection> mConnections;
        Component mParent;
    }
}
