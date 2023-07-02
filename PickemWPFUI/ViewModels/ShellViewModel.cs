using Caliburn.Micro;
using PickemWPFUI.EventModels;
using PickemWPFUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickemWPFUI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>
    {
        private GamesViewModel _GamesVM;
        private SimpleContainer _container;

        private IEventAggregator _events;

        public ShellViewModel(IEventAggregator events, GamesViewModel gamesVM,
            SimpleContainer container)
        {
            _events = events;
            _GamesVM = gamesVM;
            _container = container;

            _events.Subscribe(this);

            ActivateItem(_container.GetInstance<LoginViewModel>());
        }

        public void Handle(LogOnEvent message)
        {
            ActivateItem(_GamesVM);
        }
    }
}
