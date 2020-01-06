using ContactBook.ViewModels;
using Xamarin.Forms;

namespace ContactBook
{
    public partial class ContactDetailPage : ContentPage
    {
        public ContactDetailPage(ContactDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }
    }
}