using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using SQLite;
using Xamarin.Forms;
using XamarinTricountLike.Database;
using XamarinTricountLike.Models;

namespace XamarinTricountLike
{
    public class App : Application
    {
        public static readonly ObservableCollection<Event> Events = new ObservableCollection<Event>();

        public App()
        {
            // The root page of your application
            MainPage = new NavigationPage(new EventListPage());
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
                Name = "Adrien Event"
            });

            var events = new EventRepository().GetAllEvents();
            Device.BeginInvokeOnMainThread(() =>
            {
                foreach (var item in events)
                {
                    Events.Add(item);
                }
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
}
