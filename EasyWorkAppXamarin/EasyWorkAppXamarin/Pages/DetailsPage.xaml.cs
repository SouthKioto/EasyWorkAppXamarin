using EasyWorkAppXamarin.Classes;
using EasyWorkAppXamarin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EasyWorkAppXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        public Annoucements annoucement { get; set; }
        public DetailsPage(Annoucements annoucement)
        {
            InitializeComponent();
            this.annoucement = annoucement;

            Title_label.Text = annoucement.Notification_title;
            Descript_label.Text = annoucement.Notification_descript;
            SalaryRange_label.Text = annoucement.Salary_range_start.ToString() + " - " + annoucement.Salary_range_end.ToString() + " zl";
            WorkingDays_label.Text = annoucement.Working_days.ToString();
            WorkingHours_label.Text = annoucement.Working_hours_start.ToString() + " - " + annoucement.Working_hours_end.ToString();
            DateOfExpiryEnd_label.Text = annoucement.Date_of_expiry_end.ToString();
            Category_label.Text = annoucement.Category.ToString();
            Responsibilities_label.Text = annoucement.Responsibilities.ToString();
            User_label.Text = annoucement.User_Id.ToString();


            WorkPosition_label.Text = App.Database.GetWorkTypeName(annoucement.WorkType);
            JobLevel_label.Text = App.Database.GetJobLevelName(annoucement.Job_level);
            ContractType_label.Text = App.Database.GetContractTypeName(annoucement.Contract_type);
            EmploymentDimen_label.Text = App.Database.GetEmploymentDimensionsName(annoucement.Employment_dimensions);
            WorkType_label.Text = App.Database.GetWorkTypeName(annoucement.WorkType);
        }
    }
}