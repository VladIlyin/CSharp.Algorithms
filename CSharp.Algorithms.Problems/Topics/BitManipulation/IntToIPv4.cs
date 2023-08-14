namespace CSharp.Algorithms.Problems.Topics.BitManipulation;

public static class IntToIPv4
{
    public static string UInt32ToIP(uint ip)
    {
        return $"{ip >> 24}.{(ip >> 16) & 0xFF}.{(ip >> 8) & 0xFF}.{ip & 0xFF}";
        //return ((ip & 0xFF000000) >> 24) + "." + ((ip & 0x00FF0000) >> 16) + "." + ((ip & 0x0000FF00) >> 8) + "." + ((ip & 0x000000FF));

        //var binaryString = Convert.ToString(ip, 2).PadLeft(32, '0');
        //string GetOctet(int pos) => Convert.ToInt32(binaryString.Substring(pos, 8), 2).ToString();
        //return $"{GetOctet(0)}.{GetOctet(8)}.{GetOctet(16)}.{GetOctet(24)}";
    }
}