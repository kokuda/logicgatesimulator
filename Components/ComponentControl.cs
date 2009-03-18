using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace LogicPuzzle.Components
{
    public interface ComponentControlInterface
    {
        // Draw the component
        void DrawComponent(Graphics g);

        // The component may have been moved.
        // This should update any required information and check the connections.
        void MoveComponent();

        // Delete the component
        void DeleteComponent();
    }

    public class ComponentControl : Control
    {
        public ComponentControl(ComponentControlInterface controlInterface)
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;

            mControlInterface = controlInterface;
            mMouseDown = false;
        }

        public void DeleteComponent()
        {
            // Delete the logical Component
            mControlInterface.DeleteComponent();

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
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //e.Graphics.SetClip(Parent.DisplayRectangle);
            base.OnPaint(e);
            mControlInterface.DrawComponent(e.Graphics);
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
                mControlInterface.MoveComponent();
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

        private ComponentControlInterface mControlInterface;
        private bool mMouseDown;
        private int mMouseX;
        private int mMouseY;

    }
}
