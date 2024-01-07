using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyWorkAppXamarin.Classes
{
    public class LikeAnnoucements
    {
        [PrimaryKey, AutoIncrement]
        public int UserId { get; set; }
        public int NotificationOfWorkId { get; set; }
        public string NotificationTitle { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
