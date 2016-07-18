using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using IndiaSkills.Controls;

namespace IndiaSkills.Views
{
    /// <summary>
    /// Interaction logic for Theaters.xaml
    /// </summary>
    public partial class Theaters : UserControl
    {
        List<Theater> TheatersArray;

        public Theaters()
        {
            InitializeComponent();

            TheatersArray = Helper.DatabaseTheaterDetails();
            TheaterDataGrid.ItemsSource = TheatersArray;

            HallCodeList.ItemsSource = Helper.DatabaseSiteDetails().Select(a => a.Code);
            TheaterPlanList.ItemsSource = Helper.DatabasePlanDetails().Select(a => a.LayoutName);
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            if (TheatersArray != null)
                Helper.UpdateTheaterDetails(TheatersArray);
        }

        private void btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            HallCodeList.ItemsSource = Helper.DatabaseSiteDetails().Select(a => a.Code);
            TheaterPlanList.ItemsSource = Helper.DatabasePlanDetails().Select(a => a.LayoutName);
        }
    }
}
