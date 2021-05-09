using OptimizerService.Model;
using System.Collections.Generic;

using static OptimizerService.Model.ConstantData;

namespace OptimizerService.InternalService
{
    public class InitialDataHelper : IInitialDataHelper
    {

        public Placement[] InitialPlacementData()
        {
            return new Placement[]
                     {
               new Placement(Break.Break1,PartOfBreak.ONE),
                new Placement(Break.Break1,PartOfBreak.TWO),
                 new Placement(Break.Break1,PartOfBreak.THREE),
                  new Placement(Break.Break2,PartOfBreak.ONE),
                   new Placement(Break.Break2,PartOfBreak.TWO),
                    new Placement(Break.Break2,PartOfBreak.THREE),
                     new Placement(Break.Break3,PartOfBreak.ONE),
                      new Placement(Break.Break3,PartOfBreak.TWO),
                       new Placement(Break.Break3,PartOfBreak.THREE)
                   //    new Placement(Break.Break3,PartOfBreak.FOUR)
                      };
        }

        public List<Commercial> InitialCommercionalData()
        {
            return new List<Commercial>
            {
                new Commercial{Name="Commercial1",CType=CType.Automotive,Demographic=Demographic.W2530},
                 new Commercial{Name="Commercial2",CType=CType.Travel,Demographic=Demographic.M1835},
                  new Commercial{Name="Commercial3",CType=CType.Travel,Demographic=Demographic.T1840},
                   new Commercial{Name="Commercial4",CType=CType.Automotive,Demographic=Demographic.M1835},
                    new Commercial{Name="Commercial5",CType=CType.Automotive,Demographic=Demographic.M1835},
                     new Commercial{Name="Commercial6",CType=CType.Finance,Demographic=Demographic.W2530},
                      new Commercial{Name="Commercial7",CType=CType.Finance,Demographic=Demographic.M1835},
                       new Commercial{Name="Commercial8",CType=CType.Automotive,Demographic=Demographic.T1840},
                        new Commercial{Name="Commercial9",CType=CType.Travel,Demographic=Demographic.W2530}
                      //   new Commercial{Name="Commercial10",CType=CType.Finance,Demographic=Demographic.T1840}
            };
        }




    }
}
