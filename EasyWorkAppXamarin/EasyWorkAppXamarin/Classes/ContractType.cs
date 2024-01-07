using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyWorkAppXamarin.Classes
{
    public class ContractType
    {
        [PrimaryKey, AutoIncrement]
        public int ContractType_Id { get; set; }
        public string TypeName { get; set; }
    }
}
