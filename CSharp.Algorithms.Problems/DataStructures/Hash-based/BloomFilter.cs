using System.Collections;
using CSharp.Algorithms.Core.HashFunctions;

namespace CSharp.Algorithms.Problems.DataStructures.Hash_based;

public class BloomFilter
{
    private BitArray array = new(int.MaxValue, false);

    public void Set(string value)
    {
        array[MurmurHashFunction.Hash(value)] = true;
    }

    public bool Contains(string value)
    {
        return array[MurmurHashFunction.Hash(value)];
    }
}