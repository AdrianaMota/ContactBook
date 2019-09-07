using System;
using System.Collections.Generic;
using System.Linq;
using ContactBook.Models;
using Xamarin.Forms;

namespace ContactBook
{
    public partial class ContactDetailPage : ContentPage
    {
        public event EventHandler<Contact> ContactAdded;
        public event EventHandler<Contact> ContactUpdated;

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

                    ContactAdded?.Invoke(this, contact);
             } else
                {
                    ContactUpdated?.Invoke(this, contact);
                }
             await Navigation.PopAsync();
        }
    }
}
