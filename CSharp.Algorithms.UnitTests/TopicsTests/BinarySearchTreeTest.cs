using CSharp.Algorithms.Core.Models;
using CSharp.Algorithms.Problems.Topics.Tree;

namespace CSharp.Algorithms.UnitTests.TopicsTests
{
    public class BinarySearchTreeTest
    {
        [Theory]
        [MemberData(nameof(RemoveTestData))]
        public void RemoveTest(TreeNode tree, int valToRemove, TreeNode? expected)
        {
            var actual = BinarySearchTreeOperations.Remove(tree, valToRemove);
            Assert.Equal(expected?.ToValues(), actual?.ToValues());
        }

        [Theory]
        [MemberData(nameof(RemoveTestData))]
        public void RemoveRecursivelyTest(TreeNode tree, int valToRemove, TreeNode? expected)
        {
            var actual = BinarySearchTreeOperations.RemoveRecursively(tree, valToRemove);
            Assert.Equal(expected?.ToValues(), actual?.ToValues());
        }

        public static IEnumerable<object[]> RemoveTestData()
        {
            // value is not presented in the BST
            yield return new object[]
            {
                TreeNode.CreateTree(new int?[] { 1, 2, 3 }) !,
                12345,
                TreeNode.CreateTree(new int?[] { 1, 2, 3 }) !,
            };
            // remove root
            yield return new object[]
            {
                TreeNode.CreateTree(new int?[] { 1 }) !,
                1,
                null,
            };
            // remove root
            yield return new object[]
            {
                TreeNode.CreateTree(new int?[] { 2, 1 }) !,
                2,
                TreeNode.CreateTree(new int?[] { 1 }) !,
            };
            // remove leaf node, parent left
            yield return new object[]
            {
                TreeNode.CreateTree(new int?[] { 7, 4, 15, null, null, 12, 30, null, null, 25, 35 }) !,
                4,
                TreeNode.CreateTree(new int?[] { 7, null, 15, 12, 30, null, null, 25, 35 }) !,
            };
            // remove leaf node, parent right
            yield return new object[]
            {
                TreeNode.CreateTree(new int?[] { 7, 4, 15, null, null, 12, 30, null, null, 25, 35 }) !,
                35,
                TreeNode.CreateTree(new int?[] { 7, 4, 15, null, null, 12, 30, null, null, 25 }) !,
            };
            // remove node, parent left child
            yield return new object[]
            {
                TreeNode.CreateTree(new int?[] { 7, 4, 15, null, null, 12, 30, null, null, 25, 35, null, 27, null, 45 }) !,
                25,
                TreeNode.CreateTree(new int?[] { 7, 4, 15, null, null, 12, 30, null, null, 27, 35, null, null, null, 45 }) !,
            };
            // remove node, parent right child
            yield return new object[]
            {
                TreeNode.CreateTree(new int?[] { 7, 4, 15, null, null, 12, 30, null, null, 25, 35, null, 27, null, 45 }) !,
                35,
                TreeNode.CreateTree(new int?[] { 7, 4, 15, null, null, 12, 30, null, null, 25, 45, null, 27 }) !,
            };
            // remove root node with two children
            yield return new object[]
            {
                TreeNode.CreateTree(new int?[] { 2, 1, 3 }) !,
                2,
                TreeNode.CreateTree(new int?[] { 3, 1 }) !,
            };
            // remove root node with two children, search min value in right subtree
            yield return new object[]
            {
                TreeNode.CreateTree(new int?[] { 10, 5, 15, null, null, 12, 20 }) !,
                10,
                TreeNode.CreateTree(new int?[] { 12, 5, 15, null, null, null, 20 }) !,
            };
            // remove root node with two children, search min value in right subtree
            yield return new object[]
            {
                TreeNode.CreateTree(new int?[] { 5, 3, 6, 2, 4, null, 7 }) !,
                5,
                TreeNode.CreateTree(new int?[] { 6, 3, 7, 2, 4 }) !,
            };
            // remove node with two children
            yield return new object[]
            {
                TreeNode.CreateTree(new int?[] { 7, 4, 15, null, null, 12, 30, null, null, 25, 35, 23 }) !,
                15,
                TreeNode.CreateTree(new int?[] { 7, 4, 23, null, null, 12, 30, null, null, 25, 35 }) !,
            };
            // remove node with two children
            yield return new object[]
            {
                TreeNode.CreateTree(new int?[] { 7, 4, 15, null, null, 12, 30, null, 14, 25, 35, null, null, null, 27 }) !,
                15,
                TreeNode.CreateTree(new int?[] { 7, 4, 25, null, null, 12, 30, null, 14, 27, 35 }) !,
            };
        }
    }
}
