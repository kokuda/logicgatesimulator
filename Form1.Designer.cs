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
            this.bulbButton = new System.Windows.Forms.ToolStripButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orButton = new System.Windows.Forms.ToolStripButton();
            this.powerDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.onToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.strobeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wireToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.horizontalWireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticalWireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.powerDropDownButton,
            this.addNandButton,
            this.bulbButton,
            this.orButton,
            this.wireToolStripDropDownButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(577, 25);
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
            this.panel1.Size = new System.Drawing.Size(577, 323);
            this.panel1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(577, 24);
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
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // orButton
            // 
            this.orButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.orButton.Image = ((System.Drawing.Image)(resources.GetObject("orButton.Image")));
            this.orButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.orButton.Name = "orButton";
            this.orButton.Size = new System.Drawing.Size(23, 22);
            this.orButton.Text = "Or";
            this.orButton.Click += new System.EventHandler(this.orButton_Click);
            // 
            // powerDropDownButton
            // 
            this.powerDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.powerDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.onToolStripMenuItem,
            this.strobeToolStripMenuItem});
            this.powerDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("powerDropDownButton.Image")));
            this.powerDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.powerDropDownButton.Name = "powerDropDownButton";
            this.powerDropDownButton.Size = new System.Drawing.Size(50, 22);
            this.powerDropDownButton.Text = "Power";
            // 
            // onToolStripMenuItem
            // 
            this.onToolStripMenuItem.Name = "onToolStripMenuItem";
            this.onToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.onToolStripMenuItem.Text = "On";
            this.onToolStripMenuItem.Click += new System.EventHandler(this.onToolStripMenuItem_Click);
            // 
            // strobeToolStripMenuItem
            // 
            this.strobeToolStripMenuItem.Name = "strobeToolStripMenuItem";
            this.strobeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.strobeToolStripMenuItem.Text = "Strobe";
            this.strobeToolStripMenuItem.Click += new System.EventHandler(this.strobeToolStripMenuItem_Click);
            // 
            // wireToolStripDropDownButton
            // 
            this.wireToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.wireToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.horizontalWireToolStripMenuItem,
            this.verticalWireToolStripMenuItem});
            this.wireToolStripDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("wireToolStripDropDownButton.Image")));
            this.wireToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.wireToolStripDropDownButton.Name = "wireToolStripDropDownButton";
            this.wireToolStripDropDownButton.Size = new System.Drawing.Size(42, 22);
            this.wireToolStripDropDownButton.Text = "Wire";
            // 
            // horizontalWireToolStripMenuItem
            // 
            this.horizontalWireToolStripMenuItem.Name = "horizontalWireToolStripMenuItem";
            this.horizontalWireToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.horizontalWireToolStripMenuItem.Text = "Horizontal Wire";
            this.horizontalWireToolStripMenuItem.Click += new System.EventHandler(this.horizontalWireToolStripMenuItem_Click);
            // 
            // verticalWireToolStripMenuItem
            // 
            this.verticalWireToolStripMenuItem.Name = "verticalWireToolStripMenuItem";
            this.verticalWireToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.verticalWireToolStripMenuItem.Text = "Vertical Wire";
            this.verticalWireToolStripMenuItem.Click += new System.EventHandler(this.verticalWireToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(577, 372);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Logic";
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
        private System.Windows.Forms.ToolStripButton bulbButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton orButton;
        private System.Windows.Forms.ToolStripDropDownButton powerDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem onToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem strobeToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton wireToolStripDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem horizontalWireToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verticalWireToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}

