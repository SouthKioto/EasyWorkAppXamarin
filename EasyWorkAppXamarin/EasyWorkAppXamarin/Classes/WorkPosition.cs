using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyWorkAppXamarin.Classes
{
    public class WorkPosition
    {
        [PrimaryKey, AutoIncrement]
        public int WorkPosition_Id { get; set; }
        public string WorkPosition_Name { get; set; }
    }
}
