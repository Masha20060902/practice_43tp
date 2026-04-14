using System.Collections.ObjectModel;
using System.Windows;
namespace Task
{
    public partial class HistoryWindow : Window
    {
        public HistoryWindow(ObservableCollection<VersionEntity> versions)
        {
            InitializeComponent();
            HistoryGrid.ItemsSource = versions;
        }
    }
}
