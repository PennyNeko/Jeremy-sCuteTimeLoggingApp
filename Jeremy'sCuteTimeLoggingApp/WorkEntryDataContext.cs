using Atlassian.Jira;
using Microsoft.Graph;
using Microsoft.Graph.Auth;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Jeremy_sCuteTimeLoggingApp
{
    public class WorkEntryDataContext: INotifyPropertyChanged
    {
        string[] scopes = new string[] { "Calendars.Read" };

        private ObservableCollection<WorkEntry> events;
        private WorkEntry selectedDataGridItem;

        public WorkEntry SelectedDataGridItem
        {
            get { return selectedDataGridItem; }
            set { selectedDataGridItem = value;
                OnPropertyChanged();
            }
        } 

        public ObservableCollection<WorkEntry> Events
        {
            get
            {
                return events;
            }
            set
            {
                events = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public async void GetJiraEntries()
        {
            ICollection<WorkEntry> jiraEntries = new ObservableCollection<WorkEntry>();
            var jira = App.JiraClient;
            var recentIssues = await jira.Issues.GetIssuesFromJqlAsync(new IssueSearchOptions("issue in issueHistory()"));
            foreach(var i in recentIssues)
            {
                Events.Add(new WorkEntry(i.Summary, i.Description, i.Created, i.Created, jira.Url+"browse/"+i.Key, i.Reporter, "Jira"));
            }
            ;

        }

        public async void UpdateEventEntries()
        {
            var app = App.PublicClientApp;

            InteractiveAuthenticationProvider authProvider = new InteractiveAuthenticationProvider(app, scopes);

            GraphServiceClient graphClient = new GraphServiceClient(authProvider);

            EventFetcher eventFetcher = new EventFetcher(graphClient);

            Events = new ObservableCollection<WorkEntry>(await eventFetcher.GetEventsAsync());
            GetJiraEntries();
        }
    }
}
    