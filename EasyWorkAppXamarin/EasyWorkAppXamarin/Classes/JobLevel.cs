using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyWorkAppXamarin.Classes
{
    public class JobLevel
    {
        [PrimaryKey, AutoIncrement]
        public int JobLevel_Id { get; set; }
        public string LevelName { get; set; }
    }
}
