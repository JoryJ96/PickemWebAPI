using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using PickemWPFUI.Helpers;

namespace PickemWPFUI.ViewModels
{
    public class LoginViewModel : Screen
    {
		private string _userName;
		private string _password;
		private IAPIHelper _apiHelper;

        public LoginViewModel(IAPIHelper apiHelper)
        {
			_apiHelper = apiHelper;
        }

        public string Username
		{
			get { return _userName; }
			set {
				_userName = value;
				NotifyOfPropertyChange(() => Username);
				NotifyOfPropertyChange(() => CanLogIn);
			}
		}

		public string Password
		{
			get { return _password; }
			set
			{
				_password = value;
				NotifyOfPropertyChange(() => Password);
				NotifyOfPropertyChange(() => CanLogIn);
			}
		}

		// ERROR MESSAGE HANDLING
		public bool IsErrorVisible
		{
			get {
				bool output = false;

				if (ErrorMessage?.Length > 0)
				{
					output = true;
				}

				return output;
			}
		}

		private string _errorMessage;

		public string ErrorMessage
		{
			get { return _errorMessage; }
			set { 
				_errorMessage = value;
				NotifyOfPropertyChange(() => ErrorMessage);
				NotifyOfPropertyChange(() => IsErrorVisible);
			}
		}



		// LOGIN HANDLING
		// This is how the View determines if Log In can be pressed
		public bool CanLogIn
		{
			get
			{
                bool output = false;

                if (!String.IsNullOrEmpty(Username) && !String.IsNullOrEmpty(Password))
                {
                    output = true;
                }

                return output;
            }
		}

		public async Task LogIn()
		{
			try
			{
				var result = await _apiHelper.Authenticate(Username, Password);
				ErrorMessage = "";

				await _apiHelper.GetLoggedInUserInfo(result.Access_token);
			}
			catch (Exception ex)
			{

				ErrorMessage = ex.Message;
			}
		}
	}
}
