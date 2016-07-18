using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using IndiaSkills.Controls;

namespace IndiaSkills.Views
{
    /// <summary>
    /// Interaction logic for Shows.xaml
    /// </summary>
    public partial class Shows : UserControl
    {
        List<Show> ShowsArray;

        public Shows()
        {
            InitializeComponent();

            ShowsArray = Helper.DatabaseShowDetails();
            ShowDataGrid.ItemsSource = ShowsArray;

            HallCodeList.ItemsSource = Helper.DatabaseSiteDetails().Select(a => a.Code);
            MovieNameList.ItemsSource = Helper.DatabaseMoviesDetails().Select(a => a.MovieName);
        }

        private void btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            MovieNameList.ItemsSource = Helper.DatabaseMoviesDetails().Select(a => a.MovieName);
            HallCodeList.ItemsSource = Helper.DatabaseSiteDetails().Select(a => a.Code);
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            if (ShowsArray != null)
                Helper.UpdateShowsDetails(ShowsArray);
        }
    }
}
