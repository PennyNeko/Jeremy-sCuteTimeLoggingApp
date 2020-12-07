using Atlassian.Jira;
using Jeremy_sCuteTimeLoggingApp.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Jeremy_sCuteTimeLoggingApp.Commands
{
    public class SaveEntriesCommand : ICommand
    {
        public event EventHandler CanExecuteChanged { add { CommandManager.RequerySuggested += value; } remove { CommandManager.RequerySuggested -= value; } }

        MainWindowDataContext _dataContext;

        public SaveEntriesCommand(MainWindowDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool CanExecute(object parameter)
        {
            return _dataContext.WorkEntries.Any(x => x.IsSelected == true);
        }

        public void Execute(object parameter)
        {
            var selectedEntries = _dataContext.WorkEntries.Where(x => x.IsSelected == true);
            foreach (var item in selectedEntries)
            {
                AddWorkLog(item);
            }
            MessageBox.Show("Entries saved");
        }

        public async void AddWorkLog(WorkEntry workEntry)
        {
              await App.JiraClient.Issues.AddWorklogAsync(workEntry.Id, new Worklog(((int)(workEntry.EndTime-workEntry.StartTime).TotalMinutes).ToString()+"m", workEntry.StartTime));
        }
    }
}
