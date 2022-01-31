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
using System.Net.Http;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using System.Collections;

namespace lastone1
{
    public partial class Form4 : Form
    {
        System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
        DriveInfo[] allDrives = DriveInfo.GetDrives();
        FirestoreDb database;
        int i = 0;
        //int number_Devices = Form5.num_devices;


        public Form4()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"holaafirestore.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
            database = FirestoreDb.Create("holaa-1b527");

            InitializeComponent();

            t.Interval = 3000;
            t.Tick += new EventHandler(timer_Tick);
            t.Start();



        }
        void timer_Tick(object sender, EventArgs e)
        {
            getalll();   
        }

        async void getalll()
        {


            try
            {
                int total_pc_number = 0;

                int lb_pc_Yaxis = 150;
                int lb_pc_Xaxis = 105;

                int lb_connection_Yaxis = 150;
                int lb_connection_Xaxis = 502;

                int lb_Mac_Yaxis = 150;
                int lb_Mac_Xaxis = 277;

                int firestore_date;
                int now_date;

                IAsyncEnumerable<CollectionReference> collections = database.ListRootCollectionsAsync();

                IAsyncEnumerator<CollectionReference> collectionsEnumerator = collections.GetAsyncEnumerator(default);

                while (await collectionsEnumerator.MoveNextAsync())
                {
                    CollectionReference collectionRef = collectionsEnumerator.Current;
                    total_pc_number += 1;

                }
                total_pc_number--;
                for (int i = 1; i <= total_pc_number; i++)
                {

                    Query qref = database.Collection("pc" + i);
                    QuerySnapshot qsnap = await qref.GetSnapshotAsync();



                    foreach (DocumentSnapshot docsnap in qsnap)
                    {
                        if (docsnap.Exists)
                        {
                            device_class dev = docsnap.ConvertTo<device_class>();

                            Label lb_pc = new Label();
                            Label lb_mac = new Label();
                            Label lb_connection = new Label();

                            lb_mac.Location = new Point(lb_Mac_Xaxis, lb_Mac_Yaxis);
                            lb_pc.Location = new Point(lb_pc_Xaxis, lb_pc_Yaxis);
                            lb_connection.Location = new Point(lb_connection_Xaxis, lb_connection_Yaxis);
                            
                            lb_pc.Text = "Pc" + i;
                            lb_mac.Text = dev.mac_address;
                            //
                            if (dev.Time != null)
                            {
                                firestore_date = Convert.ToInt32(dev.Time);
                                now_date = Convert.ToInt32(DateTime.Now.ToString("HHmm"));
                                
                                if ((now_date - firestore_date) == 0)
                                {
                                    lb_connection.Text = "Connected ";
                                    lb_connection.ForeColor = Color.LimeGreen;

                                }
                                else
                                {
                                    lb_connection.Text ="Disconnected";
                                    lb_connection.ForeColor = Color.Red;
                                }
                            }

                            
                            lb_pc.Size = new Size(166, 35);
                            lb_mac.Size = new Size(166, 35);
                            lb_connection.Size = new Size(166, 35);

                            lb_mac.Font = new Font("Niagara Solid", 20);
                            lb_pc.Font = new Font("Niagara Solid", 20);
                            lb_connection.Font = new Font("Niagara Solid", 20);
                            
                            lb_pc.ForeColor = Color.Black;
                            lb_mac.ForeColor = Color.Black;

                            this.Controls.Add(lb_mac);
                            this.Controls.Add(lb_pc);
                            this.Controls.Add(lb_connection);
                        }

                    }

                    lb_connection_Yaxis += 100;

                    lb_pc_Yaxis += 100;

                    lb_Mac_Yaxis += 100;
                }
                lb_pc_Yaxis += 100;
            }

            catch
            {
                this.Close();

            }

        }

        private async void Form4_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

