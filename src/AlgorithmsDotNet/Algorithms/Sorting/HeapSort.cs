using AlgorithmsDotNet.DataStructures.Heaps;
using System.Collections.Generic;

namespace AlgorithmsDotNet.Algorithms.Sorting
{
    public class HeapSorter<T> : ISorter<T>, IInPlaceSorter<T>
    {
        /// <summary>
        /// Sort data using heapsort
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public IEnumerable<T> SortAscending(IEnumerable<T> data)
        {
            return data.HeapSortAscending();
        }

        /// <summary>
        /// Sort data in place using heapsort
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public void SortAscending(IList<T> data)
        {
            data.HeapSortAscending();
        }

        /// <summary>
        /// Sort data using heapsort
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public IEnumerable<T> SortDescending(IEnumerable<T> data)
        {
            return data.HeapSortDescending();
        }

        /// <summary>
        /// Sort data in place using heapsort
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public void SortDescending(IList<T> data)
        {
            data.HeapSortDescending();
        }
    }

    public static class HeapSortExtensions
    {
        /// <summary>
        /// Sort data using a heap sort
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">Data to be sorted</param>
        /// <returns>The sorted data</returns>
        public static IEnumerable<T> HeapSortAscending<T>(this IEnumerable<T> data)
        {
            IHeap<T> heap = new MaxHeap<T>(data);
            for (int i = heap.Count - 1; i > 0; i--)
            {
                heap.Pop();
            }

            return heap.ToList();
        }

        /// <summary>
        /// Sort data in place using a heap sort
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">Data to be sorted</param>
        public static void HeapSortAscending<T>(this IList<T> data)
        {
            IHeap<T> heap = new MaxHeap<T>(data);
            for (int i = heap.Count - 1; i > 0; i--)
            {
                heap.Pop();
            }
        }

        /// <summary>
        /// Sort data using a heap sort
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">Data to be sorted</param>
        /// <returns></returns>
        public static IEnumerable<T> HeapSortDescending<T>(this IEnumerable<T> data)
        {
            IHeap<T> heap = new MinHeap<T>(data);
            for (int i = heap.Count - 1; i > 0; i--)
            {
                heap.Pop();
            }

            return heap.ToList();
        }

        /// <summary>
        /// Sort data in place using a heap sort
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">Data to be sorted</param>
        public static void HeapSortDescending<T>(this IList<T> data)
        {
            IHeap<T> heap = new MinHeap<T>(data);
            for (int i = heap.Count - 1; i > 0; i--)
            {
                heap.Pop();
            }
        }
    }
}
