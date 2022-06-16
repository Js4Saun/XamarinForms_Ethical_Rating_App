using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prototype.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Prototype.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        
        private async void SignInProcedure(object sender, EventArgs e)
        {
           if (Entry_Email.Text != "" && Entry_Password.Text != "")
            {
                var userList = await App.DataService.GetAllAsync<User>();
                userList.ForEach(delegate (User i)
                {
                    if (i.Email == Entry_Email.Text && i.Password == Entry_Password.Text)
                    {
                        Navigation.PushAsync(new MainMenu());
                        DisplayAlert("Login", "login Sucess", "OK");
                    }
                    else
                    {
                    }
                });
            }
            else await DisplayAlert("Login", "Login Not Correct, empty username or password.", "OK");
            
        }
        //TODO: sendgrid
        async void RegNewUser(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage());
        }
    }
}