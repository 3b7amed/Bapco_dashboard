using System;
using System.Collections.Generic;
using System.Text;
using Google.Cloud.Firestore;

namespace lastone1
{
    [FirestoreData]
    public class device_class
    {
        [FirestoreProperty]
        public Boolean Connection_Status { get; set; }
        [FirestoreProperty]
        public string anti_Name { get; set; }
        [FirestoreProperty]
        public string anti_Enabled { get; set; }
        [FirestoreProperty]
        public string Time { get; set; }
        [FirestoreProperty]
        public string mac_address { get; set; }

    }
}
