using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using IndiaSkills.Controls;

namespace IndiaSkills.Views
{
    /// <summary>
    /// Interaction logic for MoviesEdit.xaml
    /// </summary>
    public partial class MoviesEdit : UserControl
    {
        List<Movies> MoviesArray;

        public MoviesEdit()
        {
            InitializeComponent();

            MoviesArray = Helper.DatabaseMoviesDetails();
            MovieEditGrid.ItemsSource = MoviesArray;
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            if (MoviesArray != null)
                Helper.UpdateMovieDetails(MoviesArray);
        }
    }
}
