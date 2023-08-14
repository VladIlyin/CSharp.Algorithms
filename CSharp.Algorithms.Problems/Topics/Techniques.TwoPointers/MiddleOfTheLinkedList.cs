using CSharp.Algorithms.Core.Models;

namespace CSharp.Algorithms.Problems.Topics.Techniques.TwoPointers;

public partial class TwoPointers
{
    /// <summary>
    /// The method is used to find the middle node in a singly linked list.
    /// The method returns the middle node of the linked list or null
    /// if the input list is empty.
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    /// https://leetcode.com/problems/middle-of-the-linked-list/
    public static ListNode? MiddleNode(ListNode? head)
    {
        if (head == null)
            return null;

        ListNode fast = head;
        ListNode slow = head;

        while (fast != null && fast.Next != null)
        {
            slow = slow.Next;
            fast = fast.Next.Next;
        }

        return slow;
    }
}