using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactBook.Models;
using Xamarin.Forms;

namespace ContactBook
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private ContactDetailPage _contactDetails = new ContactDetailPage();
        public MainPage()
        {
            InitializeComponent();
            listView.ItemsSource = _contactDetails.GetContact();
        }
        void OnAddContact(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ContactDetailPage(0));
        }
            private void ItemIsClicked(object s, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var contact = e.SelectedItem as Contact;

            listView.SelectedItem = null;

            Navigation.PushAsync(new ContactDetailPage(contact.ContactId));
        }
    }
}
