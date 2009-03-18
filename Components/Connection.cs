using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace LogicPuzzle.Components
{
    public class ConnectionList : List<WeakReference>
    {
        public void Add(Connection c)
        {
            Add(new WeakReference(c));
        }

        public bool Remove(Connection c)
        {
            bool result = false;
            WeakReference wr = this.Find(delegate(WeakReference r)
            {
                if (r.Target == c)
                {
                    return true;
                }
                return false;
            });

            if (wr != null)
            {
                result = this.Remove(wr);
            }

            return result;
        }

        // Doesn't return an IEnumerator:
        public new ConnectionEnumerator GetEnumerator()
        {
            return new ConnectionEnumerator(base.GetEnumerator());
        }

        public class ConnectionEnumerator
        {
            private List<WeakReference>.Enumerator mEnumerator;

            public ConnectionEnumerator(List<WeakReference>.Enumerator e)
            {
                mEnumerator = e;
            }

            public bool MoveNext()
            {
                bool result = false;

                // Skip over null values
                do
                {
                    result = mEnumerator.MoveNext();
                }
                while (result && (mEnumerator.Current.Target == null));

                return result;
            }

            public Connection Current
            {
                get { return mEnumerator.Current.Target as Connection; }
            }
        }

    }

    public class Connection
    {
        public Connection(Component parent)
        {
            mConnections = new ConnectionList();
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

        public ConnectionList Connections
        {
            get { return mConnections; }
        }

        public Component Parent
        {
            get { return mParent; }
        }

        Point mLocation;
        bool mValue;
        ConnectionList mConnections;
        Component mParent;
    }
}
