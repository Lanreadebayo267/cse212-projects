using System;
using System.Collections.Generic;

public class FirstDuplicateFinder
{
    public static void Run()
    {
        string test1 = "abcddef";
        string test2 = "abcdefde";
        string test3 = "abc";
        string test4 = "aaaaaaaa";
        string test5 = "";

        Console.WriteLine(FindFirstDuplicate(test1));
        Console.WriteLine(FindFirstDuplicate(test2));
        Console.WriteLine(FindFirstDuplicate(test3));
        Console.WriteLine(FindFirstDuplicate(test4));
        Console.WriteLine(FindFirstDuplicate(test5));
    }

    public static string FindFirstDuplicate(string input)
    {
        HashSet<char> seen = new HashSet<char>();

        foreach (char c in input)
        {
            if (seen.Contains(c))
            {
                return c.ToString();
            }
            seen.Add(c);
        }

        return "???";
    }
}