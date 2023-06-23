using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickemWPFUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        LoginViewModel _LoginVM;

        private ShellViewModel(LoginViewModel loginVM)
        {
            _LoginVM = loginVM;
            ActivateItem(_LoginVM);
        }
    }
}
