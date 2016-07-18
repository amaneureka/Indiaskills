using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using IndiaSkills.Controls;

namespace IndiaSkills.Views
{
    /// <summary>
    /// Interaction logic for SnackDetails.xaml
    /// </summary>
    public partial class SnackDetails : UserControl
    {
        List<Snack> SnackArray;

        public SnackDetails()
        {
            InitializeComponent();

            SnackArray = Helper.DatabaseSnackDetails();
            SnackDetailsGrid.ItemsSource = SnackArray;
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            if (SnackArray != null)
                Helper.UpdateSnackDetails(SnackArray);
        }
    }
}
