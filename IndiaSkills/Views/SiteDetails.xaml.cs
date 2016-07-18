using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using IndiaSkills.Controls;

namespace IndiaSkills.Views
{
    /// <summary>
    /// Interaction logic for SiteDetails.xaml
    /// </summary>
    public partial class SiteDetails : UserControl
    {
        List<Site> SiteDetailsArray;

        public SiteDetails()
        {
            InitializeComponent();

            SiteDetailsArray = Helper.DatabaseSiteDetails();
            SiteDataGrid.ItemsSource = SiteDetailsArray;
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            if (SiteDetailsArray != null)
                Helper.UpdateSiteDetails(SiteDetailsArray);
        }
    }
}
