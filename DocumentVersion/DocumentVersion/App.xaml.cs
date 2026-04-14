using System.Configuration;
using System.Data;
using System.Windows;

namespace DocumentVersion
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private bool _isDarkTheme;

        public void ToggleTheme()
        {
            var dictionaries = Resources.MergedDictionaries;

            var currentTheme = dictionaries
                .FirstOrDefault(d => d.Source != null &&
                                     (d.Source.OriginalString.Contains("LightTheme.xaml")
                                      || d.Source.OriginalString.Contains("DarkTheme.xaml")));

            if (currentTheme != null)
                dictionaries.Remove(currentTheme);

            var newTheme = new ResourceDictionary
            {
                Source = new Uri(
                    _isDarkTheme ? "/Themes/LightTheme.xaml" : "/Themes/DarkTheme.xaml",
                    UriKind.Relative)
            };

            _isDarkTheme = !_isDarkTheme;
            dictionaries.Add(newTheme);
        }

        public bool IsDarkTheme => _isDarkTheme;
    }

}
