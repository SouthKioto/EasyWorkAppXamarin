using EasyWorkAppXamarin.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EasyWorkAppXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditUserPage : ContentPage
    {
        public EditUserPage()
        {
            InitializeComponent();
            name_entry.Text = UserManager.CurrentUser.Name;
            surname_entry.Text = UserManager.CurrentUser.Surname;
            birth_date_entry.Date = UserManager.CurrentUser.BirthDate;
            email_entry.Text = UserManager.CurrentUser.Email;
            phone_number_entry.Text = UserManager.CurrentUser.TelNumber.ToString();
            residence_place_entry.Text = UserManager.CurrentUser.ResidencePlace;
            curr_position_entry.Text = UserManager.CurrentUser.CurrPosition;
            curr_position_descr_entry.Text = UserManager.CurrentUser.CurrPositionDescription;
            career_summary_entry.Text = UserManager.CurrentUser.CareerSummary;
            work_experience_entry.Text = UserManager.CurrentUser.WorkExperience;
            education_entry.Text = UserManager.CurrentUser.Education;
            launguage_skills_entry.Text = UserManager.CurrentUser.LanguageSkills;
            skills_entry.Text = UserManager.CurrentUser.Skills;
            courses_entry.Text = UserManager.CurrentUser.Courses;
            password_entry.Text = UserManager.CurrentUser.PasswordHash;
            IsAdmin_entry.Text = UserManager.CurrentUser.IsAdmin.ToString();
        }

        private void BackToPreviousPage(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void UpdateDataEditPageClick(object sender, EventArgs e)
        {
            string name = name_entry.Text;
            string surname = surname_entry.Text;
            string dateBirth = birth_date_entry.Date.ToString("yyyy-MM-dd");
            string email = email_entry.Text;
            string telNumber = phone_number_entry.Text;
            string residencePlace = residence_place_entry.Text;
            string currPosition = curr_position_entry.Text;
            string currPositionDescript = curr_position_descr_entry.Text;
            string careerSummary = career_summary_entry.Text;
            string workExperience = work_experience_entry.Text;
            string education = education_entry.Text;
            string laungageSkills = launguage_skills_entry.Text;
            string skills = skills_entry.Text;
            string courses = courses_entry.Text;
            string password = password_entry.Text;

            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(surname) || String.IsNullOrEmpty(email) || String.IsNullOrEmpty(password))
            {
                DisplayAlert("Info", "Proszę uzupełnić pola wymagane (imie, nazwisko, email lub haslo)", "OK");
            }
            else
            {
                if (Regex.IsMatch(telNumber, @"^[0-9]{9}$"))
                {
                    var updatedUser = new Users
                    {
                        ID = UserManager.CurrentUser.ID,
                        Name = name,
                        Surname = surname,
                        BirthDate = DateTime.ParseExact(dateBirth, "yyyy-MM-dd", null),
                        Email = email,
                        TelNumber = int.Parse(telNumber),
                        ResidencePlace = residencePlace,
                        CurrPosition = currPosition,
                        CurrPositionDescription = currPositionDescript,
                        CareerSummary = careerSummary,
                        WorkExperience = workExperience,
                        Education = education,
                        LanguageSkills = laungageSkills,
                        Skills = skills,
                        Courses = courses,
                        PasswordHash = password,
                        IsAdmin = bool.Parse(IsAdmin_entry.Text)
                    };

                    App.Database.UpdatePersonAsync(updatedUser);
                    DisplayAlert("Info", "Dane zostały poprawnie zaktualizowane", "OK");
                }
                else
                {
                    DisplayAlert("Info", "Proszę wpisać poprawny numer telefonu", "OK");
                }
            }

        }
    }
}