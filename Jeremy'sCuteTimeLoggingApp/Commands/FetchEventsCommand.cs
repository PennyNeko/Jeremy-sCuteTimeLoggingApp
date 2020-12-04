using Microsoft.Graph;
using Microsoft.Graph.Auth;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Jeremy_sCuteTimeLoggingApp
{
    public class FetchEventsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged { add { CommandManager.RequerySuggested += value; } remove { CommandManager.RequerySuggested -= value; } }

        WorkEntryDataContext _dataContext;

        public FetchEventsCommand(WorkEntryDataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            var app = App.PublicClientApp;

            InteractiveAuthenticationProvider authProvider = new InteractiveAuthenticationProvider(app, new string[] { "Calendars.Read" });

            GraphServiceClient graphClient = new GraphServiceClient(authProvider);

            EventFetcher eventFetcher = new EventFetcher(graphClient);
            IEnumerable<WorkEntry> events = new List<WorkEntry>();
            try
            {
                events = await eventFetcher.GetDaysEventsAsync(_dataContext.TodayDate);
            }
            catch { }

            _dataContext.WorkEntries = new ObservableCollection<WorkEntry>(_dataContext.WorkEntries.Where(x => x.Source != "Outlook"));

            foreach (var item in events)
            {
                _dataContext.WorkEntries.Add(item);
            }
        }
    }
}
