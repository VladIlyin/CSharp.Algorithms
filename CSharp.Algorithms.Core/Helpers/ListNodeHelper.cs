using CSharp.Algorithms.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Algorithms.Core.Helpers;

public static class ListNodeHelper
{
    public static void Insert(this ListNode node, int val, ListNode? next = null)
    {
        var temp = node;

        while (temp.Next != null)
        {
            temp = temp.Next;
        }

        temp.Next = new ListNode(val, next);
    }
}