using System;
using System.Collections.Generic;
using System.Linq;
using ContactBook.Models;
using ContactBook.Persistance;
using SQLite;
using Xamarin.Forms;

namespace ContactBook
{
    public partial class ContactDetailPage : ContentPage
    {
        public event EventHandler<Contact> ContactAdded;
        public event EventHandler<Contact> ContactUpdated;

        private SQLiteAsyncConnection _connection;

        public ContactDetailPage(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));

            BindingContext = new Contact
            {
                ContactId = contact.ContactId,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email  = contact.Email,
                Phone = contact.Phone,
                IsBlocked = contact.IsBlocked
            };

            InitializeComponent();

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();

        }

        async void ButtonClicked(object sender, EventArgs args)
        {
            var contact = BindingContext as Contact;
            if (firstName.Text == null && lastName.Text == null)
            {
                 await DisplayAlert("Error", "Please enter the name", "Ok");

                return;

            }
            if (contact.ContactId == 0)
                {
                    contact.ContactId = 1;

                await _connection.InsertAsync(contact);

                    ContactAdded?.Invoke(this, contact);
             } else
                {
                await _connection.UpdateAsync(contact);
                    ContactUpdated?.Invoke(this, contact);
                }
             await Navigation.PopAsync();
        }
    }
}
