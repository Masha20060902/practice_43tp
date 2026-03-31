using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection.Metadata;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Task
{
    /// <summary>
    /// Логика взаимодействия для AddVersionDocument.xaml
    /// </summary>
    public partial class AddVersionDocument : Window
    {
        private MainWindow _mainWindow;
        private Document _document;
        public AddVersionDocument(MainWindow mainWindow, Document document)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            _document = document;
        }

        private void AddV_Click(object sender, RoutedEventArgs e)
        {
            var doc3 = new Documents
            {
                VersionNumber = Convert.ToInt32(Version.Text),
                Date = DateTime.ParseExact(Date.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture),
                Author = Author.Text
            };
            _document.documents.Add(doc3);
            _mainWindow.DataGrid.ItemsSource = null;
            _mainWindow.DataGrid.ItemsSource = _document.documents;
            _mainWindow.SaveVersion();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
