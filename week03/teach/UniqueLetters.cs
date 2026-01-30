public static class UniqueLetters
{
    public static void Run()
    {
        var test1 = "abcdefghjiklmnopqrstuvwxyz"; // Expect True
        Console.WriteLine(AreUniqueLetters(test1));

        var test2 = "abcdefghjiklanopqrstuvwxyz"; // Expect False
        Console.WriteLine(AreUniqueLetters(test2));

        var test3 = ""; // Expect True
        Console.WriteLine(AreUniqueLetters(test3));
    }

    /// <summary>Determine if there are any duplicate letters in the text provided</summary>
    /// <param name="text">Text to check for duplicate letters</param>
    /// <returns>true if all letters are unique, otherwise false</returns>
    private static bool AreUniqueLetters(string text)
    {
        HashSet<char> seenLetters = new HashSet<char>();

        foreach (char letter in text)
        {
            if (seenLetters.Contains(letter))
            {
                return false;
            }

            seenLetters.Add(letter);
        }

        return true;
    }
}