using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsDotNet.Algorithms.Sorting
{
    public interface ISorter<T>
    {
        /// <summary>
        /// Sort data in ascending order
        /// </summary>
        /// <param name="data"></param>
        /// <returns>The sorted data</returns>
        IEnumerable<T> SortAscending(IEnumerable<T> data);

        /// <summary>
        /// Sort data in descending order
        /// </summary>
        /// <param name="data"></param>
        /// <returns>The sorted data</returns>
        IEnumerable<T> SortDescending(IEnumerable<T> data);
    }
}
