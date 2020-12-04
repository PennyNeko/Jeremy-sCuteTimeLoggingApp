using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Jeremy_sCuteTimeLoggingApp
{
    class CopyToClipboardCommand : ICommand
    {
        public event EventHandler CanExecuteChanged { add { CommandManager.RequerySuggested += value; } remove { CommandManager.RequerySuggested -= value; } }
        private WorkEntryDataContext _dataContext;

        public CopyToClipboardCommand(WorkEntryDataContext dataContext)
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
