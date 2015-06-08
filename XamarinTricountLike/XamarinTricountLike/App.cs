using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using Xamarin.Forms;
using XamarinTricountLike.Database;
using XamarinTricountLike.Models;

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
            MainPage = new EventListPage();
        }

        private static SQLiteConnection _databaseConnection;

        public static SQLiteConnection DatabaseConnection
        {
            get
            {
                if (_databaseConnection == null)
                {
                    _databaseConnection = DependencyService.Get<ISQLite>().GetConnection();
                    _databaseConnection.CreateTable<Event>();
                }
                return _databaseConnection;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            DatabaseConnection.Insert(new Event
            {
               Name = "zühlke camp"
            });
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            
        }
    }

    public class EventItem
    {
        public string DisplayName { get; set; }
    }
}
