using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using IndiaSkills.Controls;

namespace IndiaSkills.Views
{
    /// <summary>
    /// Interaction logic for PlanLayout.xaml
    /// </summary>
    public partial class PlanLayout : UserControl
    {
        List<PlanDetails> PlanLayoutArray;
        List<Tuple<int, bool>> Seats;

        public PlanLayout()
        {
            InitializeComponent();

            PlanLayoutArray = Helper.DatabasePlanDetails();

            foreach (var LayoutName in PlanLayoutArray)
                PlansList.Items.Add(LayoutName.LayoutName);
        }

        static int counter = 0;
        private void btn_create_plan_Click(object sender, RoutedEventArgs e)
        {
            var newLayout = new PlanDetails { LayoutName = "NewPlan" + (++counter), Rows = 10, Columns = 5, EncodedString = string.Empty };
            PlanLayoutArray.Add(newLayout);
            PlansList.Items.Add(newLayout.LayoutName);
        }

        private void btn_save_plan_Click(object sender, RoutedEventArgs e)
        {
            if (PlanLayoutArray == null)
                return;
            PlansList.Items.Clear();
            foreach (var LayoutName in PlanLayoutArray)
                PlansList.Items.Add(LayoutName.LayoutName);

            Helper.UpdatePlanDetails(PlanLayoutArray);
        }

        private void PlansList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = PlansList.SelectedIndex;
            if (index == -1)
                return;
            panel_details.Visibility = Visibility.Visible;
            var Layout = PlanLayoutArray[index];
            txt_planName.Text = Layout.LayoutName;
            Seats = Layout.GetListViewData();
            listBox_seats.ItemsSource = Seats;
        }

        private void txt_planName_TextChanged(object sender, TextChangedEventArgs e)
        {
            int index = PlansList.SelectedIndex;
            if (index == -1)
                return;
            var Layout = PlanLayoutArray[index];
            Layout.LayoutName = txt_planName.Text;
        }

        private void listBox_seats_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = listBox_seats.SelectedIndex;
            if (index == -1)
                return;

            var tuple = Seats[index];
            Seats[index] = new Tuple<int, bool>(tuple.Item1, !tuple.Item2);
            listBox_seats.Items.Refresh();

            index = PlansList.SelectedIndex;
            if (index == -1)
                return;

            var charMap = new char[Seats.Count];
            for (int i = 0; i < Seats.Count; i++)
            {
                char map = (Seats[i].Item2 ? '1' : '0');
                charMap[i] = map;
            }
            PlanLayoutArray[index].EncodedString = new string(charMap);
        }
    }
}
