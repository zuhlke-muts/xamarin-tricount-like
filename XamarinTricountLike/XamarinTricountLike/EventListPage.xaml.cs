using System;
using Xamarin.Forms;

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
            var eventSettingsPage = new EventSettingsPage {BindingContext = new EventItem() {DisplayName = "Test"}};
            Navigation.PushAsync(eventSettingsPage);
        }

        public void OnEditEvent(object sender, SelectedItemChangedEventArgs e)
        {
            var eventSettingsPage = new EventSettingsPage { BindingContext = e.SelectedItem };
            Navigation.PushAsync(eventSettingsPage);
        }
    }
}