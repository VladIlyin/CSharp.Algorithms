using CSharp.Algorithms.Core.Models;

namespace CSharp.Algorithms.Problems.DataStructures.LinkedList;

public partial class LinkedListOperations
{
    public static ListNode? Remove(ListNode? head, int val)
    {
        if (head == null)
        {
            return null;
        }

        ListNode prev = null;
        ListNode curr = head;

        while (curr != null)
        {
            if (curr.Val == val)
            {
                if (prev == null)
                {
                    head = head.Next;
                    curr = head;
                }
                else
                {
                    prev.Next = curr.Next;
                    curr = curr.Next;
                }
            }
            else
            {
                prev = curr;
                curr = curr.Next;
            }
        }

        return head;
    }

    public static ListNode Reverse(ListNode head)
    {
        ListNode prev = null;
        ListNode curr = head;
        ListNode temp;

        while (curr != null)
        {
            temp = curr.Next;
            curr.Next = prev;
            prev = curr;
            curr = temp;
        }

        return prev;
    }

    public static bool HasCycle(ListNode? head)
    {
        if (head == null)
        {
            return false;
        }

        var (slow, fast) = (head.Next, head.Next?.Next);

        while (fast != null
               && slow != null)
        {
            slow = slow.Next;
            fast = fast.Next?.Next;

            if (fast == slow)
                return true;
        }

        return false;
    }

    /// <summary>
    /// The method is used to find the middle node in a singly linked list.
    /// The method returns the middle node of the linked list or null
    /// if the input list is empty.
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    /// https://leetcode.com/problems/middle-of-the-linked-list/
    public static ListNode? FindMiddleNode(ListNode? head)
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

    public static ListNode MergeSortedLists(ListNode list1, ListNode list2)
    {
        if (list1 == null)
        {
            return list2;
        }

        if (list2 == null)
        {
            return list1;
        }

        if (list1.Val < list2.Val)
        {
            list1.Next = MergeSortedLists(list1.Next, list2);
            return list1;
        }
        else
        {
            list2.Next = MergeSortedLists(list1, list2.Next);
            return list2;
        }
    }

    public static ListNode DeleteDuplicatesFromSortedLists(ListNode head)
    {
        var current = head;

        while (current != null && current.Next != null)
        {
            if (current.Val == current.Next.Val)
            {
                current.Next = current.Next.Next;
            }
            else
            {
                current = current.Next;
            }
        }

        return head;
    }
}