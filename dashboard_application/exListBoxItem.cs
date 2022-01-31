using System;
using System.Collections.Generic;
using System.Text;
using Google.Cloud.Firestore;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace lastone1
{
    public class exListBoxItem
    {
        private string _ConnectionStatus;
        private string _anti_Name;
        private string _anti_Enabled;

        public exListBoxItem(string connStatus, string antiName, string antiEnabled)
        {
            _ConnectionStatus = connStatus;
            _anti_Name = antiName;
            _anti_Enabled = antiEnabled;
        }
        public string Connection_Status
        {
            get { return _ConnectionStatus; }
            set { _ConnectionStatus = value; }
        }
        public string anti_Name
        {
            get { return _anti_Name; }
            set { _anti_Name = value; }
        }
        public string anti_Enabled
        {
            get { return _anti_Enabled; }
            set { _anti_Enabled = value; }
        }
        public void drawItem(DrawItemEventArgs e, Padding margin,
                             Font titleFont, Font detailsFont, Font NameFont, StringFormat aligment)
        {

            // if selected, mark the background differently
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.Beige, e.Bounds);
            }

            // draw some item separator
            e.Graphics.DrawLine(Pens.DarkGray, e.Bounds.X, e.Bounds.Y, e.Bounds.X + e.Bounds.Width, e.Bounds.Y);

            // draw item image
            //e.Graphics.DrawImage(this.ItemImage, e.Bounds.X + margin.Left, e.Bounds.Y + margin.Top, imageSize.Width, imageSize.Height);

            // calculate bounds for title text drawing
            Rectangle titleBounds = new Rectangle(e.Bounds.X + margin.Horizontal,
                                                  e.Bounds.Y + margin.Top,
                                                  e.Bounds.Width - margin.Right- margin.Horizontal,
                                                  (int)titleFont.GetHeight() + 2);

            // calculate bounds for details text drawing
            Rectangle detailBounds = new Rectangle(e.Bounds.X + margin.Horizontal,
                                                   e.Bounds.Y + (int)titleFont.GetHeight() + 2 + margin.Vertical + margin.Top,
                                                   e.Bounds.Width - margin.Right- margin.Horizontal,
                                                   e.Bounds.Height - margin.Bottom - (int)titleFont.GetHeight() - 2 - margin.Vertical - margin.Top);
            
            // calculate bounds for details text drawing
            Rectangle NameBounds = new Rectangle(e.Bounds.X + margin.Horizontal ,
                                                   e.Bounds.Y + (int)titleFont.GetHeight() + 4 + margin.Vertical + margin.Top,
                                                   e.Bounds.Width - margin.Right- margin.Horizontal,
                                                   e.Bounds.Height - margin.Bottom - (int)titleFont.GetHeight() - 2 - margin.Vertical - margin.Top);


            // draw the text within the bounds
            e.Graphics.DrawString(this._ConnectionStatus, titleFont, Brushes.Black, titleBounds, aligment);
            e.Graphics.DrawString(this._anti_Enabled, detailsFont, Brushes.DarkGray, detailBounds, aligment);
            e.Graphics.DrawString(this._anti_Name, NameFont, Brushes.DarkGray, NameBounds, aligment);

            // put some focus rectangle
            e.DrawFocusRectangle();

        }
    }

    public partial class exListBox: ListBox
    {
        private StringFormat _fmt;
        private Font _titleFont;
        private Font _detailsFont;
        private Font _NameFont;

        public exListBox(Font titleFont, Font detailsFont,Font NameFont,
                         StringAlignment aligment, StringAlignment lineAligment)
        {
            _titleFont = titleFont;
            _detailsFont = detailsFont;
            _NameFont = NameFont;
            //_imageSize = imageSize;
            //this.ItemHeight = _imageSize.Height + this.Margin.Vertical;
            _fmt = new StringFormat();
            _fmt.Alignment = aligment;
            _fmt.LineAlignment = lineAligment;
            _titleFont = titleFont;
            _detailsFont = detailsFont;
            _NameFont = NameFont;
        }

        public exListBox()
        {
            //InitializeComponent();
            //_imageSize = new Size(80, 60);
            //this.ItemHeight = _imageSize.Height + this.Margin.Vertical;
            _fmt = new StringFormat();
            _fmt.Alignment = StringAlignment.Near;
            _fmt.LineAlignment = StringAlignment.Near;
            _titleFont = new Font(this.Font, FontStyle.Bold);
            _detailsFont = new Font(this.Font, FontStyle.Regular);
            _NameFont = new Font(this.Font, FontStyle.Bold);

        }


        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            // prevent from error Visual Designer
            if (this.Items.Count > 0)
            {
                exListBoxItem item = (exListBoxItem)this.Items[e.Index];
                item.drawItem(e, this.Margin, _titleFont, _detailsFont, _NameFont, _fmt );
            }
        }


        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }

}
