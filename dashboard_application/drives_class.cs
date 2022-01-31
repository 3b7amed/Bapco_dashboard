using System;
using System.Collections.Generic;
using System.Text;
using Google.Cloud.Firestore;

namespace lastone1
{
    [FirestoreData]
    public class drives_class
    {
        [FirestoreProperty]
        public string available_space { get; set; }
        [FirestoreProperty]
        public string name { get; set; }
        [FirestoreProperty]
        public string size_of_used { get; set; }
        [FirestoreProperty]
        public string used_drive { get; set; }
        [FirestoreProperty]
        public string bar_max { get; set; }


    }
}
