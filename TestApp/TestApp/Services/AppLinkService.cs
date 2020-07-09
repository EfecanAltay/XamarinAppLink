using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TestApp.Services
{
    public class AppLinkService : IAppLinkService
    {
        public void RegisterAppLink(string guidID)
        {
            App.Current.AppLinks.RegisterLink(GetAppLink(guidID));
        }

        private AppLinkEntry GetAppLink(string guidId)
        {
            var pageType = GetType().ToString();
            var pageLink = new AppLinkEntry
            {
                Title = $"Item {guidId}",
                Description = $"this test app main page {guidId}",
                AppLinkUri = new Uri($"https://testapp-ba927.firebaseapp.com/link/{guidId}"),
                IsLinkActive = true
            };
            return pageLink;
        }
    }
}
