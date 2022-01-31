using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Google.Cloud.Firestore;

namespace lastone1
{
    public partial class Form6 : Form
    {
        FirestoreDb database;



        public Form6()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"holaafiretore.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
            database = FirestoreDb.Create("holaa-1b527");
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            
            getDrives();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        async void getDrives()
        {
            int total_pcs_number = 0;
            


            

            IAsyncEnumerable<CollectionReference> collections = database.ListRootCollectionsAsync();

            IAsyncEnumerator<CollectionReference> collectionsEnumerator = collections.GetAsyncEnumerator(default);

            while (await collectionsEnumerator.MoveNextAsync())
            {
                CollectionReference collectionRef = collectionsEnumerator.Current;
                total_pcs_number += 1;

            }


                int bY_axis = 110;
                int bX_axis = 312;

                int lbX_pc_name = 160;
                int lbY_pc_name = 140;

                int lbX_mac_name = 327;
                int lbY_mac_name = 140;

                int lbX_device_name = 357;
                int lbY_device_name = 240;



            total_pcs_number--;
                for (int i = 1; i <= total_pcs_number; i++)
                {
                    Label lb_pc = new Label();

                    lb_pc.Location = new Point(lbX_pc_name, lbY_pc_name);
                    lb_pc.Text = "pc" + i;
                    lb_pc.Size = new Size(122, 35);
                    lb_pc.Font = new Font("Niagara Solid", 20); ;
                    this.Controls.Add(lb_pc);




                    Query qref = database.Collection("pc" + i);
                    QuerySnapshot qsnap = await qref.GetSnapshotAsync();



                    foreach (DocumentSnapshot docsnap in qsnap)
                    {
                        if (docsnap.Exists)
                        {
                            

                            drives_class driv = docsnap.ConvertTo<drives_class>();
                            CircularProgressBar.CircularProgressBar b = new CircularProgressBar.CircularProgressBar();
                            Label lb_device = new Label();
                            b.Location = new Point(bX_axis, bY_axis);
                            b.Size = new Size(140, 120);

                            //double usedd = (d.TotalSize / 1024d / 1024d / 1024d) - (d.TotalFreeSpace / 1024d / 1024d / 1024d);
                            //double ised = usedd / (d.TotalSize / 1024d / 1024d / 1024d);
                            //double fin_used = ised * 100;
                            if (Convert.ToDouble(driv.used_drive) >= 75.0)
                            {
                                b.ProgressColor = Color.Red;
                                lb_device.ForeColor = Color.Red;
                                b.ForeColor = Color.Red;

                            }
                            else
                            {
                                b.ProgressColor = Color.LimeGreen;
                                lb_device.ForeColor = Color.LimeGreen;
                                b.ForeColor = Color.LimeGreen;
                            }
                            b.ProgressWidth = 10;
                            b.OuterColor = Color.WhiteSmoke;
                            b.InnerColor = Color.White;

                            b.Text = driv.used_drive + "%";
                            b.Font = new Font("Showcard Gothic", 3);
                            Console.WriteLine(driv.used_drive);



                            b.SubscriptText = "";
                            b.SuperscriptText = "";
                        b.BackColor = Color.WhiteSmoke;
                            b.Font = new Font(FontFamily.GenericSerif, 15, FontStyle.Bold);
                            b.Enabled = true;
                            b.Visible = true;

                            if (driv.name != null)
                            {
                                this.Controls.Add(b);
                            }

                            lb_device.Location = new Point(lbX_device_name, lbY_device_name);
                            lb_device.Text = driv.name;
                            lb_device.Size = new Size(122, 35);

                            this.Controls.Add(lb_device);
                            b.Maximum = (int)Convert.ToDouble(driv.bar_max);
                            b.Value = (int)Convert.ToDouble(driv.size_of_used);
                            b.Minimum = 0;

                            device_class dev = docsnap.ConvertTo<device_class>();
                            Label lb_mac = new Label();
                            lb_mac.Location = new Point(lbX_mac_name, lbY_mac_name);
                            lb_mac.Size = new Size(122, 35);
                            lb_mac.Text = dev.mac_address;
                            lb_mac.ForeColor = Color.Black;
                            lb_mac.Font= new Font("Niagara Solid", 20);
                            this.Controls.Add(lb_mac);


                            bX_axis += 227;
                            lbX_device_name += 227;

                        }

                    }


                    bX_axis = 312;
                    bY_axis += 180;

                    lbX_device_name = 357;
                    lbY_device_name += 180;

                    lbY_pc_name += 180;

                    lbY_mac_name += 180;
                }

           

        }



        private void X_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
