using System.Text;

namespace CSharp.Algorithms.Core.HashFunctions;

// https://en.wikipedia.org/wiki/MurmurHash
// compare this implementation with wikipedia
public class MurmurHashFunction
{
    const int seed = 0x098f1a7a;
    const int m = 0x5bd1e995;
    const int r = 24;

    public static int Hash(string value)
    {
        var data = Encoding.UTF8.GetBytes(value);

        int length = data.Length;

        if (length == 0)
            return 0;

        int h = seed ^ length;
        int currentIndex = 0;

        while (length >= 4)
        {
            int k = data[currentIndex++] | data[currentIndex++] << 8 | data[currentIndex++] << 16 | data[currentIndex++] << 24;
            k *= m;
            k ^= k >> r;
            k *= m;

            h *= m;
            h ^= k;
            length -= 4;
        }

        switch (length)
        {
            case 3:
                h ^= (ushort)(data[currentIndex++] | data[currentIndex++] << 8);
                h ^= data[currentIndex] << 16;
                h *= m;
                break;
            case 2:
                h ^= (ushort)(data[currentIndex++] | data[currentIndex] << 8);
                h *= m;
                break;
            case 1:
                h ^= data[currentIndex];
                h *= m;
                break;
            default:
                break;
        }

        h ^= h >> 13;
        h *= m;
        h ^= h >> 15;

        return h;
    }
}