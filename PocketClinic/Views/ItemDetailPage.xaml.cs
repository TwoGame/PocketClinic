using PocketClinic.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace PocketClinic.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}