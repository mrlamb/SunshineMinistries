using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Caliburn.Micro;
using ContactAppWPF.EventModels;
using ModelLibrary;
using ModelLibrary.Models;

namespace ContactAppWPF.ViewModels
{
    public class LoginViewModel : Screen
    {
        private UserCredentials _user;
        private string _errorMessage;
        private string _userName;
        private string _userPassword;
        private IAuthentication _authentication;
        private IEventAggregator _events;
        public LoginViewModel(IAuthentication authentication , UserCredentials user, IEventAggregator events)
        {
            _authentication = authentication;
            _user = user;
            _events = events;
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
            set
            {
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
                _user = _authentication.Authenticate(UserName , UserPassword);
                if (null != _user)
                {
                    ErrorMessage = Authentication.AUTHENTICATION_SUCCESS;
                    _events.PublishOnUIThread(new LogOnEvent());
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
