using System.Collections.ObjectModel;
using System.Windows;
namespace Task
{
    public partial class HistoryWindow : Window
    {
        public HistoryWindow(ObservableCollection<Document> versions)
        {
            InitializeComponent();
            HistoryGrid.ItemsSource = versions;
        }
    }
}
