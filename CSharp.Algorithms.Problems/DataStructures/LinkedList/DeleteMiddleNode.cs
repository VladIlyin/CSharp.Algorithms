using CSharp.Algorithms.Core.Models;

namespace CSharp.Algorithms.Problems.DataStructures.LinkedList
{
    public partial class LinkedListProblem
    {
        public static ListNode DeleteMiddle(ListNode head)
        {
            if (head.Next == null) return null;

            var (slow, fast) = (head, head.Next.Next);

            while (fast is { Next: { } })
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            slow.Next = slow.Next.Next;

            return head;
        }
    }
}
