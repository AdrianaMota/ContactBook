using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SQLite;
using Xamarin.Forms;

namespace ContactBook.Models
{
    public class Contact : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey, AutoIncrement]
        public int ContactId { get; set; }

        public string _firstName;

        [MaxLength(255)]
        public string FirstName {
            get { return _firstName; }
            set {
                if (_firstName == value)
                    return;

                _firstName = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Name));
            }

        }

        public string _lastName;

        [MaxLength(255)]
        public string LastName {
            get { return _lastName; }
            set
            {
                if (_lastName == value)
                    return;


                _lastName = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(Name));
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        [MaxLength(255)]
        public string Phone { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }

        public bool IsBlocked { get; set; }

        public string Name { get {
                return String.Format("{0} {1}", FirstName, LastName);
            }
        }
    }
}

