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
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        /* Create a type double array with a size of "length" */
        var results = new double[length];
        /* A basic for loop is needed */
        for (int i = 0; i < length; i++) {
            /* Inside the for loop, set the value of the array at i as the result of "number" * (i + 1) */
            results[i] = number * (i + 1);
        }

        /* Return the array */
        return results;
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
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        /* Use GetRange() to store the range of numbers to be moved, you will need to subtract "amount" from "data.Count" to find the index */
        var range = data.GetRange(data.Count - amount, amount);
        /* Remove the range of numbers using RemoveRange(), the inside of the parentheses should look the same as GetRange() */
        data.RemoveRange(data.Count - amount, amount);
        /* Use InsertRange() with an index of 0 to put your stored range at the start of "data" */
        data.InsertRange(0, range);
    }
}
