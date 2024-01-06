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
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void RegisterUser(object sender, EventArgs e)
        {
            string name = name_Entry.Text;
            string surname = surname_Entry.Text;
            string email = email_Entry.Text;
            string password = password_Entry.Text;
            string repeatPassword = password_repeat_Entry.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname) ||
                string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(repeatPassword))
            {
                await DisplayAlert("Error", "Please fill in all the fields.", "OK");
                return;
            }

            if (password != repeatPassword)
            {
                await DisplayAlert("Error", "Passwords do not match.", "OK");
                return;
            }

            var existingUser = await App.Database.GetUserByEmailAsync(email);

            if (existingUser != null)
            {
                await DisplayAlert("Error", "Email is already registered. Please use a different email.", "OK");
                return;
            }

            var newUser = new Users
            {
                Name = name,
                Surname = surname,
                Email = email,
                PasswordHash = password
            };

            await App.Database.SavePersonAsync(newUser);

            await DisplayAlert("Success", "Registration successful. You can now log in.", "OK");
            await Navigation.PopAsync();
        }

        private void GoToLoginPage(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}