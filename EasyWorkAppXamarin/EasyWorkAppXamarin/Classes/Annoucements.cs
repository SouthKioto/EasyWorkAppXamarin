using SQLite;
using System;

namespace EasyWorkAppXamarin.Classes
{
    public class Annoucements
    {
        [PrimaryKey, AutoIncrement]
        public int NotificationId { get; set; }

        public string Notification_title { get; set; }
        public string Notification_descript { get; set; }

        [Indexed]
        public int Notification_work_position { get; set; }

        [Indexed]
        public int Job_level { get; set; }

        [Indexed]
        public int Contract_type { get; set; }

        [Indexed]
        public int Employment_dimensions { get; set; }

        [Indexed]
        public int WorkType { get; set; }

        public decimal Salary_range_start { get; set; }
        public decimal Salary_range_end { get; set; }
        public string Working_days { get; set; }
        public string Working_hours_start { get; set; }
        public string Working_hours_end { get; set; }
        public DateTime Date_of_expiry_start { get; set; }
        public DateTime Date_of_expiry_end { get; set; }

        [Indexed]
        public int Category { get; set; }

        public string Responsibilities { get; set; }
        public string Candidate_requirements { get; set; }
        public string Employer_offers { get; set; }
        public string About_the_company { get; set; }
        public int User_Id { get; set; }
    }
}
