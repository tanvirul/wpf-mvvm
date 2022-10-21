using ITARoutePlanner.View.Commands;
using ITARoutePlanner.View.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ITARoutePlanner.View.ViewModels
{
    public class RoutePlannerViewModel : ViewModelBase
    {
        public ICommand AddSpacecraftCommand { get; set; }
        public RoutePlannerViewModel(IRenavigator addSpacecraftRenavigator)
        {
            AddSpacecraftCommand = new  RenavigateCommand(addSpacecraftRenavigator);
        }
    }
}
