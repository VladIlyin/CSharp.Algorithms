namespace CSharp.Algorithms.Problems.Topics.BitManipulation;

public partial class BitManipulation
{
    //  We apply the extended version of this gate in our bitwise XOR operator.
    //  If we do "a^b" , it means that we are applying the XOR gate on the 2 numbers in a bitwise fashion (on each of the corresponding bits of the numbers).
    //  Similarly , if we observe,

    //  A^A=0
    //  A^B^A=B
    //  (A^A^B) = (B^A^A) = (A^B^A) = B This shows that position doesn't matter.
    //  Similarly , if we see, a^a^a......... (even times)=0 and a^a........(odd times)=a

    //  We apply the above observations :
    //  Traverse the array and take the Bitwise XOR of each element.
    //  Return the value.

    //  Why does this work ??
    //  Because , the elements with frequency = 2 will result in 0.
    //  And then the only element with frequency= 1 will generate the answer.
        
    public static int SingleNumber(int[] nums)
    {
        var res = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            res ^= nums[i];
        }

        return res;
    }


}