using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Jeremy_sCuteTimeLoggingApp
{
    public class WorkEntry : INotifyPropertyChanged
    {

        private string _name;
        string _description;
        DateTime _startTimestamp;
        DateTime _endTimestamp;
        string _link;
        string _creator;
        string _source;

        public WorkEntry(string name, string description, DateTime startTimestamp, DateTime endTimestamp, string link, string creator, string source)
        {
            Name = name;
            Description = description;
            StartTimestamp = startTimestamp;
            EndTimestamp = endTimestamp;
            Link = link;
            Creator = creator;
            Source = source;
        }

        //subject
        public string Name
        { get { return _name; } set { _name = value; OnPropertyChanged(); } }
        //bodyPreview
        public string Description
        { get { return _description; } set { _description = value; OnPropertyChanged(); } }
        //start
        public DateTime StartTimestamp
        { get { return _startTimestamp; } set { _startTimestamp = value; OnPropertyChanged(); } }
        //end
        public DateTime EndTimestamp
        { get { return _endTimestamp; } set { _endTimestamp = value; OnPropertyChanged(); } }
        //webLink
        public string Link
        { get { return _link; } set { _link = value; OnPropertyChanged(); } }
        //organizer
        public string Creator
        { get { return _creator; } set { _creator = value; OnPropertyChanged(); } }
        public string Source
        { get { return _source; } set { _source = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
