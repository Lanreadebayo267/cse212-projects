public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Create an array of size 'length'
        double[] multiples = new double[length];

        // Step 2: Loop over the array indices
        for (int i = 0; i < length; i++)
        {
            // Step 3: Calculate the multiple and store it
            multiples[i] = number * (i + 1);
        }

        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Get the size of the list
        int count = data.Count;

        // Step 2: Slice the last 'amount' elements
        List<int> tail = data.GetRange(count - amount, amount);

        // Step 3: Slice the first 'count - amount' elements
        List<int> head = data.GetRange(0, count - amount);

        // Step 4: Clear the original list
        data.Clear();

        // Step 5: Add the tail first, then the head
        data.AddRange(tail);
        data.AddRange(head);  
    }
}
