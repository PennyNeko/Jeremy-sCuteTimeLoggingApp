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
    public class EventDataContext: INotifyPropertyChanged
    {
        string[] scopes = new string[] { "Calendars.Read" };

        private ObservableCollection<WorkEntry> events;

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


        public async void UpdateWorkEntries()
        {
            var app = App.PublicClientApp;

            InteractiveAuthenticationProvider authProvider = new InteractiveAuthenticationProvider(app, scopes);

            GraphServiceClient graphClient = new GraphServiceClient(authProvider);

            EventFetcher eventFetcher = new EventFetcher(graphClient);

            Events = new ObservableCollection<WorkEntry>(await eventFetcher.GetEventsAsync());
        }
    }
}
