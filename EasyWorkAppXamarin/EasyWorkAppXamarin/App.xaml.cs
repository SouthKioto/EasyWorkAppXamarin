using EasyWorkAppXamarin.Classes;
using EasyWorkAppXamarin.Data;
using System;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EasyWorkAppXamarin
{
    public partial class App : Application
    {
        static Database database;

        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "EasyWorkDefault.db3"));
                    var existingUser = Database.GetUserByEmailAsync("admin@gmail.com");

                    if(existingUser == null)
                    {
                        var userAdmin = new Users
                        {
                            Name = "admin",
                            Surname = "admin",
                            Email = "admin@gmail.com",
                            PasswordHash = "admin",
                            IsAdmin = true,
                        };

                        Database.SavePersonAsync(userAdmin);
                    }

                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
