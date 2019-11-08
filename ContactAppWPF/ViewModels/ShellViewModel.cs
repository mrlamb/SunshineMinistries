using ModelLibrary;
using System.Windows.Controls;
using Caliburn.Micro;

namespace ContactAppWPF.ViewModels
{
    public class ShellViewModel : Screen
    {
        private string _errorMessage;
        public string UserName { get; set; }
        public string UserPassword { get; set; }

        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                NotifyOfPropertyChange(() => ErrorMessage);
            }
        }
        public void AuthenticateUser()
        {
            user loggedInUser;
            if (Authentication.TryAuthenticateUser(UserName , UserPassword , out loggedInUser))
            {
                ErrorMessage = Authentication.AUTHENTICATION_SUCCESS;
                //Process Login
            }
            else
            {
                ErrorMessage = Authentication.AUTHENTICATION_FAILED;
            }
        }

        public void OnPasswordChanged(PasswordBox source)
        {
            UserPassword = source.Password;
        }
    }
}