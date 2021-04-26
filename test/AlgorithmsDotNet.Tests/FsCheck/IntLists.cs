using FsCheck;
using System.Collections.Generic;

namespace AlgorithmsDotNet.Tests.FsCheck
{
    internal class IntLists
    {
        public static Arbitrary<List<int>> ListOfAtLeastOne()
        {
            return Arb.Default.List<int>().Filter(l => l.Count > 1);
        }
    }
}
