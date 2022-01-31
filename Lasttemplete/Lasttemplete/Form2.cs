using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Management;
using Google.Cloud.Firestore;
using System.Collections;


namespace Lasttemplete
{
    public partial class Form2 : Form
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


        System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
        DriveInfo[] allDrives = DriveInfo.GetDrives();
        FirestoreDb database;
        int i = Form1.pc_number;
        //int i = (int)Convert.ToInt32(Form2.num_device);

        DateTime dateTime = DateTime.UtcNow.Date;
        public Form2()
        {
         //   Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            InitializeComponent();
            string path = AppDomain.CurrentDomain.BaseDirectory + @"firebase.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
            database = FirestoreDb.Create("holaa-1b527");



            t.Interval = 5000;
            t.Tick += new EventHandler(timer_Tick);
            t.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {

            checkConnection();
            antiVirus();
            checkDevv();
            time();
            //anticheck();
            //BackUPdate();
            getMac();
        }
        async void checkDevv()
        {
            int m = 0;
            Dictionary<string, object> newList = new Dictionary<string, object>();

            foreach (DriveInfo d in allDrives)
            {
                DocumentReference DOC = database.Collection("pc" + i).Document("Drives" + m);

                Dictionary<string, object> drive = new Dictionary<string, object>();
                if (d.IsReady == true)
                {

                    double usedd = (d.TotalSize / 1024d / 1024d / 1024d) - (d.TotalFreeSpace / 1024d / 1024d / 1024d);
                    double ised = usedd / (d.TotalSize / 1024d / 1024d / 1024d);
                    double used_drive = ised * 100;

                    drive = new Dictionary<string, object>()
                    {
                       {"name",d.Name },
                       {"used_drive",used_drive.ToString("00.00")},
                       {"available_space",(d.TotalFreeSpace / 1024d / 1024d / 1024d).ToString("000.00")},
                       {"size_of_used",((d.TotalSize - d.TotalFreeSpace) / 1024d / 1024d / 1024d).ToString("000.00")},
                       {"bar_max",(d.TotalSize/ 1024d / 1024d / 1024d).ToString("000.00")}

                    };

                    DOC.SetAsync(drive, SetOptions.MergeAll);
                    m += 1;
                }
            }

        }


        public void checkConnection()
        {

            bool con = NetworkInterface.GetIsNetworkAvailable();
            DocumentReference DOC = database.Collection("pc" + i).Document("Device");
            Dictionary<string, object> data1 = new Dictionary<string, object>()
            {
                {"Connection_Status",con }
            };
            DOC.SetAsync(data1, SetOptions.MergeAll);

            if (con == true)
            {
                label1.Text = "Connected!";
                label1.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                label1.Text = "Not Connected";
                label1.ForeColor = System.Drawing.Color.Red;
            }
        }

        public void time()
        {
            var dt = DateTime.Now.ToString("HHmm");
            DocumentReference Doc = database.Collection("pc" + i).Document("Device");
            Dictionary<string, object> data1 = new Dictionary<string, object>()
            {
                {"Time",dt}
            };
            Doc.SetAsync(data1, SetOptions.MergeAll);

        }

        public void getMac()
        {
            string mac_address;
            DocumentReference Doc = database.Collection("pc" + i).Document("Device");
            ManagementObjectSearcher wmiData = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration where IPEnabled=true");
            ManagementObjectCollection data = wmiData.Get();
            foreach (ManagementObject checker in data)
            {
                mac_address = checker["MacAddress"].ToString();

                Dictionary<string, object> data1 = new Dictionary<string, object>()
                {
                {"mac_address",mac_address}
                };
                Doc.SetAsync(data1, SetOptions.MergeAll);
            }


        }

        public void antiVirus()
        {
            DocumentReference DOC = database.Collection("pc" + i).Document("Device");
            string antiVirus_Status;
            string antiVirus_name;
            ManagementObjectSearcher wmiData = new ManagementObjectSearcher(@"root\SecurityCenter2", "SELECT * FROM AntiVirusProduct");
            ManagementObjectCollection data = wmiData.Get();



            foreach (ManagementObject virusChecker in data)
            {

                if ((virusChecker["displayName"]).ToString() == "McAfee VirusScan")
                {


                    antiVirus_name = (virusChecker["displayName"]).ToString();
                    Dictionary<string, object> data1 = new Dictionary<string, object>()
                    {

                    {"anti_Name",virusChecker["displayName"].ToString() }

                    };
                    int vr = Convert.ToInt32(virusChecker["productState"]);
                    string svr = vr.ToString("X");

                    if (svr[1] == '1')
                    {
                        antiVirus_Status = "Enabled";
                        label6.Text = antiVirus_Status;
                        label6.ForeColor = Color.Green;
                    }
                    else
                    {
                        antiVirus_Status = "Disabled";
                        label6.Text = antiVirus_Status;
                        label6.ForeColor = Color.Red;
                    }

                    label5.Text = antiVirus_name;
                    label5.ForeColor = Color.Green;


                    data1.Add("anti_Enabled", antiVirus_Status);
                    DOC.SetAsync(data1, SetOptions.MergeAll);


                }
                else
                {
                    antiVirus_Status = "Disabled!";
                    label6.Text = antiVirus_Status;
                    label6.ForeColor = Color.Red;

                    label5.Text = "Not McaFee!";
                    label5.ForeColor = Color.Red;

                    Dictionary<string, object> data1 = new Dictionary<string, object>()
                        {
                        {"anti_Name","not McaFee" },
                        {"anti_Enabled","Disabled" }
                        };
                    DOC.SetAsync(data1, SetOptions.MergeAll);


                }


            }

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            button2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button2.Width, button2.Height, 5, 45));

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
