using System;
using System.Collections.Generic;
using System.Linq;
using ContactBook.Models;
using Xamarin.Forms;

namespace ContactBook
{
    public partial class ContactDetailPage : ContentPage
    {
        private MainPage ContactsPage = new MainPage();
        private Contact createdContact = new Contact();
        public ContactDetailPage(int contId)
        {
            BindingContext = GetContactsId(contId);

            InitializeComponent();

            if (contId == 0)
            {
                createdContact.ContactId = 0;
            }
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
                foreach (var item in ContactList)
                {
                    counter++;
                }

                if (createdContact.ContactId == 0)
                {
                    createdContact.ContactId = counter + 1;


                    ContactsPage.ContactListView.ItemsSource = AddContact(createdContact);

                    Navigation.PopAsync();
                }
                else
                {
                    UpdateContact();
                    Navigation.PopAsync();
                }



            }
        }
        public void UpdateContact()
        {
            var SelectedContat = ContactsPage.ContactListView.SelectedItem as Contact;

            SelectedContat.FirstName = firstName.Text;
            SelectedContat.LastName = lastName.Text;
            SelectedContat.Email = email.Text;
            SelectedContat.Phone = phone.Text;



        }

        public List<Contact> AddContact(Contact newContact)
        {

            newContact = new Contact { FirstName = firstName.Text, LastName = lastName.Text, Email = email.Text, Phone = phone.Text };
            ContactList.Add(newContact);
            return ContactList;
        }

        private List<Contact> ContactList = new List<Contact>
        {
            new Contact {ContactId = 1, FirstName="Lisha", LastName="Mota", Email="lishamota@hotmail.com", Phone="8298793011"},
            new Contact {ContactId = 2, FirstName="José", LastName="Félix", Email="jfelix61@outlook.com", Phone="8295615690"},
            new Contact {ContactId = 3, FirstName="José", LastName="Germán", Email="josegrdom123@gmail.com", Phone="8293498210"}
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
