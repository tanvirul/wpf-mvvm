using ITARoutePlanner.View.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITARoutePlanner.View.State.Navigators
{
    public enum ViewType
    {
        Spacecraft,
        Home,
        RoutePlanner
    }

    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        event Action StateChanged;
    }
}
