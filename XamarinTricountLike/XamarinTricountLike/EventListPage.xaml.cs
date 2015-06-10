using System;
using Xamarin.Forms;
using XamarinTricountLike.Database;
using XamarinTricountLike.Models;

namespace XamarinTricountLike
{
    public partial class EventListPage : ContentPage
    {
        public EventListPage()
        {
            InitializeComponent();
        }

        public void OnAddEvent(object sender, EventArgs e)
        {
            var eventSettingsPage = new EventSettingsPage {BindingContext = new Event()};
            Navigation.PushAsync(eventSettingsPage);
        }

        public void OnTappedEvent(object sender, ItemTappedEventArgs e)
        {
            var eventSettingsPage = new EventSettingsPage { BindingContext = e.Item };
            Navigation.PushAsync(eventSettingsPage);
        }

        public void OnDeleteClick(object sender, EventArgs e)
        {
            var item = (Event)((MenuItem)sender).CommandParameter;
            new EventRepository().DeleteItem(item.ID);
            Device.BeginInvokeOnMainThread(() => App.Events.Remove(item));
        }

    }
}