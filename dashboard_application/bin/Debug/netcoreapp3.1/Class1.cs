using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net;
using System.IO;
using Google.Cloud.Firestore;

namespace lastone1
{
    [FirestoreData]

    public class Class1
    {
        [FirestoreProperty]

        public DateTime BackupLastDate { get; set; }

    }




}
