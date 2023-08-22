//var dictCnt = Convert.ToInt32(Console.ReadLine());
//var suffixes = new Dictionary<string, List<string>>();
//var suffixes2 = new Dictionary<string, string>();

//for (var i = 0; i < dictCnt; i++)
//{
//    var str = Console.ReadLine();

//    for (var j = str.Length; j > 0; j--)
//    {
//        for (var k = 0; k < j; k++)
//        {
//            if (j == str.Length)
//            {
//                if (!suffixes.TryAdd(str[k..j], new List<string>() { str }))
//                {
//                    suffixes[str[k..j]].Add(str);
//                }
//            }
//            else
//            {
//                suffixes2.TryAdd(str[k..j], str);
//            }
//        }
//    }
//}

//var queryCnt = Convert.ToInt32(Console.ReadLine());
//var res = new List<string>();

//for (var n = 0; n < queryCnt; n++)
//{
//    var q = Console.ReadLine();
//    var currWord = "";
//    var flag = true;

//    for (var i = 1; i <= q.Length; i++)
//    {
//        if (suffixes.TryGetValue(q[^i..], out var words))
//        {
//            var wd = words.FirstOrDefault(w => !w.Equals(q));
//            if (wd is not null)
//            {
//                flag = false;
//                currWord = wd;
//            }
//        }

//        if (flag && suffixes2.TryGetValue(q[^i..], out var word))
//        {
//            currWord = word;
//            flag = false;
//        }
//    }

//    res.Add(currWord);

//}

//foreach (var str in res)
//{
//    Console.WriteLine(str);
//}

using CSharp.Algorithms;
using CSharp.Algorithms.Problems.Topics.Arrays;
using CSharp.Algorithms.Problems.Topics.Techniques.TwoPointers;

ConsoleHelper.Print(new TwoPointers().SortedSquares(new int[] { -7, -3, 2, 3, 11 }));