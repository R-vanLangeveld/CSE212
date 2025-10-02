using System.Collections;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.  Remember to both express the solution 
    /// in terms of recursive call on a smaller problem and 
    /// to identify a base case (terminating case).  If the value of
    /// n <= 0, just return 0.   A loop should not be used.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        // TODO Start Problem 1
        if (n <= 0)
        {
            return n;
        }
        else
        {
            return n * n + SumSquaresRecursive(n - 1);
        }
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length
    /// 'size' from a list of 'letters' into the results list.  This function
    /// should assume that each letter is unique (i.e. the 
    /// function does not need to find unique permutations).
    ///
    /// In mathematics, we can calculate the number of permutations
    /// using the formula: len(letters)! / (len(letters) - size)!
    ///
    /// For example, if letters was [A,B,C] and size was 2 then
    /// the following would the contents of the results array after the function ran: AB, AC, BA, BC, CA, CB (might be in 
    /// a different order).
    ///
    /// You can assume that the size specified is always valid (between 1 
    /// and the length of the letters list).
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // TODO Start Problem 2
        if (word.Length == size)
        {
            if (!results.Contains(word))
            {
                results.Add(word);
            }
        }
        else
        {
            for (int i = 0; i < letters.Length; i++)
            {
                PermutationsChoose(results, letters.Remove(i, 1), size, word + letters[i]);
            }
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Imagine that there was a staircase with 's' stairs.  
    /// We want to count how many ways there are to climb 
    /// the stairs.  If the person could only climb one 
    /// stair at a time, then the total would be just one.  
    /// However, if the person could choose to climb either 
    /// one, two, or three stairs at a time (in any order), 
    /// then the total possibilities become much more 
    /// complicated.  If there were just three stairs,
    /// the possible ways to climb would be four as follows:
    ///
    ///     1 step, 1 step, 1 step
    ///     1 step, 2 step
    ///     2 step, 1 step
    ///     3 step
    ///
    /// With just one step to go, the ways to get
    /// to the top of 's' stairs is to either:
    ///
    /// - take a single step from the second to last step, 
    /// - take a double step from the third to last step, 
    /// - take a triple step from the fourth to last step
    ///
    /// We don't need to think about scenarios like taking two 
    /// single steps from the third to last step because this
    /// is already part of the first scenario (taking a single
    /// step from the second to last step).
    ///
    /// These final leaps give us a sum:
    ///
    /// CountWaysToClimb(s) = CountWaysToClimb(s-1) + 
    ///                       CountWaysToClimb(s-2) +
    ///                       CountWaysToClimb(s-3)
    ///
    /// To run this function for larger values of 's', you will need
    /// to update this function to use memoization.  The parameter
    /// 'remember' has already been added as an input parameter to 
    /// the function for you to complete this task.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // Base Cases
        if (s == 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;

        // TODO Start Problem 3
        if (remember == null)
        {
            remember = new Dictionary<int, decimal>();
        }

        decimal ways = 0;
        if (remember.ContainsKey(s))
        {
            return remember[s];
        }
        else
        {
            ways = CountWaysToClimb(s - 1, remember) + CountWaysToClimb(s - 2, remember) + CountWaysToClimb(s - 3, remember);
            remember[s] = ways;
        }

        // Solve using recursion
        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// A binary string is a string consisting of just 1's and 0's.  For example, 1010111 is 
    /// a binary string.  If we introduce a wildcard symbol * into the string, we can say that 
    /// this is now a pattern for multiple binary strings.  For example, 101*1 could be used 
    /// to represent 10101 and 10111.  A pattern can have more than one * wildcard.  For example, 
    /// 1**1 would result in 4 different binary strings: 1001, 1011, 1101, and 1111.
    ///	
    /// Using recursion, insert all possible binary strings for a given pattern into the results list.  You might find 
    /// some of the string functions like IndexOf and [..X] / [X..] to be useful in solving this problem.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    // public static void WildcardBinary(string pattern, List<string> results, int? asterisk = null)
    {
        // TODO Start Problem 4

        // I can't figure this out
        // I can't even figure out how to make it work without recursion
        
        // int totalAsterisks = 0;
        // if (asterisk == null)
        // {
        //     asterisk = 0;
        //     foreach (var item in pattern)
        //     {
        //         if (item == '*')
        //         {
        //             asterisk ++;
        //             totalAsterisks ++;
        //         }
        //     }
        // }
        // Console.Write("Asterisks: " + asterisk + "\n");

        if (pattern != "")
        {
            var test1 = "";
            // var test2 = pattern;
            // var result = "";
            // var result = pattern;
            for (int i = 0; i < pattern.Length; i++)
            {
                if (pattern[i] == '*')
                {
                    // if (asterisk % 2 == 1)
                    // {
                    //     asterisk--;
                    test1 += "1";
                    Console.Write("Mid 1 test1: " + test1 + "\n");
                    // test2 = test2.Remove(i, 1);
                    // test2 = test2.Insert(i, "1");
                    // Console.Write("Mid 1 test2: " + test2 + "\n");
                    // }
                    // else if (asterisk % 2 == 0)
                    // {
                    //     test1 += "0";
                    //     // asterisk--;
                    //     Console.Write("Mid 2 test1: " + test1 + "\n");
                    //     test2 = test2.Remove(i, 1);
                    //     test2 = test2.Insert(i, "0");
                    //     Console.Write("Mid 2 test2: " + test2 + "\n");
                    // }
                    // WildcardBinary(test2, results, totalAsterisks);
                }
                else
                {
                    test1 += pattern[i];
                    // Console.Write("Mid 1 test1: " + test1 + "\n");
                }
                // WildcardBinary(test2, results);
            }
            // Console.Write("End test1: " + test1 + "\n");
            // Console.Write("End test2: " + test2 + "\n");
            // Console.Write("Asterisks: " + asterisk + "\n");
            results.Add(test1); // 110101
            // results.Add(test2); // 110000

            // Maybe this can help??
            /* var result = "";
            if (result.Length == pattern.Length && result.Contains('*') == false)
            {
                if (!results.Contains(result))
                {
                    results.Add(result);
                }
            }
            else if (result.Contains('*'))
            {
                for (int i = 0; i < pattern.Length; i++)
                {
                    if (pattern[i] == '*')
                    {
                        // result += "1";
                        // Console.Write("Mid 1 result: " + result + "\n");
                    }
                    else
                    {
                        result += pattern[i];
                        // Console.Write("Mid 1 result: " + result + "\n");
                    }
                }
                // WildcardBinary(result, results);
            }
            else
            {
                // WildcardBinary(pattern, results);
            }
            
            Console.Write("End Result: " + result + "\n");
            results.Add(result);
            */
        }
        
        
        foreach (var item in results)
        {
            Console.Write("Standard: " + item + "\n");
        }
        results.Sort();
        foreach (var item in results)
        {
            Console.Write("Sorted: " + item + "\n");
        }
    }

    /// <summary>
    /// Use recursion to insert all paths that start at (0,0) and end at the
    /// 'end' square into the results list.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null, List<ValueTuple<int, int>>? failPath = null)
    {
        // If this is the first time running the function, then we need
        // to initialize the currPath list.
        if (currPath == null)
        {
            currPath = new List<ValueTuple<int, int>>();
        }
        if (failPath == null)
        {
            failPath = new List<ValueTuple<int, int>>();
        }

        // currPath.Add((1,2)); // Use this syntax to add to the current path

        // TODO Start Problem 5
        // ADD CODE HERE
        if (maze.Width >= 2 && maze.Height >= 2)
        {
            var move = true;
            currPath.Add((x, y));

            if (maze.IsValidMove(currPath, x, y - 1) && !failPath.Contains((x, y - 1)))
            {
                y --;
            }
            else if (maze.IsValidMove(currPath, x, y + 1) && !failPath.Contains((x, y + 1)))
            {
                y ++;
            }
            else if (maze.IsValidMove(currPath, x + 1, y) && !failPath.Contains((x + 1, y)))
            {
                x ++;
            }
            else if (maze.IsValidMove(currPath, x - 1, y) && !failPath.Contains((x - 1, y)))
            {
                x --;
            }
            else
            {
                move = false;
            }

            if (move == false && maze.IsEnd(x, y) == false)
            {
                currPath.Clear();
                failPath.Add((x, y));
                SolveMaze(results, maze, 0, 0, currPath, failPath);
            }
            else if (move == true && maze.IsEnd(x, y) == false)
            {
                SolveMaze(results, maze, x, y, currPath);
            }
            else if (move == true && maze.IsEnd(x, y) == true)
            {
                if (results.Count > 0)
                {
                    currPath.Add((x, y));
                    currPath.RemoveRange(0, 1);
                    results.Add(currPath.AsString());
                }
                else
                {
                    currPath.Add((x, y));
                    results.Add(currPath.AsString());
                    currPath.RemoveRange(2, 3);
                    currPath.RemoveRange(0, 1);
                    SolveMaze(results, maze, 0, 0, currPath, failPath);
                }
            }
        }
        // results.Add(currPath.AsString()); // Use this to add your path to the results array keeping track of complete maze solutions when you find the solution.
    }
}