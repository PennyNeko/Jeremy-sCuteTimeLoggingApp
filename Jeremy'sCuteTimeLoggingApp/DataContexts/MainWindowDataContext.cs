using Jeremy_sCuteTimeLoggingApp.Commands;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using System.Windows.Input;

namespace Jeremy_sCuteTimeLoggingApp.DataContexts
{
    public class MainWindowDataContext : INotifyPropertyChanged
        {
        string[] scopes = new string[] { "Calendars.Read" };

        private ICommand fetchEventsCommand;
        public ICommand FetchEventsCommand { get { if (fetchEventsCommand == null) { fetchEventsCommand = new FetchEventsCommand(this); } return fetchEventsCommand; } set { fetchEventsCommand = value; } }

        private ICommand fetchIssuesCommand;
        public ICommand FetchIssuesCommand { get { if (fetchIssuesCommand == null) { fetchIssuesCommand = new FetchIssuesCommand(this); } return fetchIssuesCommand; } set { fetchIssuesCommand = value; } }

        private ICommand saveEntriesCommand;
        public ICommand SaveEntriesCommand
        {
            get
            {
                if (saveEntriesCommand == null)
                {
                    saveEntriesCommand = new SaveEntriesCommand(this);
                }
                return saveEntriesCommand;
            }
            set { saveEntriesCommand = value; }
        }

        private ICommand findAddIssueCommand;
        public ICommand FindAddIssueCommand { get { if (findAddIssueCommand == null) { findAddIssueCommand = new FindAddIssueCommand(this); } return findAddIssueCommand; } set { findAddIssueCommand = value; } }


        private CollectionViewSource workEntriesViewSource = new CollectionViewSource();
        public CollectionViewSource WorkEntriesViewSource { get { return workEntriesViewSource; } set { workEntriesViewSource = value; } }

        
        private ObservableCollection<WorkEntry> workEntries = new ObservableCollection<WorkEntry>();
        private WorkEntry selectedDataGridItem;

        public WorkEntry SelectedDataGridItem
        {
            get { return selectedDataGridItem; }
            set
            {
                selectedDataGridItem = value;
                OnPropertyChanged();
            }
        }



        private DateTime todayDate = DateTime.Now.Date;
        public DateTime TodayDate { get { return todayDate; } set { todayDate = value; } }

        public ObservableCollection<WorkEntry> WorkEntries
        {
            get
            {
                return workEntries;
            }
            set
            {
                workEntries = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
    