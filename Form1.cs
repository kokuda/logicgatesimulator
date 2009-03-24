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

            mCircuit = new Circuit(panel1);
            mCircuit.Add(ShowComponent(new Components.On(panel1, 1000)));
        }

        private Circuit mCircuit;

        private void timer1_Tick(object sender, EventArgs e)
        {
            mCircuit.Run();
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

                    // Show each component in the circuit.
                    foreach (Components.Component c in mCircuit.Components)
                    {
                        c.Show(panel1, contextMenuStrip1);
                    }
                }
            }
        }

        private Components.Component ShowComponent(Components.Component c)
        {
            c.Show(panel1, contextMenuStrip1);
            return c;
        }

        private void bulbButton_Click(object sender, EventArgs e)
        {
            mCircuit.Add(ShowComponent(new Components.Bulb(panel1)));
        }

        private void onToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mCircuit.Add(ShowComponent(new Components.On(panel1, 0)));
        }

        private void strobeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mCircuit.Add(ShowComponent(new Components.On(panel1, 1000)));
        }

        private void horizontalWireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mCircuit.Add(ShowComponent(new Components.HorizontalWire(panel1)));
        }

        private void verticalWireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mCircuit.Add(ShowComponent(new Components.VerticalWire(panel1)));
        }

        private void shortVericalWireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mCircuit.Add(ShowComponent(new Components.ShortVerticalWire(panel1)));
        }

        private void andToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mCircuit.Add(ShowComponent(new Components.And(panel1)));
        }

        private void orToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mCircuit.Add(ShowComponent(new Components.Or(panel1)));
        }

        private void nandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mCircuit.Add(ShowComponent(new Components.Nand(panel1)));
        }

        private void xorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mCircuit.Add(ShowComponent(new Components.Xor(panel1)));
        }

        private void shortHorizontalWireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mCircuit.Add(ShowComponent(new Components.ShortHorizontalWire(panel1)));
        }

        private string GetNameWithoutExtension(string filename)
        {
            System.IO.FileInfo info = new System.IO.FileInfo(filename);
            return info.Name.Remove(info.Name.Length - info.Extension.Length);
        }

        private void userCreatedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog d = new OpenFileDialog();
            if (d.ShowDialog() == DialogResult.OK)
            {
                System.IO.Stream s;
                if ((s = d.OpenFile()) != null)
                {
                    Components.IC ic = new Components.IC(panel1, GetNameWithoutExtension(d.FileName));
                    ic.LoadCircuit(s);
                    s.Close();

                    mCircuit.Add(ShowComponent(ic));
                }
            }
        }

        class MyToolStripButton : ToolStripButton
        {
            public MyToolStripButton(string name, Components.ComponentControl component)
                : base(name)
            {
                mComponent = component;
            }

            public Components.ComponentControl Component
            {
                get { return mComponent; }
                set { mComponent = value; }
            }
            Components.ComponentControl mComponent;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            Components.ComponentControl c = contextMenuStrip1.SourceControl as Components.ComponentControl;
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
            b.Component.DeleteComponent();
        }
    }
}
