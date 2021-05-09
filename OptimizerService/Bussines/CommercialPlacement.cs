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
    public class CommercialPlacement : ICommercialPlacement
    {
        private Placement[] _placements;
        private List<Commercial> _commercials;
        private readonly IInitialDataHelper _data;

        public CommercialPlacement(IInitialDataHelper data)
        {
            _data = data;
        }
        public Placement[] BuildPlacements(List<Commercial> commericials)
        {
            _commercials = commericials;
            _placements = _data.InitialPlacementData();
            Place();
            SetRates();
            return _placements;
        }
        private void Place()
        {
            Array.ForEach(_placements, p =>
            {
                p.Commercional = _commercials.Where(c => _placements
                                .GroupBy(p => p.Commercional.Name)
                                .All(g => g.Key != c.Name))
                                .First();
            });
        }
        private void SetRates()
        {
            foreach (var p in _placements)
            {
                if (p.Commercional != null)
                {
                    if (p.Break == Break.Break1 && p.Commercional.Demographic == Demographic.W2530)
                        p.Rate = (int)RateEnum.B1DW;
                    if (p.Break == Break.Break1 && p.Commercional.Demographic == Demographic.M1835)
                        p.Rate = (int)RateEnum.B1DM;
                    if (p.Break == Break.Break1 && p.Commercional.Demographic == Demographic.T1840)
                        p.Rate = (int)RateEnum.B1DT;
                    if (p.Break == Break.Break2 && p.Commercional.Demographic == Demographic.W2530)
                        p.Rate = (int)RateEnum.B2DW;
                    if (p.Break == Break.Break2 && p.Commercional.Demographic == Demographic.M1835)
                        p.Rate = (int)RateEnum.B2DM;
                    if (p.Break == Break.Break2 && p.Commercional.Demographic == Demographic.T1840)
                        p.Rate = (int)RateEnum.B2DT;
                    if (p.Break == Break.Break3 && p.Commercional.Demographic == Demographic.W2530)
                        p.Rate = (int)RateEnum.B3DW;
                    if (p.Break == Break.Break3 && p.Commercional.Demographic == Demographic.M1835)
                        p.Rate = (int)RateEnum.B3DM;
                    if (p.Break == Break.Break3 && p.Commercional.Demographic == Demographic.T1840)
                        p.Rate = (int)RateEnum.B3DT;
                }
            }

            for (var i = 0; i <= _placements.Length - 2; i++)
            {
                if (_placements[i].Commercional != null)
                {
                    if (_placements[i].Commercional.CType == _placements[i + 1].Commercional.CType)
                    {
                        _placements[i + 1].Rate = 0;
                    }
                }
            }
            foreach (var p in _placements.Where(p => p.Break == Break.Break2)
                       .Where(p => p.Commercional.CType == CType.Finance))
            {
                p.Rate = 0;
            }

        }


    }
}
