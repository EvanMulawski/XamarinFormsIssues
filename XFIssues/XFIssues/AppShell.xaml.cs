using System.Collections.Generic;
using Xamarin.Forms;

namespace XFIssues
{
    public partial class AppShell : Shell
    {
        public AppShell(IEnumerable<Issue> issues)
        {
            InitializeComponent();

            foreach (var issue in issues)
            {
                Routing.RegisterRoute(issue.Name, issue.Page);
            }
        }
    }
}
