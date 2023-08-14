﻿using CSharp.Algorithms.Core.Models;

namespace CSharp.Algorithms.Problems.DataStructures.LinkedList
{
    public partial class LinkedListProblem
    {
        public int PairSum(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;

            // Get middle of the linked list.
            while (fast != null && fast.Next != null)
            {
                fast = fast.Next.Next;
                slow = slow.Next;
            }

            // Reverse second half of the linked list.
            ListNode NextNode, prev = null;
            while (slow != null)
            {
                NextNode = slow.Next;
                slow.Next = prev;
                prev = slow;
                slow = NextNode;
            }

            ListNode start = head;
            int maximumSum = 0;

            while (prev != null)
            {
                maximumSum = Math.Max(maximumSum, start.Val + prev.Val);
                prev = prev.Next;
                start = start.Next;
            }

            return maximumSum;
        }
    }
}
