using System;
using System.Collections.Generic;
using System.Text;
using Google.Cloud.Firestore;

namespace Lasttemplete
{
    [FirestoreData]
   public class Class1
    {
        [FirestoreProperty]
        public DateTime BackupLastDate { get; set; }

    }
}
