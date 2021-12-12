using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

// Initial design and code from https://github.com/RJCodeAdvance/RJControls/blob/main/CustomControls/RJControls/RJDatePicker.cs
// Improved by Group3 dmai0920
namespace DesktopClientWinforms.Components
{
    public class FlatDatePicker : DateTimePicker
    {
        //Fields
        //-> Appearance
        private Color skinColor = Color.MediumSlateBlue;
        private Color textColor = Color.White;
        private Color borderColor = Color.PaleVioletRed;
        private int borderSize = 0;

        //-> Other Values
        private bool droppedDown = false;
        private Image calendarIcon = null;
        private RectangleF iconButtonArea;
        private const int calendarIconWidth = 34;
        private const int arrowIconWidth = 17;

        //Properties
        public Image CalendarIcon
        {
            get { return calendarIcon; }
            set
            {
                calendarIcon = value;
                Invalidate();
            }
        }

        public Color SkinColor
        {
            get { return skinColor; }
            set
            {
                skinColor = value;
                Invalidate();
            }
        }

        public Color TextColor
        {
            get { return textColor; }
            set
            {
                textColor = value;
                Invalidate();
            }
        }

        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                borderSize = value;
                Invalidate();
            }
        }

        //Constructor
        public FlatDatePicker()
        {
            SetStyle(ControlStyles.UserPaint, true);
            MinimumSize = new Size(0, 35);
            Font = new Font(Font.Name, 9.5F);
        }

        //Overridden methods
        protected override void OnDropDown(EventArgs eventargs)
        {
            base.OnDropDown(eventargs);
            droppedDown = true;
        }
        protected override void OnCloseUp(EventArgs eventargs)
        {
            base.OnCloseUp(eventargs);
            droppedDown = false;
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            e.Handled = true;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            using Graphics graphics = CreateGraphics();
            using Pen penBorder = new Pen(borderColor, borderSize);
            using SolidBrush skinBrush = new SolidBrush(skinColor);
            using SolidBrush openIconBrush = new SolidBrush(Color.FromArgb(50, 64, 64, 64));
            using SolidBrush textBrush = new SolidBrush(textColor);
            using StringFormat textFormat = new StringFormat();
            RectangleF clientArea = new RectangleF(0, 0, Width - 0.5F, Height - 0.5F);
            RectangleF iconArea = new RectangleF(clientArea.Width - calendarIconWidth, 0, calendarIconWidth, clientArea.Height);
            penBorder.Alignment = PenAlignment.Inset;
            textFormat.LineAlignment = StringAlignment.Center;

            //Draw surface
            graphics.FillRectangle(skinBrush, clientArea);
            //Draw text
            graphics.DrawString(Text, Font, textBrush, clientArea, textFormat);
            //Draw open calendar icon highlight
            if (droppedDown == true) graphics.FillRectangle(openIconBrush, iconArea);
            //Draw border 
            if (borderSize >= 1) graphics.DrawRectangle(penBorder, clientArea.X, clientArea.Y, clientArea.Width, clientArea.Height);
            //Draw icon
            if(CalendarIcon != null)
            {
                int offset = 9;
                if(ShowUpDown)
                {
                    offset += 20;
                }
                graphics.DrawImage(CalendarIcon, Width - CalendarIcon.Width - offset, (Height - CalendarIcon.Height) / 2);
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            int iconWidth = GetIconButtonWidth();
            iconButtonArea = new RectangleF(Width - iconWidth, 0, iconWidth, Height);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (iconButtonArea.Contains(e.Location))
                Cursor = Cursors.Hand;
            else Cursor = Cursors.Default;
        }

        //Private methods
        private int GetIconButtonWidth()
        {
            int textWidh = TextRenderer.MeasureText(Text, Font).Width;
            if (textWidh <= Width - (calendarIconWidth + 20))
                return calendarIconWidth;
            else return arrowIconWidth;
        }
    }
}