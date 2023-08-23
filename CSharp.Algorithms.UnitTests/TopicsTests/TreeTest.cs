using CSharp.Algorithms.Core.Models;

namespace CSharp.Algorithms.UnitTests.TopicsTests;

public class TreeTests
{
    [Theory]
    [MemberData(nameof(BinaryTreeTraversalTestData))]
    public void BinaryTreeTraversalTest(int?[] expected, TreeNode root)
    {
        Assert.Equal(expected, root.ToValues());
    }

    public static IEnumerable<object[]> BinaryTreeTraversalTestData()
    {
        yield return new object[] { new int?[] { 1 }, TreeNode.CreateTree(new int?[] { 1 })! };
        yield return new object[] { new int?[] { 1, 2 }, TreeNode.CreateTree(new int?[] { 1, 2 })! };
        yield return new object[] { new int?[] { 1, 2, 3 }, TreeNode.CreateTree(new int?[] { 1, 2, 3 })! };
        yield return new object[] { new int?[] { 1, 2, 3, 4, null, null, 7 }, TreeNode.CreateTree(new int?[] { 1, 2, 3, 4, null, null, 7 })! };
        yield return new object[] { new int?[] { 1, 2, 3, null, null, 6, 7 }, TreeNode.CreateTree(new int?[] { 1, 2, 3, null, null, 6, 7 })! };
        yield return new object[] { new int?[] { 1, 2, 3, null, 4, null, 10, 5, null, null, 11 }, TreeNode.CreateTree(new int?[] { 1, 2, 3, null, 4, null, 10, 5, null, null, 11 })! };
        yield return new object[] { new int?[] { 1, 2, null, 3, null, 4, null, 5 }, TreeNode.CreateTree(new int?[] { 1, 2, null, 3, null, 4, null, 5 })! };
    }

    [Theory]
    [MemberData(nameof(CreateBinaryTreeFromArrayTestData))]
    public void CreateBinaryTreeFromArrayTest(int?[] array)
    {
        if (array.Length == 0 || array[0] is null)
        {
            Assert.Null(TreeNode.CreateTree(array));
        }
        else
        {
            var root = TreeNode.CreateTree(array);
            Assert.Equal(array, root.ToValues());
        }
    }

    public static IEnumerable<object[]> CreateBinaryTreeFromArrayTestData()
    {
        yield return new object[] { new int?[] { } };
        yield return new object[] { new int?[] { null } };
        yield return new object[] { new int?[] { null, 1, 2 } };
        yield return new object[] { new int?[] { 1 } };
        yield return new object[] { new int?[] { 1, 2, 3 } };
        yield return new object[] { new int?[] { 1, null, 3 } };
        yield return new object[] { new int?[] { 3, 9, 20, null, null, 15, 7 } };
        yield return new object[] { new int?[] { 1, 2, 3, null, 4, null, 10, 5, null, null, 11 } };
        yield return new object[] { new int?[] { 1, 2, null, 3, null, 4, null, 5 } };
        yield return new object[] { new int?[] { 20, 8, 22, 4, 12, null, null, null, null, 10, 14 } };
    }
}