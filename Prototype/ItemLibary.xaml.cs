using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prototype.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Windows.Input;

namespace Prototype
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemLibary : ContentPage
    {
        public ICommand RefreshCommand => new Command(async () =>
        {
            IsRefreshing = true;
            await RefreshItemList();
            IsRefreshing = false;
        });

        private bool _IsRefreshing = false;
        public bool IsRefreshing
        {
            get => _IsRefreshing;
            set => Setter(value, ref _IsRefreshing, nameof(IsRefreshing));
        }

        public void Setter<T>(T value, ref T oldValue, string name)
        {
            if (!value.Equals(oldValue))
            {
                oldValue = value;
                OnPropertyChanged(name);
            }
        }


        public ItemLibary()
        {
            InitializeComponent();
            BindingContext = this;
        }
        private async Task RefreshItemList() => listView.ItemsSource = await App.DataService.GetAllAsync<Item>();

        protected override void OnAppearing()
        {
            base.OnAppearing();
            listView.BeginRefresh();
        }
        async void OnItemAddClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ItemEntryPage
            {
                BindingContext = new Item()
            });
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ItemEntryPage
                {
                    BindingContext = e.SelectedItem as Item
                });
            }
        }


    }
}