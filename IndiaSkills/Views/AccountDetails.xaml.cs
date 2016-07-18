using System.Windows;
using System.Windows.Controls;

using IndiaSkills.Controls;

namespace IndiaSkills.Views
{
    /// <summary>
    /// Interaction logic for AccountDetails.xaml
    /// </summary>
    public partial class AccountDetails : UserControl
    {
        MainViewModel CurrentContext;

        public string Username
        {
            get { return CurrentContext.Username; }
            set { return; }
        }

        public AccountDetails(MainViewModel aContext)
        {
            InitializeComponent();
            CurrentContext = aContext;
        }

        private void btn_submit_Click(object sender, RoutedEventArgs e)
        {
            string old_pass, new_pass;
            old_pass = txt_old_password.Text;
            new_pass = txt_new_password.Text;

            if (string.IsNullOrEmpty(new_pass))
            {
                NotifyErrorWarning("Password can't be empty");
                return;
            }

            if (old_pass != CurrentContext.UserObject.Password)
            {
                NotifyErrorWarning("Old password doesn't match");
                return;
            }

            CurrentContext.UserObject.Password = new_pass;
            Helper.DataBaseLoginUpdatePassword(CurrentContext.Username, new_pass);
            NotifyErrorWarning("Password changed successfully!");
        }

        private void NotifyErrorWarning(string aWarning)
        {
            lbl_status.Content = aWarning;
        }
    }
}
