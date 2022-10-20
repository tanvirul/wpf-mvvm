using ITARoutePlanner.View.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITARoutePlanner.View.ViewModels.Factories
{
    public class RoutePlannerViewModelFactory : IRoutePlannerViewModelFactory
    {
        private readonly CreateViewModel<SpacecraftViewModel> _createSpacecraftViewModel;
       
        public RoutePlannerViewModelFactory(CreateViewModel<SpacecraftViewModel> createSpacecraftViewModel)
        {
            _createSpacecraftViewModel = createSpacecraftViewModel;           
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Spacecraft:
                    return _createSpacecraftViewModel();
                
                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType");
            }
        }

    }
}
