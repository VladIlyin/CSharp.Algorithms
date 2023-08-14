using System.Text;

namespace CSharp.Algorithms.Core.HashFunctions;

public class PearsonHashFunction
{
    /* Permutation of 0-255 */
    public static readonly byte[] T = new byte[] { 1, 2, 3, 4, 5 };

    public static byte Hash(string input)
    {
        byte hash = 0;
        byte[] bytes = Encoding.UTF8.GetBytes(input);

        foreach (var b in bytes)
        {
            hash = T[(byte)(hash ^ b)];
        }

        return hash;
    }
}