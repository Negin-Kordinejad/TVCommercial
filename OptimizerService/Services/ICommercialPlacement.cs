using OptimizerService.Model;
using System.Collections.Generic;

namespace OptimizerService.Services
{
    public interface ICommercialPlacement
    {
        public Placement[] BuildPlacements(List<Commercial> commericials);
    }
}