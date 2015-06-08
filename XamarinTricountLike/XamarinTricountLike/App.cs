using System.Collections.Generic;
using Xamarin.Forms;

namespace XamarinTricountLike
{
    public class App : Application
    {
        public static readonly List<EventItem> EventItems = new List<EventItem>()
        {
            new EventItem() { DisplayName = "Christians Event" },
            new EventItem() { DisplayName = "Riinas Event" },
            new EventItem() { DisplayName = "Roman Event"}
        }; 

        public App()
        {
            // The root page of your application
            MainPage = new NavigationPage(new EventListPage());
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

    public class EventItem
    {
        public string DisplayName { get; set; }
    }
}
