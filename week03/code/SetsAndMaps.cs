using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text.Json;
using NuGet.Frameworks;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        List<string> pair = new List<string>();

        /* this works but has a time complexity of O(n²) and uses no sets */
        for (int i = 0; i < words.Length - 1; i++)
        {
            if (words[i][0] != words[i][1])
            {
                for (var x = i + 1; x < words.Length; x++)
                {
                    if (words[i][0] == words[x][1] && words[i][1] == words[x][0])
                    {
                        pair.Add($"{words[x]} & {words[i]}");
                    }
                }
            }
        }

        string[] pairs = pair.ToArray();
        return pairs;
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            if (degrees.ContainsKey(fields[3]))
            {
                degrees[fields[3]]++;
            }
            else
            {
                degrees.Add(fields[3], 1);
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        var letters1 = new Dictionary<char, int>();
        var letters2 = new Dictionary<char, int>();
        var letters = new HashSet<char>();
        var equal = false;
        var same = 0;

        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        foreach (var x in word1)
        {
            if (letters1.ContainsKey(x))
            {
                letters1[x] = letters1[x] + 1;
            }
            else
            {
                letters1.Add(x, 1);
                letters.Add(x);
            }
        }

        foreach (var x in word2)
        {
            if (letters2.ContainsKey(x))
            {
                letters2[x] = letters2[x] + 1;
            }
            else
            {
                letters2.Add(x, 1);
            }
        }

        if (letters1.Count == letters2.Count)
        {
            foreach (var i in letters)
            {
                if (letters2.ContainsKey(i))
                {
                    if (letters1[i] == letters2[i])
                    {
                        same++;
                    }
                }
            }
            if (same == letters.Count)
            {
                equal = true;
            }
        }

        if (equal == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        var features = featureCollection.features;
        var eqDescs = new string[features.Length];

        for (var i = 0; i < features.Length; i++)
        {
            eqDescs.SetValue($"{features[i].Properties.Place} - Mag {features[i].Properties.Mag}", i);
        }

        return eqDescs;
    }
}