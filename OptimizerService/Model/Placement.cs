using static OptimizerService.Model.ConstantData;

namespace OptimizerService.Model
{
    public class Placement
    {
        private Break _break;
        private PartOfBreak _partOfBreak;
        public Placement(Break @break, PartOfBreak partOfBreak)
        {
            _break = @break;
            _partOfBreak = partOfBreak;
        }

        public Break Break { get { return _break; } }
        public PartOfBreak PartOfBreak { get { return _partOfBreak; } }

        public Commercial Commercional { get; set; } = new Commercial();
        public int Rate;
    }
 
}
