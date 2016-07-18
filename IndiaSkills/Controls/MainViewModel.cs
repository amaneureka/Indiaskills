using System.ComponentModel;

namespace IndiaSkills.Controls
{
    /// <summary>
    /// Main Window View Context Data Handler
    /// </summary>
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        User mUserObject;

        public User UserObject
        {
            get { return mUserObject; }
            set
            {
                mUserObject = value;
                OnPropertyChanged("Username");
            }
        }

        public string Username
        {
            get
            {
                if (UserObject == null)
                    return string.Empty;
                return UserObject.Username;
            }
        }

        public virtual void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
