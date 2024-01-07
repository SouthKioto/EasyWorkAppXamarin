using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyWorkAppXamarin.Classes
{
    public class EmploymentDimensions
    {
        [PrimaryKey, AutoIncrement]
        public int EmploymentDimensions_Id { get; set; }
        public string DimensionName { get; set; }
    }
}
