using System.Windows;
using System.Windows.Controls;

using IndiaSkills.Controls;

namespace IndiaSkills.Views
{
    /// <summary>
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    public partial class LoginForm : UserControl
    {
        User mUserObject;
        MainWindow mMainWindow;
        LoginHelper mLoginHelper;

        public LoginForm(MainWindow aMainWindow, LoginHelper aLoginHelper)
        {
            InitializeComponent();

            mLoginHelper = aLoginHelper;
            mMainWindow = aMainWindow;
        }

        private void btn_submit_Click(object sender, RoutedEventArgs e)
        {
            string user, pass;

            user = txt_username.Text.Trim();
            pass = txt_password.Text.Trim();

            if (string.IsNullOrEmpty(user))
            {
                NotifyErrorWarning("Invalid Username");
                return;
            }

            if (string.IsNullOrEmpty(pass))
            {
                NotifyErrorWarning("Invalid Password");
                return;
            }

            var UserObject = mLoginHelper(user, pass);

            if (UserObject == null)
            {
                NotifyErrorWarning("Wrong User Credentials");
                return;
            }

            mUserObject = UserObject;
            mMainWindow.LoginUser(mUserObject);
        }

        private void NotifyErrorWarning(string aWarning)
        {
            lbl_status.Content = aWarning;
        }
    }
}
