using System.Collections.Generic;

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
        /// Sort data ascending order
        /// </summary>
        /// <param name="data"></param>
        IList<T> SortAscending(IList<T> data);

        /// <summary>
        /// Sort data in descending order
        /// </summary>
        /// <param name="data"></param>
        /// <returns>The sorted data</returns>
        IEnumerable<T> SortDescending(IEnumerable<T> data);

        /// <summary>
        /// Sort data in descending order
        /// </summary>
        /// <param name="data"></param>
        IList<T> SortDescending(IList<T> data);
    }
}
