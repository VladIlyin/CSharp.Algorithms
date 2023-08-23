using static CSharp.Algorithms.Problems.Topics.Queue.QueueProblem;

namespace CSharp.Algorithms.UnitTests.TopicsTests
{
    public class QueueProblemTest
    {
        [Theory]
        [InlineData(new int[] { 1, 100, 3000, 3001 }, new int[] { 1, 2, 3, 4 })]
        [InlineData(new int[] { 1, 100, 3001, 3002 }, new int[] { 1, 2, 3, 3 })]
        public void RecentCounterTest(int[] calls, int[] expected)
        {
            var countList = new List<int>();
            var counter = new RecentCounter();

            foreach (var call in calls)
            {
                var cnt = counter.Ping(call);
                countList.Add(cnt);
            }

            Assert.Equal(expected, countList);
        }

        [Theory]
        [InlineData("RD", "Radiant")]
        [InlineData("RDD", "Dire")]
        [InlineData("DDRRR", "Dire")]
        public void PredictPartyVictoryTest(string senate, string expected)
        {
            Assert.Equal(expected, PredictPartyVictory(senate));
        }
    }
}
