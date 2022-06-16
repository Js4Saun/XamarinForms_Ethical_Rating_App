using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prototype.Views;
using Prototype.Models;

namespace Prototype.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }
        private async void RegisterUser(object sender, System.EventArgs e)
        {
            if (Entry_Email.Text != "" && Entry_Password.Text != "" && Entry_Username.Text != "")
            {
                var userList = await App.DataService.GetAllAsync<User>();
                var existing = 0;
                userList.ForEach(delegate (User i)
                {
                    if (i.Email == Entry_Email.Text || i.Username == Entry_Username.Text) existing++;
                });

                if (existing >= 1) await DisplayAlert("Register", "Email/User already exists", "OK");

                else
                {
                    var user = new User(Entry_Username.Text, Entry_Password.Text, Entry_Email.Text);
                    await App.DataService.InsertAsync(user);
                    await DisplayAlert("Register", "Success", "Ok");
                    await Navigation.PopAsync();
                }
            }
            else await DisplayAlert("Register", "Missing Fields", "OK");
        }
    }
}