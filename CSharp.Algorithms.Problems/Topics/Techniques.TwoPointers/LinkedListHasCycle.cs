using CSharp.Algorithms.Core.Models;

namespace CSharp.Algorithms.Problems.Topics.Techniques.TwoPointers;

public partial class TwoPointers
{
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
}