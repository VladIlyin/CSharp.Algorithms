using CSharp.Algorithms.Core.Models;
using CSharp.Algorithms.Problems.DataStructures.Tree;

namespace CSharp.Algorithms.UnitTests.DataStructures
{
    public class AvlTreeTest
    {
        [Fact]
        public void InsertTest()
        {
            var node = new AvlTreeNode(1);

            foreach (var value in Enumerable.Range(2, 9))
            {
                node = AvlTreeNode
                    .Insert(node, value);
            }

            var actual = node.ToValues();

            Assert.Equal(node.ToValues(), new List<int?> { 4, 2, 8, 1, 3, 6, 9, null, null, null, null, 5, 7, null, 10 });

            // rotate right
            node = new AvlTreeNode(1);
            foreach (var value in new int[] { -2, -3 })
            {
                node = AvlTreeNode
                    .Insert(node, value);
            }

            Assert.Equal(node.ToValues(), new List<int?> { -2, -3, 1 });
            
            // rotate left
            node = new AvlTreeNode(1);
            foreach (var value in new int[] { 2, 3 })
            {
                node = AvlTreeNode
                    .Insert(node, value);
            }

            Assert.Equal(node.ToValues(), new List<int?> { 2, 1, 3 });

            // rotate left, rotate right
            node = new AvlTreeNode(1);
            foreach (var value in new int[] { -3, -2 })
            {
                node = AvlTreeNode
                    .Insert(node, value);
            }

            Assert.Equal(node.ToValues(), new List<int?> { -2, -3, 1 });

            // rotate right, rotate left
            node = new AvlTreeNode(1);
            foreach (var value in new int[] { 3, 2 })
            {
                node = AvlTreeNode
                    .Insert(node, value);
            }

            Assert.Equal(node.ToValues(), new List<int?> { 2, 1, 3 });

            node = new AvlTreeNode(1);
            foreach (var value in new int[] { 2, 3, 4, 5, 6, 7 })
            {
                node = AvlTreeNode
                    .Insert(node, value);
            }

            Assert.Equal(new List<int?> { 4, 2, 6, 1, 3, 5, 7 }, node.ToValues());
        }

        [Theory]
        [MemberData(nameof(RemoveTestData))]
        public void RemoveTest(AvlTreeNode root, int valToRemove, IEnumerable<int?> expected)
        {
            //var node = new AvlTreeNode(1);

            //foreach (var value in Enumerable.Range(2, 9))
            //{
            //    node = AvlTreeNode
            //        .Insert(node, value);
            //}

            //node = AvlTreeNode.Remove(node, 8);

            //var actual = node.ToValues();

            //Assert.Equal(actual, new List<int?> { 4, 2, 7, 1, 3, 6, 9, null, null, null, null, 5, null, null, 10 });

            var actual = AvlTreeNode
                .Remove(root, valToRemove)
                .ToValues();

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> RemoveTestData()
        {
            //yield return new object[]
            //{
            //    new int[] { 1, 2, 3 }.ToAvlTree(),
            //    3,
            //    new List<int?> { 2, 1 },
            //};
            //yield return new object[]
            //{
            //    new int[] { 1, 2, 3, 4 }.ToAvlTree(),
            //    3,
            //    new List<int?> { 2, 1, 4 },
            //};
            //yield return new object[]
            //{
            //    new int[] { 1, 2, 3, 4, 5 }.ToAvlTree(),
            //    4,
            //    new List<int?> { 2, 1, 5, null, null, 3 },
            //};
            //yield return new object[]
            //{
            //    new int[] { 1, 2, 3, 4, 5, 6, 7 }.ToAvlTree(),
            //    4,
            //    new List<int?> { 5, 2, 6, 1, 3, null, 7 },
            //};
            yield return new object[]
            {
                new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }.ToAvlTree(),
                4,
                new List<int?> { 5, 2, 8, 1, 3, 6, 9, null, null, null, null, null, 7, null, 10 },
            };
        }
    }
}
