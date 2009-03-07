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
            mCircuit.Add(new Components.Strobe(panel1, 1000));
        }

        private Circuit mCircuit;

        private void timer1_Tick(object sender, EventArgs e)
        {
            mCircuit.Run();
        }

        private void addNandButton_Click(object sender, EventArgs e)
        {
            mCircuit.Add(new Components.Nand(panel1));
        }

        private void strobeButton_Click(object sender, EventArgs e)
        {
            mCircuit.Add(new Components.Strobe(panel1, 1000));
        }

        private void bulbButton_Click(object sender, EventArgs e)
        {
            mCircuit.Add(new Components.Bulb(panel1));
        }

        private void verticalWireButton_Click(object sender, EventArgs e)
        {
            mCircuit.Add(new Components.VerticalWire(panel1));
        }

        private void horizontalWireButton_Click(object sender, EventArgs e)
        {
            mCircuit.Add(new Components.HorizontalWire(panel1));
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
    }
}
