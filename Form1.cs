using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LogicPuzzle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //BackColor = Color.Transparent;

            mCircuit = new Circuit(panel1);
            //mCircuit.Add(new Components.Nand(panel1));
            //mCircuit.Add(new Components.Nand(panel1));
            mCircuit.Add(InitializeComponent(new Components.On(panel1, 1000)));
        }

        private Circuit mCircuit;

        private void timer1_Tick(object sender, EventArgs e)
        {
            mCircuit.Run();
            System.GC.Collect();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.SaveFileDialog d = new System.Windows.Forms.SaveFileDialog();
            if (d.ShowDialog() == DialogResult.OK)
            {
                System.IO.Stream s;
                if ((s = d.OpenFile()) != null)
                {
                    mCircuit.Serialize(s);
                    s.Close();
                }
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog d = new OpenFileDialog();
            if (d.ShowDialog() == DialogResult.OK)
            {
                System.IO.Stream s;
                if ((s = d.OpenFile()) != null)
                {
                    mCircuit.Deserialize(s);
                    s.Close();
                }
            }
        }

        private Components.Component InitializeComponent(Components.Component c)
        {
            // We currently set the parent through the constructor, but I'm not
            // sure that this is the best way to do it.
            //c.Parent = panel1;
            c.ContextMenuStrip = contextMenuStrip1;
            return c;
        }

        private void addNandButton_Click(object sender, EventArgs e)
        {
            mCircuit.Add(InitializeComponent(new Components.Nand(panel1)));
        }

        private void bulbButton_Click(object sender, EventArgs e)
        {
            mCircuit.Add(InitializeComponent(new Components.Bulb(panel1)));
        }

        private void orButton_Click(object sender, EventArgs e)
        {
            mCircuit.Add(InitializeComponent(new Components.Or(panel1)));
        }

        private void onToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mCircuit.Add(InitializeComponent(new Components.On(panel1, 0)));
        }

        private void strobeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mCircuit.Add(InitializeComponent(new Components.On(panel1, 1000)));
        }

        private void horizontalWireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mCircuit.Add(InitializeComponent(new Components.HorizontalWire(panel1)));
        }

        private void verticalWireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mCircuit.Add(InitializeComponent(new Components.VerticalWire(panel1)));
        }

        class MyToolStripButton : ToolStripButton
        {
            public MyToolStripButton(string name, Components.Component component)
                : base(name)
            {
                mComponent = component;
            }

            public Components.Component Component
            {
                get { return mComponent; }
                set { mComponent = value; }
            }
            Components.Component mComponent;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            Components.Component c = contextMenuStrip1.SourceControl as Components.Component;
            contextMenuStrip1.Items.Clear();
            ToolStripItem delete = new MyToolStripButton("Delete", c);
            delete.Click +=new EventHandler(delete_Click);
            contextMenuStrip1.Items.Add(delete);
            c.ShowContextMenu(contextMenuStrip1,e);
            e.Cancel = false;
        }

        void delete_Click(object sender, EventArgs e)
        {
            MyToolStripButton b = sender as MyToolStripButton;
            mCircuit.Remove(b.Component);
            if (panel1.Controls.Contains(b.Component))
            {
                panel1.Controls.Remove(b.Component);
            }
            b.Component.Dispose();
        }
    }
}
