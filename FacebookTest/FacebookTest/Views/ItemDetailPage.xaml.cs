using System.ComponentModel;
using Xamarin.Forms;
using FacebookTest.ViewModels;

namespace FacebookTest.Views
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
