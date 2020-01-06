using System;
using ContactBook.Models;

namespace ContactBook.ViewModels
{
    public class ContactViewModel: BaseViewModel
    {
        public int ContactId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsBlocked { get; set; }

        public ContactViewModel() { }
        public ContactViewModel(Contact contact)
        {
            
            ContactId = contact.ContactId;
            _firstName = contact.FirstName;
            _lastName = contact.LastName;
            Phone = contact.Phone;
            Email = contact.Email;
            IsBlocked = contact.IsBlocked;
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                SetValue(ref _firstName, value);
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                SetValue(ref _lastName, value);
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Name
        {
            get { return $"{FirstName} {LastName}"; }
        }
    }
}
