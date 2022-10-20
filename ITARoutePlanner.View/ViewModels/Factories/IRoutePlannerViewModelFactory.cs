using ITARoutePlanner.View.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITARoutePlanner.View.ViewModels.Factories
{
    public interface IRoutePlannerViewModelFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}
