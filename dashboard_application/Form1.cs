using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace lastone1
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
            (
                int nLeftRect,
                int nTopRect,
                int rightRect,
                int nBottomRect,
                int nWidthElipse,
                int nHeightElipse
            );
        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            circularProgressBar1.Value = 0;
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
             Form2 frm2 = new Form2();
            Form3 frm3 = new Form3();
            frm2.Opacity = 10;
            frm3.Opacity = .05;
            frm2.Show();
            frm3.Show();
            */
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            circularProgressBar1.Value += 2;
            circularProgressBar1.Text = circularProgressBar1.Value.ToString() + "%";
            if (circularProgressBar1.Value == 100)
            {
                timer1.Enabled = false;
                Form5 form = new Form5();
                form.Show();
                this.Hide();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
