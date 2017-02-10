using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace FieldWorksApp
{
    public class App : Application
    {
        public static App Instance;
        public MediaController mediacontroller;

        public App()
        {
            Instance = this;
            // The root page of your application
            var content = new MainPage();
            MediaController.CreateInstance();
            mediacontroller = MediaController.instance;
            MainPage = new NavigationPage(content);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
