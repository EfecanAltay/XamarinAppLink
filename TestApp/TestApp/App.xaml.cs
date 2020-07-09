using Rg.Plugins.Popup.Services;
using System;
using TestApp.CustomViews;
using TestApp.Pages;
using TestApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestApp
{
    public partial class App : Application
    {
        public static string AppName = "TestAPP";
        public App()
        {
            InitializeComponent();
            DependencyService.Register<IAppLinkService, AppLinkService>();
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

        protected override async void OnAppLinkRequestReceived(Uri uri)
        {
            string appDomain = "https://testapp-ba927.firebaseapp.com/link/";
            if (!uri.ToString().ToLowerInvariant().StartsWith(appDomain, StringComparison.Ordinal))
                return;

            string pageUrl = uri.ToString().Replace(appDomain, string.Empty).Trim();
            var parts = pageUrl.Split('/');
            string pageTag = parts[0];
            Page form = null;
            bool isMessage = false;
            switch (pageTag)
            {
                case "main":
                    form = Activator.CreateInstance(typeof(MainPage)) as Page;
                    break;
                case "test1":
                    form = Activator.CreateInstance(typeof(TestPage1)) as Page;
                    break;
                case "test2":
                    form = Activator.CreateInstance(typeof(TestPage2)) as Page;
                    break;
                case "message":
                    isMessage = true;
                    string message = "Mesaj Boş";
                    if (string.IsNullOrWhiteSpace(parts[1]) == false)
                        message = parts[1].Replace("_", " ");
                    PopupNavigation.Instance.PushAsync(new CustomPopupView() { BindingContext = parts[1] });
                    break;
                default:
                    form = Activator.CreateInstance(typeof(MainPage)) as Page;
                    break;
            }
            if (isMessage == false)
                await MainPage.Navigation.PushAsync(form);
            base.OnAppLinkRequestReceived(uri);
        }
    }
}
