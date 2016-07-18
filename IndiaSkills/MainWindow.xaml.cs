using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using IndiaSkills.Views;
using IndiaSkills.Controls;

using MahApps.Metro.Controls;

namespace IndiaSkills
{
    public partial class MainWindow : MetroWindow
    {
        enum DrawingWindows
        {
            LoginWindow,
            UserWindow
        };

        List<Grid> mWindows;
        List<TabItem> mTabs;
        MainViewModel CurrentContext;

        public MainWindow()
        {
            InitializeComponent();

            /* prepare environment */

            // prepare grids
            mWindows = new List<Grid>();
            mWindows.Add(LoginWindow);
            mWindows.Add(UserWindow);

            mTabs = new List<TabItem>();
            mTabs.Add(ProfileTab);
            mTabs.Add(SitesTab);
            mTabs.Add(TheatersTab);
            mTabs.Add(PlansTab);
            mTabs.Add(MoviesTab);
            mTabs.Add(SnacksTab);
            mTabs.Add(ShowsTab);
            mTabs.Add(BookingTab);

            // create main view model
            CurrentContext = new MainViewModel();
            DataContext = CurrentContext;

            // create some fake users
            // Helper.CreateFakeDatabase();

            /* intializations */
            // call user login panel
            LoginPanel.Content = new LoginForm(this, Helper.DataBaseLogin);
            AccountDetailsPanel.Content = new AccountDetails(CurrentContext);
            SiteDetailsPanel.Content = new SiteDetails();
            TheaterDetailsPanel.Content = new Theaters();
            LayoutDetailsPanel.Content = new PlanLayout();
            MoviesDetailsPanel.Content = new MoviesEdit();
            SnackDetailsPanel.Content = new SnackDetails();
            ShowsDetailsPanel.Content = new Shows();
            BookingPanel.Content = new Booking();

            ShowNewWindow(DrawingWindows.LoginWindow);

            // temp stuff
            // delete it in final build
            //ShowNewWindow(DrawingWindows.UserWindow);
            //LoginUser(new User() { Username = "Admin" });
        }

        public void LoginUser(User aUserObject)
        {
            CurrentContext.UserObject = aUserObject;
            
            ShowNewWindow(DrawingWindows.UserWindow);
            foreach (var tab in mTabs)
                tab.Visibility = Visibility.Collapsed;

            if (CurrentContext.UserObject.UserLevel == 1)
            {
                foreach (var tab in mTabs)
                    tab.Visibility = Visibility.Visible;
            }
            else
            {
                ProfileTab.Visibility = Visibility.Visible;
                BookingTab.Visibility = Visibility.Visible;
            }
        }

        private void ShowNewWindow(DrawingWindows aWindow)
        {
            foreach (var window in mWindows)
                window.Visibility = Visibility.Collapsed;

            switch(aWindow)
            {
                case DrawingWindows.LoginWindow:
                    LoginWindow.Visibility = Visibility.Visible;
                    break;
                case DrawingWindows.UserWindow:
                    UserWindow.Visibility = Visibility.Visible;
                    break;
                default:
                    throw new Exception(aWindow.ToString() + " not programmed");
            }
        }

        private void btn_logout_Click(object sender, RoutedEventArgs e)
        {
            ShowNewWindow(DrawingWindows.LoginWindow);
            CurrentContext.UserObject = null;
        }
    }
}
