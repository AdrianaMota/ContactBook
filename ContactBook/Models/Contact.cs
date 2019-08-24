using System;

using Xamarin.Forms;

namespace ContactBook.Models
{
    public class Contact : ContentPage
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string Name { get {
                return String.Format("{0} {1}", FirstName, LastName);
            } }


    }
}

