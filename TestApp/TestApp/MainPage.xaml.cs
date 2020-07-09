using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Pages;
using TestApp.Services;
using Xamarin.Forms;

namespace TestApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        IAppLinkService _appLinkService;

        public MainPage()
        {
            InitializeComponent();
            _appLinkService = DependencyService.Get<IAppLinkService>();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _appLinkService.RegisterAppLink("main");
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TestPage1());
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TestPage2());
        }
    }
}
