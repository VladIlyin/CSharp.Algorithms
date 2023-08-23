using CSharp.Algorithms.Problems.Topics.Matrix;

namespace CSharp.Algorithms.UnitTests.TopicsTests
{
    public class MatrixProblemTest
    {
        [Theory]
        [MemberData(nameof(GetEqualRowAndColumnPairsTestData))]
        public void EqualRowAndColumnPairsTest(int[][] matrix, int expected)
        {
            Assert.Equal(expected, MatrixProblem.EqualPairs(matrix));
        }

        public static IEnumerable<object[]> GetEqualRowAndColumnPairsTestData()
        {
            yield return new object[]
            {
                new int[2][] { new[] { 1, 2 }, new[] { 3, 4 } },
                0
            };
            yield return new object[]
            {
                new int[3][] { new[] { 3, 2, 1 }, new[] { 1, 7, 6 }, new[] { 2, 7, 7 } },
                1
            };
            yield return new object[]
            {
                new int[4][] { new[] { 3, 1, 2, 2 }, new[] { 1, 4, 4, 5 }, new[] { 2, 4, 2, 2 }, new[] { 2, 4, 2, 2 } },
                3
            };
            yield return new object[]
            {
                new int[2][] { new[] { 13, 13 }, new[] { 13, 13 } },
                4
            };
            yield return new object[]
            {
                new int[2][] { new[] { 11, 1 }, new[] { 1, 11 } },
                2
            };
        }

        [Theory]
        [MemberData(nameof(GetSortMatrixByColumnTestData))]
        public void SortMatrixByColumnTest(int[][] matrix, int col, int[][] expected)
        {
            var res = MatrixProblem.SortJaggedArray(matrix, col);
            Assert.Equal(expected, res);
        }

        public static IEnumerable<object[]> GetSortMatrixByColumnTestData()
        {
            yield return new object[]
            {
                new int[3][] { new[] { 3, 2 }, new[] { 1, 4 }, new [] { 2, 5 } },
                0,
                new int[3][] { new[] { 1, 4 }, new[] { 2, 5 }, new [] { 3, 2 } },
            };
            yield return new object[]
            {
                new int[5][] { new[] { 3, 4 }, new[] { 2, 3 }, new [] { 1, 2 }, new [] { 1, 5 }, new [] { 1, 15 } },
                1,
                new int[5][] { new[] { 1, 2 }, new[] { 2, 3 }, new [] { 3, 4 }, new [] { 1, 5 }, new [] { 1, 15 } },
            };
            yield return new object[]
            {
                new int[2][] { new[] { 3, 4 }, new[] { 2, 3 } },
                1,
                new int[2][] { new[] { 2, 3 }, new [] { 3, 4 } },
            };
            yield return new object[]
            {
                new int[3][] { new[] { 3, 2, 1 }, new[] { 1, 4, 6 }, new [] { 2, 1, 3 } },
                1,
                new int[3][] { new[] { 2, 1, 3 }, new[] { 3, 2, 1 }, new [] { 1, 4, 6 } },
            };
            yield return new object[]
            {
                new int[3][] { new[] { 3, 2, 1 }, new[] { 1, 4, 6 }, new [] { 2, 2, 3 } },
                1,
                new int[3][] { new[] { 3, 2, 1 }, new[] { 2, 2, 3 }, new [] { 1, 4, 6 } },
            };
        }
    }
}
