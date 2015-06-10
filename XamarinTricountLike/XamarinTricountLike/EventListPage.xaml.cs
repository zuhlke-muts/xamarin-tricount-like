using System;
using Xamarin.Forms;
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
            var eventSettingsPage = new EventSettingsPage {BindingContext = new Event() {Name = "Test"}};
            Navigation.PushAsync(eventSettingsPage);
        }

        public void OnTappedEvent(object sender, ItemTappedEventArgs e)
        {
            var eventSettingsPage = new EventSettingsPage { BindingContext = e.Item };
            Navigation.PushAsync(eventSettingsPage);
        }
    }
}