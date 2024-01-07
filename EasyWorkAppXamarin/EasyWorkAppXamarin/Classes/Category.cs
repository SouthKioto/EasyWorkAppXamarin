using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyWorkAppXamarin.Classes
{
    public class Category
    {
        [PrimaryKey, AutoIncrement]
        public int Category_Id { get; set; }

        public string CategoryName { get; set; }
    }
}
