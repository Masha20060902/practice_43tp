using DocumentVersion.Model;
using System.Collections.ObjectModel;
using System.Windows;
namespace DocumentVersion.View
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
