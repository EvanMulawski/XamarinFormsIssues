using DynamicData;
using System;
using System.Linq;
using Xamarin.Forms;

namespace XFIssues
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Issues = new SourceCache<Issue, string>(x => x.Name);
            var markers = typeof(App).Assembly.GetTypes().Where(t => typeof(IXFIssueMarker).IsAssignableFrom(t) && !t.IsInterface).ToList();
            Issues.AddOrUpdate(markers.Select(t => new Issue(t.Namespace.Split('.').Skip(1).First(), t)).OrderBy(x => x.Name).ToList());

            MainPage = new AppShell(Issues.Items);
        }

        public static new App Current => (App)Application.Current;

        public SourceCache<Issue, string> Issues { get; }
    }

    public class Issue
    {
        public Issue(string name, Type page)
        {
            Name = name;
            Page = page;
        }

        public string Name { get; }
        public Type Page { get; }
    }
}
