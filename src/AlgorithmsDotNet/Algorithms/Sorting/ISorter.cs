using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsDotNet.Algorithms.Sorting
{
    public interface ISorter<T>
    {
        IEnumerable<T> SortAscending(IEnumerable<T> data);
        IEnumerable<T> SortDescending(IEnumerable<T> data);
    }
}
