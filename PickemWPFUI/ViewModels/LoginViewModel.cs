using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace PickemWPFUI.ViewModels
{
    public class LoginViewModel : Screen
    {
		private string _userName;
        private string _password;	

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

		public void LogIn(string userName, string password)
		{
			Console.WriteLine("You logged in!");
		}
	}
}
