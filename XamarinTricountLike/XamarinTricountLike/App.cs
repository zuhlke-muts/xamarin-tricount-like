using System.Diagnostics;
using System.Linq;
using SQLite;
using Xamarin.Forms;
using XamarinTricountLike.Database;
using XamarinTricountLike.Models;

namespace XamarinTricountLike
{
    public class App : Application
    {
        static SQLiteConnection _databaseConnection;

        public App()
        {
            // The root page of your application
            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
						new Label {
							XAlign = TextAlignment.Center,
							Text = "Welcome to Xamarin Forms!"
						}
					}
                }
            };
        }

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
}
