using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private ObservableCollection<Contact> _ContactList;


        public MainPage()
        {

        _ContactList = new ObservableCollection<Contact>
        {
            new Contact {ContactId = 1, FirstName="Lisha", LastName="Mota", Email="lishamota@hotmail.com", Phone="8298793011"},
            new Contact {ContactId = 2, FirstName="José", LastName="Félix", Email="jfelix61@outlook.com", Phone="8295615690"},
            new Contact {ContactId = 3, FirstName="José", LastName="Germán", Email="josegrdom123@gmail.com", Phone="8293498210"}
        };

        InitializeComponent();

        listView.ItemsSource = _ContactList;
        }

        async void OnAddContact(object sender, System.EventArgs e)
        {
            var page = new ContactDetailPage(new Contact());

            page.ContactAdded += (source, contact) =>
            {
                _ContactList.Add(contact);
            };
            await Navigation.PushAsync(page);
        }
        async void OnContactSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (listView.SelectedItem == null)
                return;
            var SelectedContact = e.SelectedItem as Contact;

            listView.SelectedItem = null;

            var page = new ContactDetailPage(SelectedContact);
            page.ContactUpdated += (source, contact) =>
            {
                SelectedContact.ContactId = contact.ContactId;
                SelectedContact.FirstName = contact.FirstName;
                SelectedContact.LastName = contact.LastName;
                SelectedContact.Email = contact.Email;
                SelectedContact.Phone = contact.Phone;
                SelectedContact.IsBlocked = contact.IsBlocked;


            };
            await Navigation.PushAsync(page);
        }
        
    }
}
