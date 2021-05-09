namespace OptimizerService.Model
{
    public class ConstantData
    {
        public enum CType 
        {
            Automotive, Travel, Finance
        }
        public enum Demographic
        {
            W2530, M1835, T1840

        }
        public enum Break
        {
            Break1, Break2, Break3
        }
        public enum PartOfBreak
        {
            ONE, TWO, THREE,FOUR
        }
        public enum RateEnum : int
        {
            B1DW = 80, B1DM = 100, B1DT = 250,
            B2DW = 50, B2DM = 120, B2DT = 200,
            B3DW = 350, B3DM = 150, B3DT = 500

        }
    }
}
