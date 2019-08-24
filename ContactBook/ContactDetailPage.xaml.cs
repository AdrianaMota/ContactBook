using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ContactBook
{
    public partial class ContactDetailPage : ContentPage
    {
        public ContactDetailPage(int contId)
        {
            InitializeComponent();
        }
        public async void OnButtonClicked(object sender, EventArgs args)
        {
            if (firstName.Text == null || lastName.Text == null)
            {
                var alert = await DisplayAlert("WAIT!", "Please enter the name or", "Ok", "Go back");
                if (alert == false)
                {
                    await Navigation.PopAsync();
                }
            }

        }
    }
}
