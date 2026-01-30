public static class DisplaySums
{
    public static void Run()
    {
        DisplaySumPairs(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

        Console.WriteLine("------------");
        DisplaySumPairs(new int[] { -20, -15, -10, -5, 0, 5, 10, 15, 20 });

        Console.WriteLine("------------");
        DisplaySumPairs(new int[] { 5, 11, 2, -4, 6, 8, -1 });
    }

    /// <summary>
    /// Display pairs of numbers (no duplicates should be displayed) that sum to
    /// 10 using a set in O(n) time. We are assuming that there are no duplicates
    /// in the list.
    /// </summary>
    /// <param name="numbers">array of integers</param>
    private static void DisplaySumPairs(int[] numbers)
    {
        HashSet<int> seen = new HashSet<int>();

        foreach (int x in numbers)
        {
            int target = 10 - x;

            if (seen.Contains(target))
            {
                Console.WriteLine($"{target} {x}");
            }

            seen.Add(x);
        }
    }
}