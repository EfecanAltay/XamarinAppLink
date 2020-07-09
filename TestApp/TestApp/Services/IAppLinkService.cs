using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TestApp.Services
{
    public interface IAppLinkService
    {
        void RegisterAppLink(string guidID);
    }
}
