using System;
using Xamarin.Forms;
using System.IO;
using Xamarin.Forms.Xaml;
using Prototype.Models;


namespace Prototype
{
    public partial class App : Application
    {
        static DataService dataService;
        internal static object Database;

        public static DataService DataService
        {
            get
            {
                if (dataService is null)
                {
                    dataService =
                    new DataService("https://192.168.0.10:5001")
                    .AddEntityModelEndpoint<Item>("api/Items").AddEntityModelEndpoint<User>("api/Users").AddEntityModelEndpoint<ImageFile>("api/ImageFiles");
                }
                return dataService;
            }
        }

        public App()
        {
            InitializeComponent();
            Device.SetFlags(new[]
            {
                "Shapes_Experimental",
            });

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
