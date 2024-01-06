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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void LoginUser(object sender, EventArgs e)
        {
            try
            {
                string email = email_Entry.Text;
                string password = password_Entry.Text;

                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                {
                    await DisplayAlert("Error", "Please enter both email and password.", "OK");
                    return;
                }

                var user = await App.Database.GetUserByEmailAsync(email);

                if (user != null && user.PasswordHash == password)
                {
                    var mainPage = new MainPage();
                    UserManager.CurrentUser = user;
                    mainPage.UpdateUserData(user, true);
                    await Navigation.PushAsync(mainPage);
                }
                else
                {
                    await DisplayAlert("Error", "Invalid email or password.", "OK");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in LoginUser: {ex}");
                await DisplayAlert("Error", "An unexpected error occurred.", "OK");
            }
        }


        private void GoToRegisterPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}