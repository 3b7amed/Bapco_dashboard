using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Google.Cloud.Firestore;

namespace exListBox
{
    class exListBoxItem
    {
        public string connection_status { get; set; }
        public string anti_Enabled { get; set; }
        public string anti_Name { get; set; }
        public string available_space { get; set; }
        public string bar_max { get; set; }
        public string name { get; set; }
        public string size_of_used { get; set; }
        
        public string used_drive { get; set; }

        public exListBoxItem(string conn_stat, string anti_enabled, string anti_name, string avail_space,
                            string barMax, string namee, string size_usedd, string used_drivee)
        {
            connection_status = conn_stat;
            anti_Enabled = anti_enabled;
            anti_Name = anti_name;
            available_space = avail_space;
            bar_max = barMax;
            name = namee;
            size_of_used = size_usedd;
            used_drive = used_drivee;
        }
        
        public void drawItem(DrawItemEventArgs e, Padding margin,
                             Font titleFont, Font detailsFont, StringFormat aligment,
                             Size imageSize)
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

            CircularProgressBar.CircularProgressBar cpb= new CircularProgressBar.CircularProgressBar();
            if (Convert.ToDouble(this.used_drive) >= 75.0)
            {
                cpb.ProgressColor = Color.Red;
                cpb.ForeColor = Color.Red;
            }
            else
            {
                cpb.ProgressColor = Color.LimeGreen;
                cpb.ForeColor = Color.LimeGreen;
            }
            cpb.ProgressWidth = 10;
            cpb.OuterColor = Color.White;
            cpb.InnerColor = Color.Black;

            cpb.Text = this.used_drive + "%";

            cpb.SubscriptText = "";
            cpb.SuperscriptText = "";
            cpb.BackColor = Color.White;
            cpb.Font = new Font(FontFamily.GenericSerif, 15, FontStyle.Bold);
            cpb.Enabled = true;
            cpb.Visible = true;
            cpb.Maximum = (int)Convert.ToDouble(this.bar_max);
            cpb.Value = (int)Convert.ToDouble(this.size_of_used);
            cpb.Minimum = 0;
            cpb.Location = new Point(e.Bounds.X + margin.Left, e.Bounds.Y + margin.Top);
        


        // draw item image
        //e.Graphics.DrawImage(this.ItemImage, e.Bounds.X + margin.Left, e.Bounds.Y + margin.Top, imageSize.Width, imageSize.Height);

            // calculate bounds for title text drawing
            Rectangle titleBounds = new Rectangle(e.Bounds.X + margin.Horizontal + imageSize.Width,
                                                  e.Bounds.Y + margin.Top,
                                                  e.Bounds.Width - margin.Right - imageSize.Width - margin.Horizontal,
                                                  (int)titleFont.GetHeight() + 2);

            // calculate bounds for details text drawing
            Rectangle detailBounds = new Rectangle(e.Bounds.X + margin.Horizontal + imageSize.Width,
                                                   e.Bounds.Y + (int)titleFont.GetHeight() + 2 + margin.Vertical + margin.Top,
                                                   e.Bounds.Width - margin.Right - imageSize.Width - margin.Horizontal,
                                                   e.Bounds.Height - margin.Bottom - (int)titleFont.GetHeight() - 2 - margin.Vertical - margin.Top);
            // draw the text within the bounds
           e.Graphics.DrawString(this.connection_status, titleFont, Brushes.Black, titleBounds, aligment);
            e.Graphics.DrawString(this.anti_Name, detailsFont, Brushes.DarkGray, detailBounds, aligment);
            //e.Graphics.DrawString(this.anti_Enabled, detailsFont, Brushes.DarkGray, detailBounds, aligment);
            // put some focus rectangle
            e.DrawFocusRectangle();

        }

    }
    public partial class exListBoxx : ListBox
    {

        private Size _cpb;
        private StringFormat _fmt;
        private Font _titleFont;
        private Font _detailsFont;

        public exListBoxx(Font titleFont, Font detailsFont, Size cpb,
                         StringAlignment aligment, StringAlignment lineAligment)
        {
            _titleFont = titleFont;
            _detailsFont = detailsFont;
            _cpb = cpb;
            this.ItemHeight = cpb.Height + this.Margin.Vertical;
            _fmt = new StringFormat();
            _fmt.Alignment = aligment;
            _fmt.LineAlignment = lineAligment;
            _titleFont = titleFont;
            _detailsFont = detailsFont;
        }

        public exListBoxx()
        {
            //InitializeComponent();
            _cpb = new Size(80, 60);
            this.ItemHeight = _cpb.Height + this.Margin.Vertical;
            _fmt = new StringFormat();
            _fmt.Alignment = StringAlignment.Near;
            _fmt.LineAlignment = StringAlignment.Near;
            _titleFont = new Font(this.Font, FontStyle.Bold);
            _detailsFont = new Font(this.Font, FontStyle.Regular);

        }


        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            // prevent from error Visual Designer
            if (this.Items.Count > 0)
            {
                exListBoxItem item = (exListBoxItem)this.Items[e.Index];
                item.drawItem(e, this.Margin, _titleFont, _detailsFont, _fmt, this._cpb);
            }
        }


        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
