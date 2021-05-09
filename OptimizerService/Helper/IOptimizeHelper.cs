using System.Collections.Generic;

namespace OptimizerService.Helper
{
    public interface IOptimizeHelper
    {
        IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length);
    }
}