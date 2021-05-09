using OptimizerService.Model;
using System.Collections.Generic;

namespace OptimizerService.InternalService
{
    public interface IInitialDataHelper
    {
        List<Commercial> InitialCommercionalData();
        Placement[] InitialPlacementData();
    }
}