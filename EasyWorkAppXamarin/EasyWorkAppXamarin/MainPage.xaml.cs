using EasyWorkAppXamarin.Classes;
using EasyWorkAppXamarin.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EasyWorkAppXamarin
{
    public partial class MainPage : ContentPage
    {

        protected string imie { get; set; }
        protected string nazwisko { get; set; }
        protected string email { get; set; }
        protected bool isAdmin { get; set; }
        protected bool isLogged { get; set; }

        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            UpdateUserUI();
        }

        public void UpdateUserData(Users user, bool IsLogged)
        {
            this.imie = user.Name;
            this.nazwisko = user.Surname;
            this.email = user.Email;
            this.isAdmin = user.IsAdmin;
            this.isLogged = IsLogged;
        }

        public void UpdateUserUI()
        {
            if (isLogged) 
            {
                if (isAdmin)
                {
                    var adminButton = new Button
                    {
                        Text = "Profil",
                        BackgroundColor = Color.Transparent,
                        BorderColor = Color.Black,
                        BorderWidth = 1.5,
                        CornerRadius = 25,
                        TextColor = Color.Black,
                    };
                    UserData.Children.Add(adminButton);
                    UserGreetings.Text = "Good Morning " + imie;
                    adminButton.Clicked += GoToProfilePage;
                }
                else
                {
                    var userButton = new Button
                    {
                        Text = "Profil",
                        BackgroundColor = Color.Transparent,
                        BorderColor = Color.Black,
                        BorderWidth = 1.5,
                        CornerRadius = 25,
                        TextColor = Color.Black,
                    };
                    UserData.Children.Add(userButton);
                    UserGreetings.Text = "Good Morning " + imie;
                    userButton.Clicked += GoToProfilePage;
                }

            }
            else
            {
                var loginButton = new Button
                {
                    Text = "Zaloguj",
                    BackgroundColor = Color.Transparent,
                    BorderColor = Color.Black,
                    BorderWidth = 1.5,
                    CornerRadius = 25,
                    TextColor = Color.Black,
                };
                UserData.Children.Add(loginButton);
                loginButton.Clicked += GoToLoginPage;
            }
        }


        private void GoToLoginPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }

        private void GoToProfilePage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProfilePage());
        }
    }
}
