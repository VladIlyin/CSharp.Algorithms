namespace CSharp.Algorithms.Problems.DataStructures.Queue
{
    public partial class QueueProblem
    {
        public static string PredictPartyVictory(string senate)
        {
            var queue = new Queue<char>();
            var (radiantSenatorsCount, direSenatorsCount) = (0, 0);
            var (dFloatingBan, rFloatingBan) = (0, 0);

            foreach (var senator in senate)
            {
                switch (senator)
                {
                    case 'R':
                        radiantSenatorsCount++;
                        break;
                    case 'D':
                        direSenatorsCount++;
                        break;
                }

                queue.Enqueue(senator);
            }

            while (radiantSenatorsCount > 0 && direSenatorsCount > 0)
            {
                var currentSenator = queue.Dequeue();

                if (currentSenator == 'D')
                {
                    if (dFloatingBan > 0)
                    {
                        dFloatingBan--;
                        direSenatorsCount--;
                    }
                    else
                    {
                        rFloatingBan++;
                        queue.Enqueue('D');
                    }
                }
                else
                {
                    if (rFloatingBan > 0)
                    {
                        rFloatingBan--;
                        radiantSenatorsCount--;
                    }
                    else
                    {
                        dFloatingBan++;
                        queue.Enqueue('R');
                    }
                }
            }

            return radiantSenatorsCount == 0 ? "Dire" : "Radiant";
        }
    }
}
