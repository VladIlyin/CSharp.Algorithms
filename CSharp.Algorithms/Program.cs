var dictCnt = Convert.ToInt32(Console.ReadLine());

var dict = new string[dictCnt];
for (var i = 0; i < dictCnt; i++)
{
    dict[i] = Reverse(Console.ReadLine());
}

var maxDictWord = dict.Max(s => s.Length);

var queryCnt = Convert.ToInt32(Console.ReadLine());
var queryList = new List<string>(queryCnt);
var res = new List<string>();

for (var i = 0; i < queryCnt; i++)
{
    queryList.Add(Reverse(Console.ReadLine()));
    //var queryStr = Reverse(Console.ReadLine());
    //var max = 0;
    //var currMaxStr = "";
    //var currDictStr = "";

    //var offset = 0;
    //while (currMaxStr == "")
    //{
    //    if (offset > maxDictWord) break;

    //    for (var j = 0; j < dictCnt; j++)
    //    {
    //        currDictStr = Reverse(dict[j]);

    //        if (currDictStr.Length <= offset) continue;

    //        currDictStr = currDictStr.Substring(offset);

    //        if (queryStr == currDictStr) continue;

    //        var s1 = "";
    //        var s2 = "";

    //        if (queryStr.Length > currDictStr.Length)
    //        {
    //            s1 = queryStr;
    //            s2 = currDictStr;
    //        }
    //        else
    //        {
    //            s1 = currDictStr;
    //            s2 = queryStr;
    //        }

    //        int idx = 0;
    //        var currMax = 0;
    //        foreach (var ch in s1)
    //        {
    //            if (idx >= s2.Length) break;

    //            if (ch == s2[idx++])
    //            {
    //                currMax++;
    //            }
    //            else
    //            {
    //                break;
    //            }
    //        }

    //        if (currMax > max)
    //        {
    //            max = currMax;
    //            currMaxStr = Reverse(dict[j]);
    //        }
    //    }

    //    offset++;
    //}

    //res.Add(Reverse(currMaxStr));

}

var currPosition = 0;

foreach (var q in queryList)
{
    while (currPosition < maxDictWord)
    {
        (int max, int idx) memo = (-1, -1);
        for (var i = 0; i < dict.Length; i++)
        {
            var cnt = CheckAllSubstrings(q, dict[i][currPosition..]);
            if (cnt > memo.max)
            {
                memo.max = cnt;
                memo.idx = i;
            }
        }

        if (memo.max > 0)
        {
            res.Add(Reverse(dict[memo.idx]));
            break;
        }
        
        currPosition++;
    }

    currPosition = 0;
}

int CheckAllSubstrings(string q, string word)
{
    var idx = q.Length;
    while (idx > 0)
    {
        if (word.StartsWith(q[idx..]))
        {
            return idx;
        }

        idx--;
    }

    return 0;
}

foreach (var str in res)
{
    Console.WriteLine(str);
}

string Reverse(string s)
{
    char[] charArray = s.ToCharArray();
    Array.Reverse(charArray);
    return new string(charArray);
}