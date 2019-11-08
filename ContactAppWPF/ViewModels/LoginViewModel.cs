using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Caliburn.Micro;
using ModelLibrary;

namespace ContactAppWPF.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string _errorMessage;
        private string _userName;
        private string _userPassword;
        private IAuthentication _authentication;
        public LoginViewModel(IAuthentication authentication)
        {
            _authentication = authentication;
        }
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                NotifyOfPropertyChange(() => UserName);
                NotifyOfPropertyChange(() => CanAuthenticateUser);
            }
        }
        public string UserPassword
        {
            get
            {
                return _userPassword;
            }
            set {
                _userPassword = value;
                NotifyOfPropertyChange(() => UserPassword);
                NotifyOfPropertyChange(() => CanAuthenticateUser);
            }
        }

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

        public bool CanAuthenticateUser
        {
            get
            {
                bool output = false;
                if (UserName?.Length > 0 && UserPassword?.Length > 0)
                {
                    output = true;
                }
                return output;
            }
        }

        public void AuthenticateUser()
        {
            ErrorMessage = Authentication.AUTHENTICATION_IN_PROGRESS;

            try
            {
                var result = _authentication.Authenticate(UserName , UserPassword);
                if (null != result)
                {
                    ErrorMessage = Authentication.AUTHENTICATION_SUCCESS;
                }
                else
                {
                    ErrorMessage = Authentication.AUTHENTICATION_FAILED;
                }
            }
            catch (Exception E)
            {

                ErrorMessage = E.Message;
            }


            
        }


    }
}
