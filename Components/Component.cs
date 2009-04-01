using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace LogicPuzzle.Components
{
    // Handle generic logic component behaviours, such as drag and drop.
    public class Component
    {
        // Default constructor needed so that Visual Studio doesn't fail
        // when attempting to open the components in design mode.
        public Component()
        {
            Reinitalize(0, 0);
        }

        public Component(int inputs, int outputs)
        {
            Reinitalize(inputs, outputs);
        }

        public void Reinitalize(int inputs, int outputs)
        {
            mConnections = new Connection[inputs + outputs];
            mPreviousValues = new bool[inputs + outputs];
            for (int i = 0; i < mConnections.Length; ++i)
            {
                mConnections[i] = new Connection(this);
                mPreviousValues[i] = false;
            }
        }

        public virtual void Dispose()
        {
            if (mControl != null)
            {
                mControl.Dispose();
            }

            for (int i = 0; i < mConnections.Length; ++i)
            {
                mConnections[i] = null;
            }

            mConnections = null;
        }

        ~Component()
        {
            //Disconnect();
        }

        public void Show(Control parent, ContextMenuStrip menuStrip)
        {
            // Create the control if it does not exist and initialize it.
            if (mControl == null || mControl.IsDisposed)
            {
                mControl = CreateComponentControl();
            }
            mControl.Bounds = mBounds;
            mControl.Location = mLocation;
            mControl.Parent = parent;
            mControl.ContextMenuStrip = menuStrip;
        }

        protected virtual ComponentControl CreateComponentControl()
        {
            return new ComponentControl(this);
        }

        public virtual void Setup()
        {
        }

        // Calculate the outputs from the inputs.
        public virtual void Execute()
        {
            if (ValuesDiffer())
            {
                InvalidateEx();
            }
        }

        public virtual void ConnectInput(int index, Connection c)
        {
            mConnections[index].Connections.Add(c);
            OnConnect();
        }

        public virtual void ConnectOutput(int index, Connection c)
        {
            mConnections[index].Connections.Add(c);
            OnConnect();
        }

        public virtual void Disconnect()
        {
            for (int c = 0; c < mConnections.Length; ++c )
            {
                foreach (Connection comp in mConnections[c].Connections)
                {
                    if (comp.Connections.Remove(mConnections[c]))
                    {
                        // Notify the component that it has had a connection removed.
                        comp.Parent.OnDisconnect();
                    }
                }
                mConnections[c].Connections.Clear();
            }

            OnDisconnect();
        }

        public virtual bool GetValue(int index)
        {
            bool result = mConnections[index].Value;
            foreach (Connection c in mConnections[index].Connections)
            {
                result |= c.Value;
            }
            return result;
        }

        public virtual void SetValue(int index, bool value)
        {
            // Set the output value, for polling.
            mConnections[index].Value = value;
        }


        public virtual void Serialize(System.Xml.XmlWriter writer)
        {
        }

        public virtual void Deserialize(System.Xml.XmlReader reader)
        {
        }

        public Component GetComponent()
        {
            return this;
        }

        ///////////////////////////////////////////////////////////////////////
        // Public Properties
        ///////////////////////////////////////////////////////////////////////
        public Rectangle Bounds
        {
            get
            {
                return mBounds;
            }
            set
            {
                if (mControl != null)
                {
                    mControl.Bounds = value;
                }
                mBounds = value;
            }
        }

        public int Width
        {
            get { return Bounds.Width; }
        }

        public int Height
        {
            get { return Bounds.Height; }
        }

        private Point mLocation;
        public Point Location
        {
            get
            {
                if (mControl != null)
                {
                    mLocation = mControl.Location;
                }
                return mLocation;
            }
            set
            {
                if (mControl != null)
                {
                    mControl.Location = value;
                }
                mLocation = value;
            }
        }

        public virtual Connection[] Connections
        {
            get { return mConnections; }
        }

        public virtual Circuit Circuit
        {
            set { mCircuit = value; }
            get { return mCircuit; }
        }

        protected virtual void OnDisconnect()
        {
            InvalidateEx();
        }

        protected virtual void OnConnect()
        {
            InvalidateEx();
        }

        ///////////////////////////////////////////////////////////////////////
        // Private
        ///////////////////////////////////////////////////////////////////////

        private bool ValuesDiffer()
        {
            bool dirty = false;

            // Compare the current value of each connection with
            // the previously stored values.
            for (int i = 0; i < Connections.Length; ++i )
            {
                bool value = GetValue(i);
                if (mPreviousValues[i] != value)
                {
                    dirty = true;
                    mPreviousValues[i] = value;
                }
            }

            return dirty;
        }

        private void InvalidateEx()
        {
            if (mControl != null)
            {
                mControl.InvalidateEx();
            }
        }

        protected Connection[] mConnections;
        private Circuit mCircuit;
        private bool[] mPreviousValues;
        private ComponentControl mControl;
        private Rectangle mBounds;
    }
}
