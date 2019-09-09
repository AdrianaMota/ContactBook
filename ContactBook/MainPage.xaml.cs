using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using ContactBook.Models;
using ContactBook.Persistance;
using SQLite;
using Xamarin.Forms;

namespace ContactBook
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        private ObservableCollection<Contact> _ContactList;
        private SQLiteAsyncConnection _connection;
        private bool _isDataLoaded;


        public MainPage()
        {
        
        InitializeComponent();

        listView.ItemsSource = _ContactList;

         _connection = DependencyService.Get<ISQLiteDb>().GetConnection();

        }

        protected override async void OnAppearing()
        {
            if (_isDataLoaded)
                return;

            _isDataLoaded = true;

            await LoadData();

            base.OnAppearing();
        }

        private async Task LoadData()
        {
            await _connection.CreateTableAsync<Contact>();

            var contacts = await _connection.Table<Contact>().ToListAsync();
            _ContactList = new ObservableCollection<Contact>(contacts);

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
        async void OnDeleteContact(object sender, System.EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Contact;
            if (await DisplayAlert("WARNING!", $"You are about to delete {contact.Name} as a contact, do you wanna continue?", "Yes", "Nope"))
                _ContactList.Remove(contact);

            await _connection.DeleteAsync(contact);
        }


    }
}
