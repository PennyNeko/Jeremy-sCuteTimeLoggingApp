using Jeremy_sCuteTimeLoggingApp.DataContexts;
using Jeremy_sCuteTimeLoggingApp.UserControls;
using System.Windows;

namespace Jeremy_sCuteTimeLoggingApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = App.WorkEntryDataContext;
        }
    }
}