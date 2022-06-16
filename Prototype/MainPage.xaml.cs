using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prototype
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
        }
        private async void Go_LoginPage(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Views.LoginPage());
        }
    }
}
