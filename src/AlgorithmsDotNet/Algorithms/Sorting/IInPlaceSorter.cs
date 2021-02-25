using System.Collections.Generic;

namespace AlgorithmsDotNet.Algorithms.Sorting
{
    public interface IInPlaceSorter<T>
    {
        /// <summary>
        /// Sort data in place in ascending order
        /// </summary>
        /// <param name="data"></param>
        void SortAscending(IList<T> data);

        /// <summary>
        /// Sort data in place in descending order
        /// </summary>
        /// <param name="data"></param>
        void SortDescending(IList<T> data);
    }
}
