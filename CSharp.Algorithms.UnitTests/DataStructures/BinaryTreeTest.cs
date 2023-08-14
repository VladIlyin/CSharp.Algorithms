using CSharp.Algorithms.Core.Models;
using CSharp.Algorithms.Problems.DataStructures.Tree;
using CSharp.Algorithms.Problems.Topics.Tree.BinaryTree;

namespace CSharp.Algorithms.UnitTests.DataStructures
{
    public class BinaryTreeTest
    {
        [Theory]
        [MemberData(nameof(InvertTestData))]
        public void InvertTest(int?[] tree, int?[] expected)
        {
            var invertedTree = BinaryTreeOperations.Invert(TreeNode.CreateTree(tree));
            var actual = invertedTree!.ToValues();

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(InvertTestData))]
        public void InvertRecursivelyTest(int?[] tree, int?[] expected)
        {
            var invertedTree = BinaryTreeOperations.InvertRecursively(TreeNode.CreateTree(tree));
            var actual = invertedTree!.ToValues();

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> InvertTestData()
        {
            yield return new object[] { new int?[] { 1 }, new int?[] { 1 } };
            yield return new object[] { new int?[] { 1, 2, 3 }, new int?[] { 1, 3, 2 } };
            yield return new object[] { new int?[] { 1, 2, 3, 4, null, 5, null }, new int?[] { 1, 3, 2, null, 5, null, 4 } };
            yield return new object[] { new int?[] { 1, 2, 3, 4, 5, 6, 7 }, new int?[] { 1, 3, 2, 7, 6, 5, 4 } };
            yield return new object[] { new int?[] { 1, 2, null, 3, null, 4 }, new int?[] { 1, null, 2, null, 3, null, 4 } };
        }

        [Fact]
        public void BinaryTreeGetHeightTest()
        {
            var root = new TreeNode(
                left: new TreeNode(), right: new TreeNode(left: new TreeNode())
            );

            Assert.Equal(3, BinaryTreeOperations.GetHeight(root));
        }

        [Theory]
        [MemberData(nameof(MergeTestData))]
        public void MergeBinaryTreesTest(int?[] tree1, int?[] tree2, int?[] expected)
        {
            var mergedTree = BinaryTreeOperations.Merge(
                TreeNode.CreateTree(tree1),
                TreeNode.CreateTree(tree2));

            var actual = mergedTree!.ToValues();

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> MergeTestData()
        {
            yield return new object[] { new int?[] { 1 }, new int?[] { 1 }, new int?[] { 2 } };
            yield return new object[] { new int?[] { 1, 2, 3 }, new int?[] { 4, 5, 6 }, new int?[] { 5, 7, 9 } };
            yield return new object[] { new int?[] { 1, null, 3, 4, 5 }, new int?[] { 1, 2, 3, 4, 5 }, new int?[] { 2, 2, 6, 4, 5, 4, 5 } };
        }

        [Theory]
        [MemberData(nameof(CountGoodNodesInBinaryTreeTestData))]
        public void CountGoodNodesInBinaryTreeTest(TreeNode root, int expected)
        {
            var actual = BinaryTreeProblem.GoodNodes(root);
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> CountGoodNodesInBinaryTreeTestData()
        {
            yield return new object[] { TreeNode.CreateTree(new int?[] { 3, 1, 4, 3, null, 1, 5 }), 4 };
            yield return new object[] { TreeNode.CreateTree(new int?[] { 3, 3, null, 4, 2 }), 3 };
        }

        [Theory]
        [MemberData(nameof(LowestCommonAncestorTestData))]
        public void LowestCommonAncestorTest(TreeNode root, TreeNode p, TreeNode q, TreeNode expected)
        {
            var actual = BinaryTreeProblem.LowestCommonAncestor(root, p, q);
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> LowestCommonAncestorTestData()
        {
            var root = TreeNode.CreateTree(new int?[] { 3, 5, 1, 6, 2, 0, 8, null, null, 7, 4 });
            yield return new object[]
            {
                root,
                root[1],
                root[2],
                root[0],
            };
            yield return new object[]
            {
                root,
                root[1],
                root[10],
                root[1],
            };
            yield return new object[]
            {
                root,
                root[5],
                root[6],
                root[2],
            };
            root = TreeNode.CreateTree(new int?[] { 1, 2 });
            yield return new object[]
            {
                root,
                root[0],
                root[1],
                root[0],
            };
            root = TreeNode.CreateTree(new int?[] { 1, 2, 3, null, 4, null, 5, 6, 7 });
            yield return new object[]
            {
                root,
                root[7],
                root[8],
                root[4],
            };
            root = TreeNode.CreateTree(new int?[] { 1, 2, 3 });
            yield return new object[]
            {
                root,
                root[1],
                root[2],
                root[0],
            };
        }

        [Theory]
        [MemberData(nameof(RightSideViewTestData))]
        public void RightSideViewTest(TreeNode root, IEnumerable<int> expected)
        {
            var actual1 = BinaryTreeProblem.RightSideView(root);
            var actual2 = BinaryTreeProblem.RightSideViewIterativeBFS(root);

            Assert.Equal(expected, actual1);
            Assert.Equal(expected, actual2);
        }

        public static IEnumerable<object[]> RightSideViewTestData()
        {
            yield return new object[]
            {
                TreeNode.CreateTree(new int?[] { 1, 2, 3, null, 5, null, 4 }),
                new List<int>() { 1, 3, 4 },
            };
            yield return new object[]
            {
                TreeNode.CreateTree(new int?[] { 1, null, 3 }),
                new List<int>() { 1, 3 },
            };
            yield return new object[]
            {
                null,
                new List<int>(),
            };
            yield return new object[]
            {
                TreeNode.CreateTree(new int?[] { 1, 2, 3, 4 }),
                new List<int>() { 1, 3, 4 },
            };
        }

        [Theory]
        [MemberData(nameof(MaxLevelSumTestData))]
        public void MaxLevelSumTest(TreeNode root, int expected)
        {
            var actual = BinaryTreeProblem.MaxLevelSum(root);

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> MaxLevelSumTestData()
        {
            yield return new object[]
            {
                TreeNode.CreateTree(new int?[] { 1, 7, 0, 7, -8, null, null }),
                2,
            };
            yield return new object[]
            {
                TreeNode.CreateTree(new int?[] { 989, null, 10250, 98693, -89388, null, null, null, -32127 }),
                2,
            };
            yield return new object[]
            {
                TreeNode.CreateTree(new int?[] { -100, -200, -300, -20, -5, -10, null }),
                3,
            };
        }
    }
}
