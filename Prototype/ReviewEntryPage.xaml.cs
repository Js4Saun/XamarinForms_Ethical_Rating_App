using Prototype.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prototype
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReviewEntryPage : ContentPage
    {
        public User User;
        public int productID;
        public ReviewEntryPage()
        {
            InitializeComponent();
        }
        private async void SaveReview(object sender, EventArgs e)
        {
            var user = (User)BindingContext;
            var review = new Review()
            {
                reviewDes = "asdf", itemID = productID, userID = User.Id
            };
                
            await App.DataService.InsertAsync(review);
            await DisplayAlert("Review", "Success", "Ok");
            await Navigation.PopAsync();
        }
    }
}