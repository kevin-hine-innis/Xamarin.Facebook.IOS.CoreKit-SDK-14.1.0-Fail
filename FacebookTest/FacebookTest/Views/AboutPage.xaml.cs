using FacebookTest.DependencyServices;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FacebookTest.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            DependencyService.Get<IPlatformKickFacebook>().KickIt();
        }
    }
}
