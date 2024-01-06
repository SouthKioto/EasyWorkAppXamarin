using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyWorkAppXamarin.Classes
{
    public class Users
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public int TelNumber { get; set; }
        public byte[] ProfileImagePath { get; set; }
        public string ResidencePlace { get; set; }
        public string CurrPosition { get; set; }
        public string CurrPositionDescription { get; set; }
        public string CareerSummary { get; set; }
        public string WorkExperience { get; set; }
        public string Education { get; set; }
        public string LanguageSkills { get; set; }
        public string Skills { get; set; }
        public string Courses { get; set; }
        public string PasswordHash { get; set; }
        public bool IsAdmin { get; set; }
    }
}
