using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestPage1 : ContentPage
    {
        IAppLinkService _appLinkService;
        public TestPage1()
        {
            InitializeComponent();
            _appLinkService = DependencyService.Get<IAppLinkService>();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _appLinkService.RegisterAppLink("Test1");
        }
    }
}