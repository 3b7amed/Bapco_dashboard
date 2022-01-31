using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Management;
using Google.Cloud.Firestore;
using System.Collections;

namespace lastone1
{
    public partial class Form2 : Form
    {
        System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
        DriveInfo[] allDrives = DriveInfo.GetDrives();
        FirestoreDb database;

        public Form2()
        {
            InitializeComponent();
            string path = AppDomain.CurrentDomain.BaseDirectory + @"backUp.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
            database = FirestoreDb.Create("backup-32978");

            t.Interval = 1500;
            t.Tick += new EventHandler(timer_Tick);
            t.Start();
            
            
        }

        void timer_Tick(object sender, EventArgs e)
        {
            //checkConnection();
            // getAntivirusName();
            antiVirus();
            checkDev();
            getConnection();

        }
        async void getConnection()
        {
            
            DocumentReference docref = database.Collection("pc"+0).Document("Drives");
            DocumentSnapshot snap = await docref.GetSnapshotAsync();
            if (snap.Exists)
            {
                Dictionary<string, object> connection = snap.ToDictionary();
                foreach (var item in connection)
                {
                    if (item.Value.ToString() == "connected")
                    {
                        label2.Text= "Connected!";
                        label2.ForeColor = System.Drawing.Color.Green;
                    }

                    else
                    {
                        label2.Text = "Not Connected";
                        label2.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }
        /*
        public void checkConnection()
        {
            bool con = NetworkInterface.GetIsNetworkAvailable();
            if (con == true)
            {

                label2.Text = "Connected!";
                label2.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                label2.Text = "Not Connected";
                label2.ForeColor = System.Drawing.Color.Red;
            }
        }
    */

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void circularProgressBar1_Click(object sender, EventArgs e)
        {

        }
        async void checkDev()
        {


            /* b.Location = new Point(394, 233);
            b.Text = "lala";
            b.Size=new Size(50, 50);
            b.Enabled = true;
            b.Visible = true;
            this.Controls.Add(b);
            */
            //from 5 to 6 french
            //label5.Text = "Drives Status ";
            //label5.Text += "\n---------------------------------";
            int bY_axis = 216;
            int bX_axis = 190;

            int lbY_axis = 427;
            int lbX_axis = 281;


            //List<CircularProgressBar.CircularProgressBar> cpb = new List<CircularProgressBar.CircularProgressBar>();

            /* DocumentReference docref = database.Collection("moham").Document("drives");
             DocumentSnapshot snap = await docref.GetSnapshotAsync();
             if (snap.Exists)
             {
                 Dictionary<string, object> connection = snap.ToDictionary();
                 foreach (var item in connection)
                 {
             */

            foreach (DriveInfo d in allDrives)
                    {
                        CircularProgressBar.CircularProgressBar b = new CircularProgressBar.CircularProgressBar();
                        Label lb = new Label();

                        b.Location = new Point(bX_axis, bY_axis);
                        b.Size = new Size(193, 168);
                        double usedd = (d.TotalSize / 1024d / 1024d / 1024d) - (d.TotalFreeSpace / 1024d / 1024d / 1024d);
                        double ised = usedd / (d.TotalSize / 1024d / 1024d / 1024d);
                        double fin_used = ised * 100;
                        if (fin_used >= 75.0)
                        {
                            b.ProgressColor = Color.Red;
                            lb.ForeColor = Color.Red;
                            b.ForeColor = Color.Red;
                        }
                        else
                        {
                            b.ProgressColor = Color.LimeGreen;
                            lb.ForeColor = Color.LimeGreen;
                            b.ForeColor = Color.LimeGreen;
                        }
                        b.ProgressWidth = 10;
                        b.OuterColor = Color.White;
                        b.InnerColor = Color.Black;

                        b.Text = d.Name;

                        b.SubscriptText = "";
                        b.SuperscriptText = "";
                        b.BackColor = Color.White;
                        b.Font = new Font(FontFamily.GenericSerif, 15, FontStyle.Bold);
                        b.Enabled = true;
                        b.Visible = true;
                        this.Controls.Add(b);

                        lb.Location = new Point(lbX_axis, lbY_axis);
                        lb.Text = d.Name;
                        lb.Size = new Size(122, 35);
                        this.Controls.Add(lb);
                        if (d.IsReady == true)
                        {/*
                            b.Maximum = bar_max;
                            b.Value = size_of_used;
                            b.Minimum = 0;
                            */
                            b.Maximum = Convert.ToInt32(d.TotalSize / 1024d / 1024d / 1024d);
                            b.Value = Convert.ToInt32((d.TotalSize - d.TotalFreeSpace) / 1024d / 1024d / 1024d);
                            b.Minimum = 0;
                        }
                        bX_axis += 277;
                        lbX_axis += 291;
                    
                
            }
        }

        public void antiVirus()
        {
            ManagementObjectSearcher wmiData = new ManagementObjectSearcher(@"root\SecurityCenter2", "SELECT * FROM AntiVirusProduct");
            ManagementObjectCollection data = wmiData.Get();

            foreach (ManagementObject virusChecker in data)
            {
               
                antiName.Text =virusChecker["displayName"].ToString();
                antiName.ForeColor = System.Drawing.Color.Green;
                /*ctrlLstBox.Items.Add(virusChecker["displayName"]);
                ctrlLstBox.Items.Add(virusChecker["instanceGuid"]);
                ctrlLstBox.Items.Add(virusChecker["pathToSignedProductExe"]);
                */
                
                //label5.Text+="\n"+(virusChecker["productState"]);
                
                //ctrlLstBox.Items.Add(virusChecker["SignatureStatus"]);
                //ctrlLstBox.Items.Add(virusChecker["productUptoDate"]);
                //ctrlLstBox.Items.Add(virusChecker["enableOnAccessUIMd5Hash"]);
                //ctrlLstBox.Items.Add(virusChecker["enableOnAccessUIParameters"]);
                //ctrlLstBox.Items.Add(virusChecker["productUptoDate"]);

                int vr = Convert.ToInt32(virusChecker["productState"]);
                string svr = vr.ToString("X");
                //ctrlLstBox.Items.Add(svr);
                //ctrlLstBox.Items.Add(svr[1]);
                if (svr[1] != '1')
                {
                    antiStatus.Text="enabled";
                    antiStatus.ForeColor = Color.Green;
                }
                else
                {
                    antiStatus.Text= "disabled";
                    antiStatus.ForeColor = Color.Red;
                }

                //ctrlLstBox.Items.Add(vrr);
               // ctrlLstBox.Items.Add(vr);
                //Decode(vr);
            }
            //ctrlLstBox.Items.Add("last");
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();
            this.Hide();
            
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
