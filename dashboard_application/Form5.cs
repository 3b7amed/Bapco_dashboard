using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Google.Cloud.Firestore;
using System.Runtime.InteropServices;

namespace lastone1
{
    public partial class Form5 : Form
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

        public Form5()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
         
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn5_Click(object sender, EventArgs e)
        {

        }

     

        private void btnPi_Click(object sender, EventArgs e)
        {
        
        }

        private void btnHdd_Click(object sender, EventArgs e)
        {
            openChildForm(new Form6());//hdd
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            openChildForm(new Form6());
            //hideSubMenu();

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("1");
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
        }

        private void btnPi_Click_1(object sender, EventArgs e)
        {
        }

        private void btnHdd_Click_1(object sender, EventArgs e)
        {
            openChildForm(new Form3());
            panelAnti.Visible = false;
            //   panelBack.Visible = true;
            panelDash.Visible = false;
            panelHdd.Visible = false;
            panelNet.Visible = false;
            panelReport.Visible = false;

            btnDashboard.BackColor = Color.FromArgb(192, 0, 0);
            //btnReport.BackColor = Color.FromArgb(192, 0, 0);
            btnAntivirus.BackColor = Color.FromArgb(192, 0, 0);
            button1.BackColor = Color.FromArgb(192, 0, 0);
            //  btnBackup.BackColor = Color.FromArgb(255, 0, 0);
            btnHdd.BackColor = Color.FromArgb(192, 0, 0);
            btnNetwork.BackColor = Color.FromArgb(192, 0, 0);
            pictureBox5.BackColor = Color.FromArgb(192, 0, 0);
            pictureBox1.BackColor = Color.FromArgb(192, 0, 0);
            //   pictureBox3.BackColor = Color.FromArgb(255, 0, 0);
            pictureBox4.BackColor = Color.FromArgb(192, 0, 0);
            pictureBox6.BackColor = Color.FromArgb(192, 0, 0);
            //pictureBox7.BackColor = Color.FromArgb(192, 0, 0);
        }

        private void panelChildForm_Paint(object sender, PaintEventArgs e)
        {
            openChildForm(new Form7());

        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            openChildForm(new Form8());//anti

            panelAnti.Visible = true;
        //    panelBack.Visible = false;
            panelDash.Visible = false;
            panelHdd.Visible = false;
            panelNet.Visible = false;
            panelReport.Visible = false;

            btnDashboard.BackColor = Color.FromArgb(192, 0, 0);
            //btnReport.BackColor = Color.FromArgb(192, 0, 0);
            btnAntivirus.BackColor = Color.FromArgb(255, 0, 0);
            button1.BackColor = Color.FromArgb(192, 0, 0);
         //   btnBackup.BackColor = Color.FromArgb(192, 0, 0);
            btnHdd.BackColor = Color.FromArgb(192, 0, 0);
            btnNetwork.BackColor = Color.FromArgb(192, 0, 0);
            pictureBox5.BackColor = Color.FromArgb(192, 0, 0);
            pictureBox1.BackColor = Color.FromArgb(255, 0, 0);
         //   pictureBox3.BackColor = Color.FromArgb(192, 0, 0);
            pictureBox4.BackColor = Color.FromArgb(192, 0, 0);
            pictureBox6.BackColor = Color.FromArgb(192, 0, 0);
            //pictureBox7.BackColor = Color.FromArgb(192, 0, 0);
        }

