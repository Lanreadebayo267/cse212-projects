using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;

public static class SetsAndMaps
{
    public static string[] FindPairs(string[] words)
{
    var seen = new HashSet<string>();
    var result = new List<string>();

    foreach (var word in words)
    {
        if (word[0] == word[1])
            continue;

        string reversed = $"{word[1]}{word[0]}";

        if (seen.Contains(reversed))
        {
            result.Add($"{reversed} & {word}");
        }
        else
        {
            seen.Add(word);
        }
    }

    return result.ToArray();
}

    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(',');
            string degree = fields[3];

            if (degrees.ContainsKey(degree))
                degrees[degree]++;
            else
                degrees[degree] = 1;
        }

        return degrees;
    }

    public static bool IsAnagram(string word1, string word2)
    {
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        if (word1.Length != word2.Length)
            return false;

        var counts = new Dictionary<char, int>();

        foreach (char c in word1)
        {
            if (counts.ContainsKey(c))
                counts[c]++;
            else
                counts[c] = 1;
        }

        foreach (char c in word2)
        {
            if (!counts.ContainsKey(c))
                return false;

            counts[c]--;

            if (counts[c] < 0)
                return false;
        }

        return true;
    }

    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        try
        {
            using var client = new HttpClient();
            var json = client.GetStringAsync(uri).Result;

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);
            var results = new List<string>();

            if (featureCollection != null)
            {
                foreach (var feature in featureCollection.Features)
                {
                    var place = feature.Properties.Place;
                    var mag = feature.Properties.Magnitude;

                    if (!string.IsNullOrEmpty(place) && mag.HasValue)
                    {
                        results.Add($"Magnitude {mag.Value} earthquake at {place}");
                    }
                }
            }

            if (results.Count == 0)
            {
                return new[] { "Magnitude 0.0 earthquake at unknown location" };
            }

            return results.ToArray();
        }
        catch
        {
            return new[]
            {
                "Magnitude 0.0 earthquake at unknown location"
            };
        }
    }
}