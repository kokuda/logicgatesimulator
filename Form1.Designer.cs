namespace LogicPuzzle
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addNandButton = new System.Windows.Forms.ToolStripButton();
            this.strobeButton = new System.Windows.Forms.ToolStripButton();
            this.bulbButton = new System.Windows.Forms.ToolStripButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.verticalWireButton = new System.Windows.Forms.ToolStripButton();
            this.horizontalWireButton = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNandButton,
            this.strobeButton,
            this.bulbButton,
            this.verticalWireButton,
            this.horizontalWireButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(292, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // addNandButton
            // 
            this.addNandButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.addNandButton.Image = ((System.Drawing.Image)(resources.GetObject("addNandButton.Image")));
            this.addNandButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addNandButton.Name = "addNandButton";
            this.addNandButton.Size = new System.Drawing.Size(36, 22);
            this.addNandButton.Text = "Nand";
            this.addNandButton.Click += new System.EventHandler(this.addNandButton_Click);
            // 
            // strobeButton
            // 
            this.strobeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.strobeButton.Image = ((System.Drawing.Image)(resources.GetObject("strobeButton.Image")));
            this.strobeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.strobeButton.Name = "strobeButton";
            this.strobeButton.Size = new System.Drawing.Size(43, 22);
            this.strobeButton.Text = "Strobe";
            this.strobeButton.Click += new System.EventHandler(this.strobeButton_Click);
            // 
            // bulbButton
            // 
            this.bulbButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.bulbButton.Image = ((System.Drawing.Image)(resources.GetObject("bulbButton.Image")));
            this.bulbButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bulbButton.Name = "bulbButton";
            this.bulbButton.Size = new System.Drawing.Size(31, 22);
            this.bulbButton.Text = "Bulb";
            this.bulbButton.Click += new System.EventHandler(this.bulbButton_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 217);
            this.panel1.TabIndex = 1;
            // 
            // verticalWireButton
            // 
            this.verticalWireButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.verticalWireButton.Image = ((System.Drawing.Image)(resources.GetObject("verticalWireButton.Image")));
            this.verticalWireButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.verticalWireButton.Name = "verticalWireButton";
            this.verticalWireButton.Size = new System.Drawing.Size(39, 22);
            this.verticalWireButton.Text = "VWire";
            this.verticalWireButton.ToolTipText = "Vertical Wire";
            this.verticalWireButton.Click += new System.EventHandler(this.verticalWireButton_Click);
            // 
            // horizontalWireButton
            // 
            this.horizontalWireButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.horizontalWireButton.Image = ((System.Drawing.Image)(resources.GetObject("horizontalWireButton.Image")));
            this.horizontalWireButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.horizontalWireButton.Name = "horizontalWireButton";
            this.horizontalWireButton.Size = new System.Drawing.Size(40, 22);
            this.horizontalWireButton.Text = "HWire";
            this.horizontalWireButton.ToolTipText = "Horizontal Wire";
            this.horizontalWireButton.Click += new System.EventHandler(this.horizontalWireButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(292, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileStripMenuItem
            // 
            this.fileStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.fileStripMenuItem.Name = "fileStripMenuItem";
            this.fileStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton addNandButton;
        private System.Windows.Forms.ToolStripButton strobeButton;
        private System.Windows.Forms.ToolStripButton bulbButton;
        private System.Windows.Forms.ToolStripButton verticalWireButton;
        private System.Windows.Forms.ToolStripButton horizontalWireButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
    }
}

