﻿namespace CSharp.Algorithms.Problems.Others;

//https://www.codewars.com/kata/54acc128329e634e9a000362/train/csharp
public static class TCP
{
    private static Dictionary<string, string> StateEvent = new Dictionary<string, string>()
    {
        ["CLOSED:APP_PASSIVE_OPEN"] = "LISTEN",
        ["CLOSED:APP_ACTIVE_OPEN"] = "SYN_SENT",
        ["LISTEN:RCV_SYN"] = "SYN_RCVD",
        ["LISTEN:APP_SEND"] = "SYN_SENT",
        ["LISTEN:APP_CLOSE"] = "CLOSED",
        ["SYN_RCVD:APP_CLOSE"] = "FIN_WAIT_1",
        ["SYN_RCVD:RCV_ACK"] = "ESTABLISHED",
        ["SYN_SENT:RCV_SYN"] = "SYN_RCVD",
        ["SYN_SENT:RCV_SYN_ACK"] = "ESTABLISHED",
        ["SYN_SENT:APP_CLOSE"] = "CLOSED",
        ["ESTABLISHED:APP_CLOSE"] = "FIN_WAIT_1",
        ["ESTABLISHED:RCV_FIN"] = "CLOSE_WAIT",
        ["FIN_WAIT_1:RCV_FIN"] = "CLOSING",
        ["FIN_WAIT_1:RCV_FIN_ACK"] = "TIME_WAIT",
        ["FIN_WAIT_1:RCV_ACK"] = "FIN_WAIT_2",
        ["CLOSING:RCV_ACK"] = "TIME_WAIT",
        ["FIN_WAIT_2:RCV_FIN"] = "TIME_WAIT",
        ["TIME_WAIT:APP_TIMEOUT"] = "CLOSED",
        ["CLOSE_WAIT:APP_CLOSE"] = "LAST_ACK",
        ["LAST_ACK:RCV_ACK"] = "CLOSED",
    };

    public static string TraverseStates(string[] events)
    {
        var state = "CLOSED"; // initial state, always

        for (var i = 0; i < events.Length; i++)
        {
            if (!StateEvent.TryGetValue($"{state}:{events[i]}", out state))
            {
                return "ERROR";
            }
        }

        return state;
    }
}