using Jeremy_sCuteTimeLoggingApp.Commands;
using Jeremy_sCuteTimeLoggingApp.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Jeremy_sCuteTimeLoggingApp.DataContexts
{
    public class WorkEntryDataContext : INotifyPropertyChanged
    {
        private WorkEntry workEntry;

        public WorkEntry WorkEntry
        {
            get { return workEntry; }
            set
            {
                workEntry = value;
                OnPropertyChanged();
            }
        }

        private ICommand copyToClipboardCommand;
        public ICommand CopyToClipboardCommand
        {
            get
            {
                if (copyToClipboardCommand == null)
                {
                    copyToClipboardCommand = new CopyToClipboardCommand(this);
                }
                return copyToClipboardCommand;
            }
            set { copyToClipboardCommand = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
