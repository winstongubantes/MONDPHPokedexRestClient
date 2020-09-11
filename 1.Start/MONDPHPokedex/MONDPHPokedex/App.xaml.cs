using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MONDPHPokedex
{
    public partial class App : Application
    {
        public static Page Page { get; set; }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
            Page = MainPage;
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
