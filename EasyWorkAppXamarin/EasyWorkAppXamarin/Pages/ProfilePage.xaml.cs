using EasyWorkAppXamarin.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EasyWorkAppXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            CheckAdminPermit(UserManager.CurrentUser);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            UpdateUserData();
        }

        public void UpdateUserData()
        {
            nameSurname_label.Text = UserManager.CurrentUser.Name + " " + UserManager.CurrentUser.Surname;
            age_label.Text = UserManager.CurrentUser.BirthDate.ToString("dd/MM/yyyy");
            email_label.Text = UserManager.CurrentUser.Email;
            tel_number_label.Text = UserManager.CurrentUser.TelNumber.ToString();
            residence_label.Text = UserManager.CurrentUser.ResidencePlace;
            currPosition_label.Text = UserManager.CurrentUser.CurrPosition;
            currPositionDescript_label.Text = UserManager.CurrentUser.CurrPositionDescription;
            careerSummary_label.Text = UserManager.CurrentUser.CareerSummary;
            workExperience_label.Text = UserManager.CurrentUser.WorkExperience;
            education_label.Text = UserManager.CurrentUser.Education;
            lauguageSkills_label.Text = UserManager.CurrentUser.LanguageSkills;
            skills_label.Text= UserManager.CurrentUser.Skills;
            courses_label.Text = UserManager.CurrentUser.Courses;
            isAdmin_label.Text = UserManager.CurrentUser.IsAdmin.ToString();
        }

        private void EditUserProfileButton(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditUserPage());
        }

        private void AddNewAdvertisment(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddAnnoucement());
        }

        private void LogOut(object sender, EventArgs e)
        {
            UserManager.Logout();
            Navigation.PushAsync(new MainPage());
        }

        private void BackToMainFromProfile(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void CheckAdminPermit(Users user)
        {
            if(user.IsAdmin == true)
            {
                var adminButton = new Button
                {
                    Text = "Admin Page",
                    BackgroundColor = Color.Transparent,
                    BorderColor = Color.Black,
                    BorderWidth = 1.5,
                    CornerRadius = 50,
                    FontAttributes = FontAttributes.Bold,
                    TextColor = Color.Black,
                    VerticalOptions = LayoutOptions.Center,
                };
                buttons_stacklayout.Children.Add(adminButton);
                adminButton.Clicked += GoToAdminPage;
            }
        }

        private void GoToAdminPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AdminPage());
        }
    }
}