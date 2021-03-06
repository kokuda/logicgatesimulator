﻿namespace LogicSim
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
            this.powerDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.onToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.strobeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bulbButton = new System.Windows.Forms.ToolStripButton();
            this.wireToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.horizontalWireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticalWireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shortVericalWireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shortHorizontalWireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gatesToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.notToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.andToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bitDisplayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bitDisplayToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.userCreatedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.switchButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.powerDropDownButton,
            this.bulbButton,
            this.wireToolStripDropDownButton,
            this.gatesToolStripDropDownButton,
            this.switchButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(577, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
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
            this.powerDropDownButton.Size = new System.Drawing.Size(53, 22);
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
            // bulbButton
            // 
            this.bulbButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.bulbButton.Image = ((System.Drawing.Image)(resources.GetObject("bulbButton.Image")));
            this.bulbButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bulbButton.Name = "bulbButton";
            this.bulbButton.Size = new System.Drawing.Size(35, 22);
            this.bulbButton.Text = "Bulb";
            this.bulbButton.Click += new System.EventHandler(this.bulbButton_Click);
            // 
            // wireToolStripDropDownButton
            // 
            this.wireToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.wireToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.horizontalWireToolStripMenuItem,
            this.verticalWireToolStripMenuItem,
            this.shortVericalWireToolStripMenuItem,
            this.shortHorizontalWireToolStripMenuItem});
            this.wireToolStripDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("wireToolStripDropDownButton.Image")));
            this.wireToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.wireToolStripDropDownButton.Name = "wireToolStripDropDownButton";
            this.wireToolStripDropDownButton.Size = new System.Drawing.Size(44, 22);
            this.wireToolStripDropDownButton.Text = "Wire";
            // 
            // horizontalWireToolStripMenuItem
            // 
            this.horizontalWireToolStripMenuItem.Name = "horizontalWireToolStripMenuItem";
            this.horizontalWireToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.horizontalWireToolStripMenuItem.Text = "Horizontal Wire";
            this.horizontalWireToolStripMenuItem.Click += new System.EventHandler(this.horizontalWireToolStripMenuItem_Click);
            // 
            // verticalWireToolStripMenuItem
            // 
            this.verticalWireToolStripMenuItem.Name = "verticalWireToolStripMenuItem";
            this.verticalWireToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.verticalWireToolStripMenuItem.Text = "Vertical Wire";
            this.verticalWireToolStripMenuItem.Click += new System.EventHandler(this.verticalWireToolStripMenuItem_Click);
            // 
            // shortVericalWireToolStripMenuItem
            // 
            this.shortVericalWireToolStripMenuItem.Name = "shortVericalWireToolStripMenuItem";
            this.shortVericalWireToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.shortVericalWireToolStripMenuItem.Text = "Short Verical Wire";
            this.shortVericalWireToolStripMenuItem.Click += new System.EventHandler(this.shortVericalWireToolStripMenuItem_Click);
            // 
            // shortHorizontalWireToolStripMenuItem
            // 
            this.shortHorizontalWireToolStripMenuItem.Name = "shortHorizontalWireToolStripMenuItem";
            this.shortHorizontalWireToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.shortHorizontalWireToolStripMenuItem.Text = "Short Horizontal Wire";
            this.shortHorizontalWireToolStripMenuItem.Click += new System.EventHandler(this.shortHorizontalWireToolStripMenuItem_Click);
            // 
            // gatesToolStripDropDownButton
            // 
            this.gatesToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.gatesToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.notToolStripMenuItem,
            this.andToolStripMenuItem,
            this.orToolStripMenuItem,
            this.nandToolStripMenuItem,
            this.xorToolStripMenuItem,
            this.bitDisplayToolStripMenuItem,
            this.bitDisplayToolStripMenuItem1,
            this.userCreatedToolStripMenuItem});
            this.gatesToolStripDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("gatesToolStripDropDownButton.Image")));
            this.gatesToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.gatesToolStripDropDownButton.Name = "gatesToolStripDropDownButton";
            this.gatesToolStripDropDownButton.Size = new System.Drawing.Size(49, 22);
            this.gatesToolStripDropDownButton.Text = "Gates";
            // 
            // notToolStripMenuItem
            // 
            this.notToolStripMenuItem.Name = "notToolStripMenuItem";
            this.notToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.notToolStripMenuItem.Text = "Not";
            this.notToolStripMenuItem.Click += new System.EventHandler(this.notToolStripMenuItem_Click);
            // 
            // andToolStripMenuItem
            // 
            this.andToolStripMenuItem.Name = "andToolStripMenuItem";
            this.andToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.andToolStripMenuItem.Text = "And";
            this.andToolStripMenuItem.Click += new System.EventHandler(this.andToolStripMenuItem_Click);
            // 
            // orToolStripMenuItem
            // 
            this.orToolStripMenuItem.Name = "orToolStripMenuItem";
            this.orToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.orToolStripMenuItem.Text = "Or";
            this.orToolStripMenuItem.Click += new System.EventHandler(this.orToolStripMenuItem_Click);
            // 
            // nandToolStripMenuItem
            // 
            this.nandToolStripMenuItem.Name = "nandToolStripMenuItem";
            this.nandToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nandToolStripMenuItem.Text = "Nand";
            this.nandToolStripMenuItem.Click += new System.EventHandler(this.nandToolStripMenuItem_Click);
            // 
            // xorToolStripMenuItem
            // 
            this.xorToolStripMenuItem.Name = "xorToolStripMenuItem";
            this.xorToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.xorToolStripMenuItem.Text = "Xor";
            this.xorToolStripMenuItem.Click += new System.EventHandler(this.xorToolStripMenuItem_Click);
            // 
            // bitDisplayToolStripMenuItem
            // 
            this.bitDisplayToolStripMenuItem.Name = "bitDisplayToolStripMenuItem";
            this.bitDisplayToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.bitDisplayToolStripMenuItem.Text = "4 Bit Display";
            this.bitDisplayToolStripMenuItem.Click += new System.EventHandler(this.bitDisplayToolStripMenuItem_Click);
            // 
            // bitDisplayToolStripMenuItem1
            // 
            this.bitDisplayToolStripMenuItem1.Name = "bitDisplayToolStripMenuItem1";
            this.bitDisplayToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.bitDisplayToolStripMenuItem1.Text = "8 Bit Display";
            this.bitDisplayToolStripMenuItem1.Click += new System.EventHandler(this.bitDisplayToolStripMenuItem1_Click);
            // 
            // userCreatedToolStripMenuItem
            // 
            this.userCreatedToolStripMenuItem.Name = "userCreatedToolStripMenuItem";
            this.userCreatedToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.userCreatedToolStripMenuItem.Text = "User Defined...";
            this.userCreatedToolStripMenuItem.Click += new System.EventHandler(this.userCreatedToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
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
            this.fileStripMenuItem,
            this.helpToolStripMenuItem});
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
            this.loadToolStripMenuItem,
            this.newToolStripMenuItem});
            this.fileStripMenuItem.Name = "fileStripMenuItem";
            this.fileStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.saveToolStripMenuItem.Text = "Save...";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.loadToolStripMenuItem.Text = "Load...";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // switchButton
            // 
            this.switchButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.switchButton.Image = ((System.Drawing.Image)(resources.GetObject("switchButton.Image")));
            this.switchButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.switchButton.Name = "switchButton";
            this.switchButton.Size = new System.Drawing.Size(46, 22);
            this.switchButton.Text = "Switch";
            this.switchButton.Click += new System.EventHandler(this.switchButton_Click);
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
            this.Text = "LogicSim";
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
        private System.Windows.Forms.ToolStripButton bulbButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton powerDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem onToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem strobeToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton wireToolStripDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem horizontalWireToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verticalWireToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem shortVericalWireToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton gatesToolStripDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem andToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shortHorizontalWireToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userCreatedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bitDisplayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bitDisplayToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton switchButton;
    }
}

