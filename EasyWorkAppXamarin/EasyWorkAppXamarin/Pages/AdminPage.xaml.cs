using EasyWorkAppXamarin.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EasyWorkAppXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminPage : ContentPage
    {
        protected bool AdminPermit { get; set; }
        private ObservableCollection<Users> usersCollection;
        private ObservableCollection<Annoucements> annoucementsCollection;

        public AdminPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            usersCollection = new ObservableCollection<Users>(await App.Database.GetPeopleAsync());
            usersList_adminPage.ItemsSource = usersCollection;

            annoucementsCollection = new ObservableCollection<Annoucements>(await App.Database.GetAnnoucementsAsync());
            annoucementList_adminPage.ItemsSource = annoucementsCollection;
        }

        private async void ChangeAdminPermits(object sender, EventArgs e)
        {
            var button = (Button)sender;

            if (button != null)
            {
                var userData = button.BindingContext as Users;


                if (userData != null)
                {
                    userData.IsAdmin = !userData.IsAdmin;
                    await App.Database.UpdateAdminPermitAsync(userData);

                    var index = usersCollection.IndexOf(userData);
                    usersCollection[index] = userData;


                    await DisplayAlert("Info", "Uprawnienia administratorskie zostały zmienione", "OK");
                }

            }
        }

        private async void DeleteUserClick(object sender, EventArgs e)
        {
            var button = (Button)sender;

            if (button != null)
            {
                var userData = button.BindingContext as Users;

                if (userData != null)
                {
                    bool answer = await DisplayAlert("Confirmation", "Are you sure you want to delete this user?", "Yes", "No");

                    if (answer)
                    {
                        await App.Database.DeleteUserAsync(userData.ID);
                        usersCollection.Remove(userData);
                        await DisplayAlert("Info", "User deleted successfully", "OK");
                    }
                }
            }
        }

        private void DeleteAnnoucementFromDatabase(object sender, EventArgs e)
        {

        }
    }
}