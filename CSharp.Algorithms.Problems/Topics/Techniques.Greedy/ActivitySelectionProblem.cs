namespace CSharp.Algorithms.Problems.Topics.Techniques.Greedy;

//https://www.javatpoint.com/activity-selection-problem
//https://en.wikipedia.org/wiki/Activity_selection_problem
public class ActivitySelectionProblem
{
    public static IEnumerable<Activity> ScheduleMaximumActivity(List<Activity> activities)
    {
        Activity currentActivity = null;
        activities.Sort(new ActivityEndDateTimeFirst());

        foreach (var activity in activities)
        {
            if (!IsOverlap(currentActivity, activity))
            {
                currentActivity = activity;
                yield return activity;
            }
        }

        static bool IsOverlap(Activity? first, Activity second) =>
            first?.start >= second.start && first.start < second.end
            || first?.end > second.start && first.start <= second.end
            || first?.start <= second.start && first.end >= second.end;
    }
}

public record Activity(int number, DateTime start, DateTime end);

public class ActivityEndDateTimeFirst : Comparer<Activity>
{
    public override int Compare(Activity? x, Activity? y)
    {
        if (x == null || y == null) return 0;

        if (x.end > y.end)
        {
            return 1;
        }

        if (x.end < y.end)
        {
            return -1;
        }

        return 0;
    }
}