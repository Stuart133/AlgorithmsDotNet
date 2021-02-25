using System.Collections.Generic;

namespace AlgorithmsDotNet.Algorithms.Sorting
{
    public interface IInPlaceSorter<T>
    {
        IEnumerable<T> SortAscending(IList<T> data);
        IEnumerable<T> SortDescending(IList<T> data);
    }
}
