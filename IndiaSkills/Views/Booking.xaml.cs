using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using IndiaSkills.Controls;

namespace IndiaSkills.Views
{
    /// <summary>
    /// Interaction logic for Booking.xaml
    /// </summary>
    public partial class Booking : UserControl
    {
        List<Movies> MoviesArray;
        List<Site> SiteArray;
        List<Show> ShowArray;
        List<Snack> SnacksArray;
        List<Tuple<int, bool>> Seats;
        List<BookingDetail> BookingArray;

        string EncodedStringPlan;

        public Booking()
        {
            InitializeComponent();
            MoviesArray = Helper.DatabaseMoviesDetails();
            SiteArray = Helper.DatabaseSiteDetails();
            ShowArray = Helper.DatabaseShowDetails();
            SnacksArray = Helper.DatabaseSnackDetails();
            BookingArray = Helper.DatabaseBookingDetails();

            Seats = new List<Tuple<int, bool>>();
            Refresh();

            MovieName.ItemsSource = MoviesArray.Select(a => a.MovieName);
            listBox_seats.ItemsSource = Seats;
            Snacks.ItemsSource = SnacksArray.Select(a => a.Name);
            SiteLocation.ItemsSource = SiteArray.Select(a => string.Format("{0}, {1}", a.Address, a.City));
        }

        private void Refresh()
        {
            BookingArray = Helper.DatabaseBookingDetails();
            Seats.Clear();

            var layoutPlan = Helper.DatabasePlanDetails()[0];
            var encodedString = layoutPlan.EncodedString;
            EncodedStringPlan = encodedString;

            int area = layoutPlan.Rows * layoutPlan.Columns;
            for (int i = 0; i < area; i++)
                Seats.Add(new Tuple<int, bool>(encodedString[i] == '0' ? -1 : i, false));

            foreach(var bookedseats in BookingArray)
                Seats[bookedseats.SeatNo] = new Tuple<int, bool>(bookedseats.SeatNo, true);
            listBox_seats.Items.Refresh();

            lastSeatSelected = -1;
        }

        private void MovieName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var SelectedMovie = MovieName.SelectedItem as string;

            if (SelectedMovie == null)
                return;

            var TimingArray = new List<string>();
            foreach(var show in ShowArray)
            {
                if (show.MovieName == SelectedMovie)
                    TimingArray.Add(show.StartTiming);
            }

            ShowTiming.ItemsSource = TimingArray;

            RefreshAmount();
        }
                
        private void ShowTiming_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshAmount();
        }

        private double RefreshAmount()
        {
            var xMovieName = MovieName.SelectedItem as string;
            var xSiteLocation = SiteLocation.SelectedItem as string;
            var xShowTiming = ShowTiming.SelectedItem as string;
            var xSnacks = Snacks.SelectedItem as string;

            if (xSiteLocation == null || xMovieName == null || xShowTiming == null)
            {
                txt_pricing.Text = string.Empty;
                return -1;
            }

            double price = 0.0;
            foreach (var show in ShowArray)
            {
                if (show.MovieName == xMovieName &&
                    show.StartTiming == xShowTiming)
                {
                    price += show.Price;
                    break;
                }
            }

            if (xSnacks != null)
            {
                foreach (var snack in SnacksArray)
                {
                    if (snack.Name == xSnacks)
                        price += snack.Price;
                }
            }

            txt_pricing.Text = price.ToString();
            btn_submit.IsEnabled = lastSeatSelected != -1 && price != -1;
            return price;
        }

        int lastSeatSelected = -1;
        private void listBox_seats_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = listBox_seats.SelectedIndex;
            if (index == -1)
                return;

            var seatDetail = Seats[index];
            if (seatDetail.Item2)
                return;

            if (EncodedStringPlan[index] == '0')
                return;
                        
            Seats[index] = new Tuple<int, bool>(seatDetail.Item1, true);
            if (lastSeatSelected != -1)
                Seats[lastSeatSelected] = new Tuple<int, bool>(lastSeatSelected, false);

            listBox_seats.Items.Refresh();
            lastSeatSelected = index;
            txt_SeatNo.Text = index.ToString();

            btn_submit.IsEnabled = lastSeatSelected != -1 && RefreshAmount() != -1;
        }

        private void btn_submit_Click(object sender, RoutedEventArgs e)
        {
            var xMovieName = MovieName.SelectedItem as string;
            var xSiteLocation = SiteLocation.SelectedItem as string;
            var xShowTiming = ShowTiming.SelectedItem as string;
            var xSnacks = Snacks.SelectedItem as string;

            var pricePaid = RefreshAmount();
            if (pricePaid == -1)
                return;

            if (lastSeatSelected == -1)
            {
                btn_submit.IsEnabled = false;
                return;
            }

            if (BookingArray == null)
                return;

            int RandomHash = new Random().Next(100000, 999999);

            BookingArray.Add(new BookingDetail
            {
                Location = xSiteLocation,
                MovieName = xMovieName,
                PricePaid = pricePaid,
                RandomHash = RandomHash,
                SeatNo = lastSeatSelected,
                Snacks = xSnacks == null ? string.Empty : xSnacks,
                Timing = xShowTiming
            });

            MessageBox.Show("Booking Confirmed!\nCode: " + RandomHash);

            Helper.UpdateBookingDetails(BookingArray);
            Refresh();
        }
    }
}
