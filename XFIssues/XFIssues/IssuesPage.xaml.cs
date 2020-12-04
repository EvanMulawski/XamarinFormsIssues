using DynamicData;
using DynamicData.Binding;
using ReactiveUI;
using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Xamarin.Forms;

namespace XFIssues
{
    public partial class IssuesPage : ContentPage
    {
        public IssuesPage()
        {
            InitializeComponent();

            BindingContext = new IssuesViewModel();
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var issue = e.Item as Issue;
            await Shell.Current.GoToAsync(issue.Name);
        }
    }

    internal sealed class IssuesViewModel : IDisposable
    {
        private readonly CompositeDisposable _disposables;

        public IssuesViewModel()
        {
            var itemsLoader = App.Current.Issues
                .Connect()
                .ObserveOn(RxApp.MainThreadScheduler)
                .Bind(Issues)
                .Subscribe();

            _disposables = new CompositeDisposable(itemsLoader);
        }

        public IObservableCollection<Issue> Issues { get; } = new ObservableCollectionExtended<Issue>();

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}