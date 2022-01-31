using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.IO;
using System.Runtime;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Linq;
using Google.Cloud.Firestore;
using System.Collections;
//3kx4d83

namespace lastone1
{
    public partial class Form3 : Form
    {
        System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
        //DriveInfo[] allDrives = DriveInfo.GetDrives();
        int i = 0;


        public Form3()
        {

            //getalll();
            InitializeComponent();

            //LastHere();
            //GetAccount();
            //checkDevv();
            //label2.Text += GetCPUId();

            /* t.Interval = 1500;
            t.Tick += new EventHandler(timer_Tick);
            t.Start();
        */
            }
        void timer_Tick(object sender, EventArgs e)
        {

          //  getalll();
            //checkDevv();
            //Connection();
            //AntiVirus();
        }
        /*
        async void get_drives()
        {
            int bY_axis = 216;
            int bX_axis = 190;

            int lbY_axis = 427;
            int lbX_axis = 281;

            DocumentReference docref = database.Collection("moham").Document("Drives0");
            DocumentSnapshot snap = await docref.GetSnapshotAsync();
            if (snap.Exists)
            {

                /*Dictionary<string, object> connection = snap.ToDictionary();
                foreach (var item in connection)
                {
                    label2.Text += "\navailable space "+item.Key + " + " + item.Value +"\n";
                    label2.Text += "\nname " + item.Key + " + " + item.Value + "\n";
                    label2.Text += "\nsize of used " + item.Key + " + " + item.Value + "\n";
                    label2.Text += "\nused drive " + item.Key + " + " + item.Value + "\n";
                }
                drives_class anti = snap.ConvertTo<drives_class>();
                /*
                label2.Text += "\n name " + anti.name;
                label2.Text += "\n available space " + Convert.ToDouble(anti.available_space);
                label2.Text += "\n size of used " + Convert.ToDouble(anti.size_of_used);
                label2.Text += "\n used drive " + Convert.ToDouble(anti.used_drive);
                label2.Text += "\n used drive " + Convert.ToDouble(anti.bar_max);
                foreach (DriveInfo d in allDrives)
                {
                

                CircularProgressBar.CircularProgressBar b = new CircularProgressBar.CircularProgressBar();
                Label lb = new Label();

                b.Location = new Point(bX_axis, bY_axis);
                b.Size = new Size(193, 168);
                //double usedd = (d.TotalSize / 1024d / 1024d / 1024d) - (d.TotalFreeSpace / 1024d / 1024d / 1024d);
                //double ised = usedd / (d.TotalSize / 1024d / 1024d / 1024d);
                //double fin_used = ised * 100;
                if (Convert.ToDouble(anti.used_drive) >= 75.0)
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

                b.Text = anti.used_drive;

                b.SubscriptText = "";
                b.SuperscriptText = "";
                b.BackColor = Color.White;
                b.Font = new Font(FontFamily.GenericSerif, 15, FontStyle.Bold);
                b.Enabled = true;
                b.Visible = true;
                this.Controls.Add(b);

                lb.Location = new Point(lbX_axis, lbY_axis);
                lb.Text = anti.name;
                lb.Size = new Size(122, 35);
                this.Controls.Add(lb);

                /*if (d.IsReady == true)
                {

                b.Maximum = (int)Convert.ToDouble(anti.bar_max);
                b.Value = (int)Convert.ToDouble(anti.size_of_used);
                b.Minimum = 0;

                /*
                    b.Maximum = Convert.ToInt32(d.TotalSize / 1024d / 1024d / 1024d);
                    b.Value = Convert.ToInt32((d.TotalSize - d.TotalFreeSpace) / 1024d / 1024d / 1024d);
                    b.Minimum = 0;
                }
                bX_axis += 277;
                lbX_axis += 291;
            }

        }
        /*
        label2.Text += "\n name " + anti.name;
        label2.Text += "\n available space " + anti.available_space;
        label2.Text += "\n size of used " + anti.size_of_used;
        label2.Text += "\n used drive " + anti.used_drive;
        
        async void getAll()
        {
            
            Query allCitiesQuery = database.Collection("moham");
            QuerySnapshot allCitiesQuerySnapshot = await allCitiesQuery.GetSnapshotAsync();
            foreach (DocumentSnapshot documentSnapshot in allCitiesQuerySnapshot.Documents)
            {
                label2.Text += ("\nDocument data for {0} document:", documentSnapshot.Id);
                Dictionary<string, object> city = documentSnapshot.ToDictionary();
                foreach (KeyValuePair<string, object> pair in city)
                {
                    label2.Text += ("\n{0}: {1}", pair.Key, pair.Value);
                }
                label2.Text += ("");
            }
        }
        */
        /*
         * new
         * async void getalll()
        {
            FirestoreDb database;
            string path = AppDomain.CurrentDomain.BaseDirectory + @"cloudfire.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
            database = FirestoreDb.Create("bapco1");

            try
            {
                int bY_axis = 150;
                int bX_axis = 115;

                int lb_conn_Yaxis = 62;
                int lb_conn_Xaxis = 16;

                int lb_connValue_Yaxis = 103;
                int lb_connValue_Xaxis = 16;

                int lb_antiName_Yaxis = 62;
                int lb_antiName_Xaxis = 254;

                int lb_antiNameValue_Yaxis = 103;
                int lb_antiNameValue_Xaxis = 254;

                int lb_antiStat_Yaxis = 62;
                int lb_antiStat_Xaxis = 504;

                int lb_antiStatValue_Yaxis = 103;
                int lb_antiStatValue_Xaxis = 504;

                int lb_drives_name_Yaxis = 193;

                int lb_drives_name_Xaxis = 16;

                int lbY_axis = 314;
                int lbX_axis = 170;



                for (int i = 0; i <= 2; i++)
                {

                    Query qref = database.Collection("pc" + i);
                    QuerySnapshot qsnap = await qref.GetSnapshotAsync();



                    foreach (DocumentSnapshot docsnap in qsnap)
                    {
                        if (docsnap.Exists)
                        {
                            device_class dev = docsnap.ConvertTo<device_class>();
                            drives_class driv = docsnap.ConvertTo<drives_class>();
                            CircularProgressBar.CircularProgressBar b = new CircularProgressBar.CircularProgressBar();
                            Label lb = new Label();
                            Label lb_conn_value = new Label();
                            Label lb_antiName_value = new Label();
                            Label lb_antiStat_value = new Label();

                            Label lb_drives_name = new Label();
                            Label lb_conn_name = new Label();
                            Label lb_antiName_name = new Label();
                            Label lb_antiStat_name = new Label();

                            lb_antiName_name.Location = new Point(lb_antiName_Xaxis, lb_antiName_Yaxis);
                            lb_antiName_value.Location = new Point(lb_antiNameValue_Xaxis, lb_antiNameValue_Yaxis);

                            lb_conn_name.Location = new Point(lb_conn_Xaxis, lb_conn_Yaxis);
                            lb_conn_value.Location = new Point(lb_connValue_Xaxis, lb_connValue_Yaxis);

                            lb_antiStat_name.Location = new Point(lb_antiStat_Xaxis, lb_antiStat_Yaxis);
                            lb_antiStat_value.Location = new Point(lb_antiStatValue_Xaxis, lb_antiStatValue_Yaxis);

                            lb_drives_name.Location = new Point(lb_drives_name_Xaxis, lb_drives_name_Yaxis);
                            //label3.Text += "\n-------------";
                            //label4.Text += "\n" + driv.name;
                            //label5.Text = dev.anti_Name;
                            lb_antiStat_value.Text = dev.anti_Enabled;
                            if (dev.anti_Enabled == "Enabled")
                            {
                                lb_antiStat_value.ForeColor = Color.Green;

                            }
                            else
                            {
                                lb_antiStat_value.ForeColor = Color.Red;

                            }
                            if (dev.Connection_Status == true)
                            {
                                lb_conn_value.Text = "Connected";
                                lb_conn_value.ForeColor = Color.Green;
                            }
                            else
                            {

                                lb_conn_value.Text = "Disconnected";
                                lb_conn_value.ForeColor = Color.Red;

                            }
                            lb_antiName_value.Text = dev.anti_Name;

                            b.Location = new Point(bX_axis, bY_axis);
                            b.Size = new Size(193, 168);

                            //double usedd = (d.TotalSize / 1024d / 1024d / 1024d) - (d.TotalFreeSpace / 1024d / 1024d / 1024d);
                            //double ised = usedd / (d.TotalSize / 1024d / 1024d / 1024d);
                            //double fin_used = ised * 100;
                            if (Convert.ToDouble(driv.used_drive) >= 75.0)
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

                            b.Text = driv.used_drive + "%";
                            Console.WriteLine(driv.used_drive);



                            b.SubscriptText = "";
                            b.SuperscriptText = "";
                            b.BackColor = Color.White;
                            b.Font = new Font(FontFamily.GenericSerif, 15, FontStyle.Bold);
                            b.Enabled = true;
                            b.Visible = true;

                            if (driv.name != null)
                            {
                                this.Controls.Add(b);
                            }

                            lb.Location = new Point(lbX_axis, lbY_axis);
                            lb.Text = driv.name;
                            lb.Size = new Size(122, 35);

                            lb_conn_name.Text = "Connection";
                            lb_antiName_name.Text = "AntiVirus Name";
                            lb_antiStat_name.Text = "AntiVirus Status";
                            lb_drives_name.Text = "Drives";

                            lb_drives_name.Size = new Size(122, 35);
                            lb_antiName_name.Size = new Size(122, 35);
                            lb_antiName_value.Size = new Size(131, 20);
                            lb_antiStat_name.Size = new Size(122, 35);
                            lb_antiStat_value.Size = new Size(131, 20);
                            lb_conn_value.Size = new Size(122, 35);
                            lb_conn_name.Size = new Size(131, 20);

                            this.Controls.Add(lb);
                            this.Controls.Add(lb_conn_name);
                            this.Controls.Add(lb_conn_value);
                            this.Controls.Add(lb_antiStat_name);
                            this.Controls.Add(lb_antiStat_value);
                            this.Controls.Add(lb_antiName_name);
                            this.Controls.Add(lb_antiName_value);
                            this.Controls.Add(lb_drives_name);

                            b.Maximum = (int)Convert.ToDouble(driv.bar_max);
                            b.Value = (int)Convert.ToDouble(driv.size_of_used);
                            b.Minimum = 0;

                            bX_axis += 277;
                            lbX_axis += 291;
                            b.Update();
                            lb.Update();
                        }

                    }


                    bX_axis = 115;
                    bY_axis += 306;

                    lbX_axis = 170;
                    lbY_axis += 313;

                    lb_conn_Yaxis += 300;

                    lb_connValue_Yaxis += 300;

                    lb_drives_name_Yaxis += 300;

                    lb_antiName_Yaxis += 300;

                    lb_antiNameValue_Yaxis += 300;

                    lb_antiStat_Yaxis += 300;

                    lb_antiStatValue_Yaxis += 300;
                }
            }

            catch
            {
                this.Close();
                MessageBox.Show("err");
                Form2 frm = new Form2();
                frm.Show();
                this.Hide();
            }
        
        }
        */
        private void Form3_Load(object sender, EventArgs e)
        {
            //getalll();
        }
        private void button2_Click(object sender, EventArgs e)
        {
          /*  Form2 forma = new Form2();
            forma.Show();
            this.Hide();
        */
        }
        /*
        async void checkDevv()
        {
            int i_cons = 0;
            string used_driven;

            foreach (DriveInfo d in allDrives)
            {
                DocumentReference DOC = database.Collection("pc"+i).Document("Drives" + i_cons);
               
                Dictionary<string, object> drive=new Dictionary<string, object>();
           //     label5.Text += "\n  Drive type: " + d.DriveType;
                if (d.IsReady == true)
                {
                    
                    double usedd = (d.TotalSize / 1024d / 1024d / 1024d) - (d.TotalFreeSpace / 1024d / 1024d / 1024d);
                    double ised = usedd / (d.TotalSize / 1024d / 1024d / 1024d);
                    double used_drive = ised * 100;
                    used_driven= used_drive.ToString().Substring(0,5);

                    drive = new Dictionary<string, object>()
                    {
                       {"name",d.Name },
                       {"used_drive",used_drive.ToString("00.00") },
                       {"available_space",(d.TotalFreeSpace / 1024d / 1024d / 1024d).ToString("00.00")},
                       {"size_of_used",((d.TotalSize - d.TotalFreeSpace) / 1024d / 1024d / 1024d).ToString("00.00")},
                       {"bar_max", (d.TotalSize / 1024d / 1024d / 1024d).ToString("00.00")}
                    };
                        i_cons += 1;
                    await DOC.SetAsync(drive, SetOptions.MergeAll);
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
         
        }

      
       
        public void Connection()
        {
            string conn;
            bool con = NetworkInterface.GetIsNetworkAvailable();
            if (con == true)
            {
                conn = "Connected";
            }
            else
            {
                conn = "Disconnected";
            }
            DocumentReference DOC = database.Collection("pc"+i).Document("Device");

            Dictionary<string, object> data1 = new Dictionary<string, object>()
            {
                {"Connection_Status" ,conn}
            };
            DOC.SetAsync(data1, SetOptions.MergeAll);
        }


        
        public void AntiVirus()
        {
            DocumentReference DOC = database.Collection("pc"+i).Document("Device");
            string antiVirus_Status;
            ManagementObjectSearcher wmiData = new ManagementObjectSearcher(@"root\SecurityCenter2", "SELECT * FROM AntiVirusProduct");
            ManagementObjectCollection data = wmiData.Get();



                foreach (ManagementObject virusChecker in data)
                {
                /*label3.Text+=(virusChecker["displayName"]);
                label3.Text += (virusChecker["instanceGuid"]);
                label3.Text += (virusChecker["pathToSignedProductExe"]);
                label3.Text += (virusChecker["productState"]);
                
                Dictionary<string, object> data1 = new Dictionary<string, object>()
                {
                  {"anti_Name",virusChecker["displayName"].ToString() },

                };
                int vr =Convert.ToInt32(virusChecker["productState"]);
                string svr = vr.ToString("X");
                if (svr[1] == '1')
                {
                 antiVirus_Status = "Enable";
                }
                else
                {
                  antiVirus_Status = "Disable";
                }

                data1.Add("anti_Enabled", antiVirus_Status);
                DOC.SetAsync(data1, SetOptions.MergeAll);

                }

                }
        */
        private void circularProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           /* Form4 frm1 = new Form4();
            frm1.Show();
            this.Hide();
            */
            }

        private void Form3_Load_1(object sender, EventArgs e)
        {

        }
    }
}
