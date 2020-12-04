using Xamarin.Forms;
using XFIssues.XF13054.ViewModels;

namespace XFIssues.XF13054.Views
{
    public partial class ItemsPage : ContentPage, IXFIssueMarker
    {
        ItemsViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
        }
    }
}