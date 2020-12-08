using Jeremy_sCuteTimeLoggingApp.DataContexts;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Jeremy_sCuteTimeLoggingApp.Commands
{
    internal class FetchIssuesCommand : ICommand
    {
        public event EventHandler CanExecuteChanged { add { CommandManager.RequerySuggested += value; } remove { CommandManager.RequerySuggested -= value; } }

        MainWindowDataContext _dataContext;

        public FetchIssuesCommand(MainWindowDataContext workEntryDataContext)
        {
            _dataContext = workEntryDataContext;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            var issueFetcher = new IssueFetcher(App.JiraClient);
            var issues = await issueFetcher.GetRecentIssuesAsync();

            _dataContext.WorkEntries = new ObservableCollection<WorkEntry>(_dataContext.WorkEntries.Where(x => x.Source != "Jira"));
            foreach (var item in issues)
            {
                _dataContext.WorkEntries.Add(item);
            }
        }
    }
}