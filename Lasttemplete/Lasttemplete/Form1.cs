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
using Google.Cloud.Firestore;
using Lasttemplete;


using System.IO;
using System.Runtime;
using System.Net.NetworkInformation;
using System.Management;
using System.Collections;

namespace Lasttemplete
{
    public partial class Form1 : Form
    {
        public static int pc_number;
        FirestoreDb database;
        public string mac_address;

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
            string path = AppDomain.CurrentDomain.BaseDirectory + @"firebase.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
            database = FirestoreDb.Create("holaa-1b527");

            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            circularProgressBar1.Value = 0;
        
        }

        private void Form4_Load(object sender, EventArgs e)
        {
          
        }
        async void check1()
        {
           // string mac_address;
            ManagementObjectSearcher wmiData = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration where IPEnabled=true");
            ManagementObjectCollection data = wmiData.Get();
            foreach (ManagementObject checker in data)
            {
                mac_address = checker["MacAddress"].ToString();
            }
                DocumentReference docRef = database.Collection("pcs").Document(mac_address);
                DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
                if (snapshot.Exists)
                {
                    pcName pc_name_db = snapshot.ConvertTo<pcName>();
                    pc_number = pc_name_db.num;
                    Form2 frm = new Form2();
                    frm.Show();
                    this.Hide();
                }
                else
                {

                    DocumentReference all_pcs = database.Collection("pcs").Document("allPcs");
                    DocumentSnapshot all_pcs_1 = await all_pcs.GetSnapshotAsync();
                    if (all_pcs_1.Exists)
                    {
                        //label2.Text+="\n1)Document data for {0} document:"+all_pcs_1.Id;
                        pcName pcs_number = all_pcs_1.ConvertTo<pcName>();
                        //label2.Text += "\n 2)" + "all_pcs number is " + pcs_number.num;
                        all_pcs.UpdateAsync("num", FieldValue.Increment(1));

                        Dictionary<string, object> newPc = new Dictionary<string, object>
                        {{ "num",(pcs_number.num+1) }};
                        database.Collection("pcs").Document(mac_address).SetAsync(newPc);

                        pc_number = pcs_number.num + 1;

                        Form2 frm = new Form2();
                        frm.Show();
                        this.Hide();

                    }
                }


        }
        async void check()
        {
            string name;
            //int pc_number;
            string pc_name =System.Environment.MachineName;
            DocumentReference docRef = database.Collection("pcs").Document(pc_name);
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
            if (snapshot.Exists)
            {
                
                pcName pc_name_db = snapshot.ConvertTo<pcName>();
                pc_number = pc_name_db.num;
                Form2 frm = new Form2();
                frm.Show();
                this.Hide();
            }
            else
            {
                DocumentReference all_pcs = database.Collection("pcs").Document("allPcs");
                DocumentSnapshot all_pcs_1 = await all_pcs.GetSnapshotAsync();
                if (all_pcs_1.Exists)
                {
                    
                    //label2.Text+="\n1)Document data for {0} document:"+all_pcs_1.Id;
                    pcName pcs_number = all_pcs_1.ConvertTo<pcName>();

                        //label2.Text += "\n 2)" + "all_pcs number is " + pcs_number.num;
                        all_pcs.UpdateAsync("num", FieldValue.Increment(1));

                        Dictionary<string, object> newPc = new Dictionary<string, object>
                        {{ "num",(pcs_number.num+1) }};
                        database.Collection("pcs").Document(pc_name).SetAsync(newPc);

                        pc_number = pcs_number.num + 1;

                        Form2 frm = new Form2();
                        frm.Show();
                        this.Hide();
                    
                }
            }

        }
              


        

        private void timer1_Tick(object sender, EventArgs e)
        {
            circularProgressBar1.Value += 2;
            circularProgressBar1.Text = circularProgressBar1.Value.ToString() + "%";
            if (circularProgressBar1.Value == 100)
            {
                timer1.Enabled = false;
                check1();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