        public Form activeForm = null;
        public void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnNetwork_Click(object sender, EventArgs e)
        {
            openChildForm(new Form6());//hdd
            panelAnti.Visible = false;
            //  panelBack.Visible = false;
            panelDash.Visible = false;
            panelHdd.Visible = true;
            panelNet.Visible = false;
            panelReport.Visible = false;

            btnDashboard.BackColor = Color.FromArgb(192, 0, 0);
            //btnReport.BackColor = Color.FromArgb(192, 0, 0);
            btnAntivirus.BackColor = Color.FromArgb(192, 0, 0);
            button1.BackColor = Color.FromArgb(192, 0, 0);
            // btnBackup.BackColor = Color.FromArgb(192, 0, 0);
            btnHdd.BackColor = Color.FromArgb(255, 0, 0);
            btnNetwork.BackColor = Color.FromArgb(192, 0, 0);
            pictureBox5.BackColor = Color.FromArgb(192, 0, 0);
            pictureBox1.BackColor = Color.FromArgb(192, 0, 0);
            // pictureBox3.BackColor = Color.FromArgb(192, 0, 0);
            pictureBox4.BackColor = Color.FromArgb(255, 0, 0);
            pictureBox6.BackColor = Color.FromArgb(192, 0, 0);
            //pictureBox7.BackColor = Color.FromArgb(192, 0, 0);
        }
        private void btnAntivirus_Click(object sender, EventArgs e)
        {
            openChildForm(new Form7());
            panelAnti.Visible = false;
            //  panelBack.Visible = false;
            panelDash.Visible = true;
            panelHdd.Visible = false;
            panelNet.Visible = false;
            panelReport.Visible = false;

            btnDashboard.BackColor = Color.FromArgb(255, 0, 0);
            //btnReport.BackColor = Color.FromArgb(192, 0, 0);
            btnAntivirus.BackColor = Color.FromArgb(192, 0, 0);
            button1.BackColor = Color.FromArgb(192, 0, 0);
            //  btnBackup.BackColor = Color.FromArgb(192, 0, 0);
            btnHdd.BackColor = Color.FromArgb(192, 0, 0);
            btnNetwork.BackColor = Color.FromArgb(192, 0, 0);
            pictureBox5.BackColor = Color.FromArgb(255, 0, 0);
            pictureBox1.BackColor = Color.FromArgb(192, 0, 0);
            //  pictureBox3.BackColor = Color.FromArgb(192, 0, 0);
            pictureBox4.BackColor = Color.FromArgb(192, 0, 0);
            pictureBox6.BackColor = Color.FromArgb(192, 0, 0);
            //pictureBox7.BackColor = Color.FromArgb(192, 0, 0);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            
            openChildForm(new Form4());//network
            panelAnti.Visible = false;
            //     panelBack.Visible = false;
            panelDash.Visible = false;
            panelHdd.Visible = false;
            panelNet.Visible = true;
            panelReport.Visible = false;

            btnDashboard.BackColor = Color.FromArgb(192, 0, 0);
            //btnReport.BackColor = Color.FromArgb(192, 0, 0);
            btnAntivirus.BackColor = Color.FromArgb(192, 0, 0);
            button1.BackColor = Color.FromArgb(192, 0, 0);
            //  btnBackup.BackColor = Color.FromArgb(192, 0, 0);
            btnHdd.BackColor = Color.FromArgb(192, 0, 0);
            btnNetwork.BackColor = Color.FromArgb(255, 0, 0);
            pictureBox5.BackColor = Color.FromArgb(192, 0, 0);
            pictureBox1.BackColor = Color.FromArgb(192, 0, 0);
            //   pictureBox3.BackColor = Color.FromArgb(192, 0, 0);
            pictureBox4.BackColor = Color.FromArgb(192, 0, 0);
            pictureBox6.BackColor = Color.FromArgb(255, 0, 0);
            //pictureBox7.BackColor = Color.FromArgb(192, 0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openChildForm(new Form9());//report
            panelAnti.Visible = false;
            //   panelBack.Visible = false;
            panelDash.Visible = false;
            panelHdd.Visible = false;
            panelNet.Visible = false;
            panelReport.Visible = true;

            btnDashboard.BackColor = Color.FromArgb(192, 0, 0);
            //btnReport.BackColor = Color.FromArgb(255, 0, 0);
            btnAntivirus.BackColor = Color.FromArgb(192, 0, 0);
            button1.BackColor = Color.FromArgb(192, 0, 0);
            //    btnBackup.BackColor = Color.FromArgb(192, 0, 0);
            btnHdd.BackColor = Color.FromArgb(192, 0, 0);
            btnNetwork.BackColor = Color.FromArgb(192, 0, 0);
            pictureBox5.BackColor = Color.FromArgb(192, 0, 0);
            pictureBox1.BackColor = Color.FromArgb(192, 0, 0);
            //      pictureBox3.BackColor = Color.FromArgb(192, 0, 0);
            pictureBox4.BackColor = Color.FromArgb(192, 0, 0);
            pictureBox6.BackColor = Color.FromArgb(192, 0, 0);
            //pictureBox7.BackColor = Color.FromArgb(255, 0, 0);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
           
            WindowState = FormWindowState.Maximized;
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            Form9 frm = new Form9();
            frm.report_function();
        }
    }
}
