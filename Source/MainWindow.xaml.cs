using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Collections.ObjectModel;



namespace NoiceVideoDownloader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<SearchResultItem> SearchResult;
        public MainWindow()
        {
            InitializeComponent();
            SearchResultViewCtrl.DataContext = App.SearchProvider.SearchResult;
        }

        private void SelectViewMode(object sender, RoutedEventArgs e)
        {

        }

        // start search
        private void OnBtnSearchClick(object sender, RoutedEventArgs e)
        {
            App.SearchProvider.SearchResult.Clear();
            App.SearchProvider.Run();
        }
    }
}
  