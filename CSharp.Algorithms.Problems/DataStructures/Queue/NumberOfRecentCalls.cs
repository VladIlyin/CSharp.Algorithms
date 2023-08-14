using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Algorithms.Problems.DataStructures.Queue
{
    public partial class QueueProblem
    {
        public class RecentCounter
        {

            private readonly Queue<int> _queue;
            private readonly int _timeWindow = 3000;

            public RecentCounter()
            {
                _queue = new();
            }

            public int Ping(int t)
            {
                _queue.Enqueue(t);

                while (t - _queue.Peek() > _timeWindow)
                {
                    _queue.Dequeue();
                }

                return _queue.Count();
            }
        }
    }
}
