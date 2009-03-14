using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace LogicPuzzle.Components
{
    /// <summary>
    /// A connection that doesn't store its value, but rather calculates it as
    /// the sum of all the inputs.
    /// </summary>
    public class WireConnection : Connection
    {
        public WireConnection(Component parent)
            : base(parent)
        {
            mProcessing = false;
        }

        // The value of a wire is just the sum of all inputs.
        // Rather than calculate and store the value, we calculate the value
        // dynamically.
        public override bool Value
        {
            get
            {
                // Avoid infinite recursion if the wire is attached to other wires.
                if (!mProcessing)
                {
                    // Instead of returning the value, we return the value of
                    // each of the attached connections for both ends of the wire.
                    mProcessing = true;
                    // We only need to get one value of the parent wire as each value is the same (sum of all connections).
                    bool value = Parent.GetValue(0); // || Parent.GetValue(1);
                    mProcessing = false;
                    return value;
                }
                else
                {
                    // If we have already passed this node then do not contribute
                    // anything more.
                    return false;
                }
            }
        }

        bool mProcessing;
    }

    /// <summary>
    /// A Component that acts as a wire bridge between other components.
    /// </summary>
    public class Wire : Component
    {
        public Wire(Control parent, Point in0, Point in1)
            : base(1,1)
        {
            Bounds = new Rectangle(0, 0, Math.Max(in0.X, in1.X) + 5, Math.Max(in0.Y, in1.Y) + 5);
            
            Connections[0] = new WireConnection(this);
            Connections[1] = new WireConnection(this);
            Connections[0].Location = in0;
            Connections[1].Location = in1;
        }

        public override void Setup()
        {
            mCalculated = false;
            mValue = false;
        }

        public override void Execute()
        {
            base.Execute();
        }

        public override bool GetValue(int index)
        {
            if (mCalculated)
            {
                return mValue;
            }

            // The value of either input is the logical OR of ALL connections
            // to all inputs.

            bool result = false;
            foreach (Connection c in Connections[0].Connections)
            {
                result |= c.Value;
            }

            foreach (Connection c in Connections[1].Connections)
            {
                result |= c.Value;
            }

            // Disable the caching of the values as it isn't propagating them correctly.
            // Also, the performance has improved so there may not be a need for the caching.
            //mValue = result;
            //mCalculated = true;
            return result;
        }

        protected override void OnDisconnect()
        {
            SetValue(0, false);
            SetValue(1, false);
            base.OnDisconnect();
        }

        private bool mCalculated;
        private bool mValue;
    }
}
