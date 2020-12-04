using DynamicData;
using DynamicData.Binding;
using ReactiveUI;
using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Xamarin.Forms;
using XFIssues.XF13054.Models;

namespace XFIssues.XF13054.ViewModels
{
    public sealed class ItemsViewModel : IDisposable
    {
        public IObservableCollection<Item> Items { get; } = new ObservableCollectionExtended<Item>();

        public Command AddItemCommand { get; }
        public Command QuickAddItemCommand { get; }

        private readonly CompositeDisposable _disposables;

        public ItemsViewModel()
        {
            var itemsLoader = DataSource.Instance.Items
                .Connect()
                .AutoRefresh()
                .Do(_ => System.Diagnostics.Debug.WriteLine("***DATA_SOURCE_CHANGE***"))
                .ObserveOn(RxApp.MainThreadScheduler)
                .Bind(Items)
                .Subscribe();

            AddItemCommand = new Command(OnAddItem);

            _disposables = new CompositeDisposable(itemsLoader);
        }

        private void OnAddItem()
        {
            var newItem = new Item
            {
                Id = Guid.NewGuid(),
                Text = "Test"
            };

            DataSource.Instance.Items.Edit(updater =>
            {
                updater.AddOrUpdate(newItem);
            });
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}