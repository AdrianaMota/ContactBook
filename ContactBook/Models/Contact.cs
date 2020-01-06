using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ContactBook.ViewModels;
using SQLite;
using Xamarin.Forms;

namespace ContactBook.Models
{
    public class Contact : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey, AutoIncrement]
        public int ContactId { get; set; }

        [MaxLength(255)]
        public string FirstName {get; set;}

        [MaxLength(255)]
        public string LastName { get; set; }

        [MaxLength(255)]
        public string Phone { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }

        public bool IsBlocked { get; set; }

       
    }
}

