using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyWorkAppXamarin.Classes
{
    public class WorkType
    {
        [PrimaryKey, AutoIncrement]
        public int WorkType_Id { get; set; }
        public string TypeName { get; set; }

    }
}
