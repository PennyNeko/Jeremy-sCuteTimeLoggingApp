using Jeremy_sCuteTimeLoggingApp.DataContexts;
using System;
using System.Windows;
using System.Windows.Input;

namespace Jeremy_sCuteTimeLoggingApp.Commands
{
    class CopyToClipboardCommand : ICommand
    {
        public event EventHandler CanExecuteChanged { add { CommandManager.RequerySuggested += value; } remove { CommandManager.RequerySuggested -= value; } }
        private MainWindowDataContext _dataContext;

        public CopyToClipboardCommand(MainWindowDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool CanExecute(object parameter)
        {
            return _dataContext.SelectedDataGridItem != null;
        }

        public void Execute(object parameter)
        {
            Clipboard.SetData(DataFormats.Text, _dataContext.SelectedDataGridItem.Link);
        }
    }
}
