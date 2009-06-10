﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace LogicSim.Components
{
    ///////////////////////////////////////////////////////////////////////
    // ComponentControl : Control
    ///////////////////////////////////////////////////////////////////////
    public class ComponentControl : Control
    {
        public ComponentControl(Component component)
        {
            //SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //BackColor = Color.Transparent;
            //this.DoubleBuffered = true;

            mComponent = component;
            mMouseDown = false;
        }

        public void DeleteComponent()
        {
            // Delete the visual component
            if (Parent != null)
            {
                if (Parent.Controls.Contains(this))
                {
                    Parent.Controls.Remove(this);
                }
            }
            Dispose();
            Parent = null;

            // Remove the logical Component
            mComponent.Circuit.Remove(mComponent);
            mComponent = null;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Start a drag
                mMouseDown = true;
                mMouseX = e.X;
                mMouseY = e.Y;
                this.BringToFront();
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mMouseDown = false;

                // Snap to grid.
                int gridSize = 5;
                mComponent.Location = new Point((mComponent.Location.X + (gridSize / 2)) / gridSize * gridSize, (mComponent.Location.Y + (gridSize / 2)) / gridSize * gridSize);

                // The component may have moved.
                // Reconnect any connections in the circuit.
                mComponent.Circuit.ConnectComponent(mComponent);
            }
            base.OnMouseUp(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (mMouseDown)
            {
                this.SetBounds(Location.X + e.X - mMouseX, Location.Y + e.Y - mMouseY, Bounds.Width, Bounds.Height);
                base.OnMouseMove(e);
                InvalidateEx();
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020; //WS_EX_TRANSPARENT
                return cp;
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            //do not allow the background to be painted 
        }

        public void InvalidateEx()
        {
            if (Parent == null)
                return;

            Rectangle rc = new Rectangle(this.Location, this.Size);
            Parent.Invalidate(rc, true);
        }

        public virtual void ShowContextMenu(ContextMenuStrip menu, CancelEventArgs e)
        {
            // TODO: This could be used to add individual context menus for
            // different controls.
            // we need to go through the ComponentControlInterface for that.
        }

        protected Component mComponent;
        protected bool mMouseDown;
        protected int mMouseX;
        protected int mMouseY;

    }

    ///////////////////////////////////////////////////////////////////////
    // DefaultDrawComponentControl : ComponentControl
    ///////////////////////////////////////////////////////////////////////
    public class DefaultDrawComponentControl : ComponentControl
    {
        public DefaultDrawComponentControl(Component component)
            : base(component)
        {
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Pen blackpen = new Pen(Color.Black, 1);
            Graphics g = e.Graphics;

            for (int i = 0; i < mComponent.GetComponent().Connections.Length; ++i)
            {
                Color c = mComponent.GetComponent().GetValue(i) ? Color.Red : Color.Black;
                int w = mComponent.GetComponent().Connections[i].Connections.Count > 0 ? 2 : 1;
                Pen pen = new Pen(c, w);

                g.DrawEllipse(pen, new Rectangle(Point.Subtract(mComponent.GetComponent().Connections[i].Location, new Size(2, 2)), new Size(4, 4)));
                g.DrawLine(pen, mComponent.GetComponent().Connections[i].Location, new Point(this.Width / 2, this.Height / 2));
            }
            g.DrawEllipse(blackpen, this.Width / 3, this.Height / 3, this.Width / 3, this.Height / 3);
        }
    }

    ///////////////////////////////////////////////////////////////////////
    // BitmapComponentControl : ComponentControl
    ///////////////////////////////////////////////////////////////////////
    class BitmapComponentControl : ComponentControl
    {
        public BitmapComponentControl(Component component, string bitmapResource)
            : base(component)
        {
            System.IO.Stream stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(bitmapResource);
            mBitmap = new Bitmap(stream);
        }

        ~BitmapComponentControl()
        {
            mBitmap.Dispose();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            for (int i = 0; i < mComponent.Connections.Length; ++i)
            {
                Color c = mComponent.GetValue(i) ? Color.Red : Color.Black;
                int w = mComponent.Connections[i].Connections.Count > 0 ? 2 : 1;
                Pen pen = new Pen(c, w);

                g.DrawEllipse(pen, new Rectangle(Point.Subtract(mComponent.Connections[i].Location, new Size(2, 2)), new Size(4, 4)));
                g.DrawLine(pen, mComponent.Connections[i].Location, new Point(this.Width / 2, mComponent.Connections[i].Location.Y));
            }

            g.DrawImage(mBitmap, 0, 0);
        }

        private Bitmap mBitmap;
    }

}
