using Jeremy_sCuteTimeLoggingApp.DataContexts;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Jeremy_sCuteTimeLoggingApp.Commands
{
    class FindAddIssueCommand : ICommand
    {
        public event EventHandler CanExecuteChanged { add { CommandManager.RequerySuggested += value; } remove { CommandManager.RequerySuggested -= value; } }

        MainWindowDataContext _dataContext;

        public FindAddIssueCommand(MainWindowDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool CanExecute(object parameter)
        {
            return false;
        }

        public void Execute(object parameter)
        {
            WorkEntry workEntry;
            
            //_dataContext.WorkEntries.Add(workEntry);
        }

        
    }
}
