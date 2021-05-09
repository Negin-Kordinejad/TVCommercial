using OptimizerService.Helper;
using OptimizerService.InternalService;
using OptimizerService.Model;
using OptimizerService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OptimizerService.Model.ConstantData;

namespace OptimizerService.Bussines
{
    public class CommertialObtimizer : ICommertialObtimizer
    {
        private readonly ICommercialPlacement _placement;
        private readonly IInitialDataHelper _data;
        private readonly IOptimizeHelper _opthelper;

        public CommertialObtimizer(ICommercialPlacement Placement, IInitialDataHelper data,
            IOptimizeHelper opthelper)
        {
            _placement = Placement;
            _data = data;
            _opthelper = opthelper;
        }

        public PrintModel FindOptimalPlacement()
        {

            var commertialPlacementsForProgram = new List<Placement[]>();

            var commercialPermutationList = GetCommercialPermutations();


            foreach (var Commercial in commercialPermutationList.ToList())
            {
                commertialPlacementsForProgram.Add(_placement.BuildPlacements(Commercial.ToList()));
            }


            commertialPlacementsForProgram.RemoveAll(placements => placements.Any(p => p.Rate == 0));
            commertialPlacementsForProgram.RemoveAll(placements => placements.Any(p => p.Commercional== null));

            var optimalMaxRatePlacement = commertialPlacementsForProgram.ToList()
                .GroupBy(placements => placements.Sum(p => p.Rate))
                .OrderByDescending(o => o.Key)
                .FirstOrDefault();

            var printModel = new PrintModel();
            foreach (var placements in optimalMaxRatePlacement)
            {
                printModel.Placements = placements;
                printModel.TotalRate = optimalMaxRatePlacement.Key;
            };
            return printModel;
        }

        private IEnumerable<IEnumerable<Commercial>> GetCommercialPermutations()
        {
            List<Commercial> Commercials = _data.InitialCommercionalData();
            var CListx = _opthelper.GetPermutations<Commercial>(Commercials.AsEnumerable(), Commercials.Count()).ToList();
            var CList = from c in CListx.ToList()
                        select c.ToList();
            return CList;
        }

    }
}

