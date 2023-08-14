using System.Text;

namespace CSharp.Algorithms.Problems.Others;

public static class Base64
{
    private const string base64Table = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
    public static string ToBase64(string s)
    {
        var bytes = string.Join(null, s.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')));

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < bytes.Length; i += 6)
        {
            if (i + 6 > bytes.Length)
            {
                sb.Append(base64Table[Convert.ToInt16(bytes.Substring(i, bytes.Length - i).PadRight(6, '0'), 2)]);
                break;
            }

            sb.Append(base64Table[Convert.ToInt16(bytes.Substring(i, 6), 2)]);
        }

        return bytes.Length % 24 == 8
            ? sb.Append('=').Append('=').ToString()
            : bytes.Length % 24 == 16
                ? sb.Append('=').ToString()
                : sb.ToString();
    }

    public static string FromBase64(string s)
    {
        var bytes = string.Join(
            null, s.TrimEnd('=').Select(x => Convert.ToString(base64Table.IndexOf(x), 2).PadLeft(6, '0')));

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i + 6 < bytes.Length; i += 8)
        {
            sb.Append((char)Convert.ToInt16(bytes.Substring(i, 8), 2));
        }

        return sb.ToString();
    }
}