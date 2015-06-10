using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinTricountLike.Database;
using XamarinTricountLike.Models;

namespace XamarinTricountLike
{
    public partial class EventSettingsPage : ContentPage
    {
        public EventSettingsPage()
        {
            InitializeComponent();
        }

        public void OnSaveClicked(object sender, EventArgs e)
        {
            var item = BindingContext as Event;

            new EventRepository().SaveEvent(item);
            Device.BeginInvokeOnMainThread(() =>
            {
                if (App.Events.Contains(item))
                {
                    App.Events.Remove(item);
                }
                App.Events.Add(item);
            });
            Navigation.PopAsync();
        }
        
        public void OnCancelClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
