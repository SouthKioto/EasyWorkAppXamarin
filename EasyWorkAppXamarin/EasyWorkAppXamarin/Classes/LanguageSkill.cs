using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyWorkAppXamarin.Classes
{
    public class LanguageSkill
    {
        [PrimaryKey, AutoIncrement]
        public int Language_Id { get; set; }
        public string Language { get; set; }
        public string Level { get; set; }
    }
}
