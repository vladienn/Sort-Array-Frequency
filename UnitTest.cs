using Microsoft.VisualStudio.TestTools.UnitTesting;
using static SortArrayFrequency.Program;

namespace UnitTestFrequency

{
    [TestClass]
    public class FrequencyTests
    {
        [TestMethod]
        public void TestSampleInput1()
        {
            var o = new SortByFrequency();

            int[] Expected = { 9, 7, 102, 102, 3, 3, 3, 6, 6, 6, 6 };
            int[] arr = { 3, 6, 3, 7, 9, 102, 3, 6, 6, 6, 102 };

            int[] Result = o.FinalSort(arr);

            CollectionAssert.AreEqual(Expected, Result);
        }

        [TestMethod]
        public void TestSampleInput2()
        {
            var o = new SortByFrequency();

            int[] Expected = { 6, 40, 40, 15, 15, 7, 7, 7 };
            int[] arr = { 40, 15, 40, 7, 15, 6, 7, 7 };

            int[] Result = o.FinalSort(arr);

            CollectionAssert.AreEqual(Expected, Result);
        }

        [TestMethod]
        public void TestSampleInput3()
        {
            var o = new SortByFrequency();

            int[] Expected = { 999, 6, -1, 53, 53, 22, 22, 8, 8, 8 };
            int[] arr = { 22, 53, 22, 6, -1, 999, 53, 8, 8, 8 };

            int[] Result = o.FinalSort(arr);

            CollectionAssert.AreEqual(Expected, Result);
        }

        [TestMethod]
        public void TestSampleInput4()
        {
            var o = new SortByFrequency();

            int[] Expected = { 7, 6, 5, 3, 3, 1, 1, 4, 4, 4, 2, 2, 2, 2 };
            int[] arr = { 4, 4, 4, 2, 2, 2, 2, 3, 3, 1, 1, 6, 7, 5 };

            int[] Result = o.FinalSort(arr);

            CollectionAssert.AreEqual(Expected, Result);
        }

    } 
}
