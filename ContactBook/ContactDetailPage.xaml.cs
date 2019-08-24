using System;
using System.Collections.Generic;
using System.Linq;
using ContactBook.Models;
using Xamarin.Forms;

namespace ContactBook
{
    public partial class ContactDetailPage : ContentPage
    {
        public ContactDetailPage(int contId)
        {
            BindingContext = GetContactsId(contId);
            InitializeComponent();

            
        }
        
        public ContactDetailPage()
        {
            GetContact();
        }

        public void ButtonClicked(object sender, EventArgs args)
        {
            if (firstName.Text == null && lastName.Text == null)
            {
                var alert = DisplayAlert("Error", "Please enter the name", "Ok");
                
            } else
            {
                int counter = 0;
                foreach (var contact in ContactList)
                {
                    counter = contact.ContactId;
                    counter++;
                }
                
                var newContact = new Contact { ContactId = counter, FirstName = firstName.Text, LastName = lastName.Text, Email = email.Text, Phone = phone.Text };
                ContactList.Add(newContact);
                
            }
        }

        private List<Contact> ContactList = new List<Contact>
        {
            new Contact {ContactId = 1, FirstName="Lisha", LastName="Mota", Email="lishamota@hotmail.com", Phone="8298793011"},
            new Contact {ContactId = 2, FirstName="José", LastName="Félix", Email="jfelix61@outlook.com", Phone="8295615690"}
        };

        public Contact GetContactsId(int contId)
        {
            
            return ContactList.SingleOrDefault(u => u.ContactId == contId);
        }
        public List<Contact> GetContact()
        {
            return ContactList;
        }
    }
}
