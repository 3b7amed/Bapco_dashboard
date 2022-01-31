using System;
using System.Collections.Generic;
using System.Text;
using Google.Cloud.Firestore;


namespace lastone1
{
    [FirestoreData]
    class add_second
    {
        [FirestoreProperty]
        public string connection_status { get; set; }
        [FirestoreProperty]
        public string anti_Enabled { get; set; }
        [FirestoreProperty]
        public string anti_Name { get; set; }
        /*[FirestoreProperty]
        public string available_space { get; set; }
        [FirestoreProperty]
        public string bar_max { get; set; }
        [FirestoreProperty]
        public string name { get; set; }
        [FirestoreProperty]
        public string size_of_used { get; set; }
        [FirestoreProperty]
        public string used_drive { get; set; }*/
    }
}
