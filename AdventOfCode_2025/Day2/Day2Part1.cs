using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode_2025.Day2;

public partial class Day2Part1
{
    private int p1 = 0;
    private int p2 = 0;
    private string data;
    long runningTotal = 0;
    
    [GeneratedRegex("^(\\d+)\\1+$")]
    private static partial Regex MyRegex();
    
    public void Run()
    {
        data = ReadFile();
        
        int startingIndex = 0;
        while (startingIndex < data.Length)
        {
            (long id1, long id2, int index) = GetRange(startingIndex);
            ProcessIds(id1, id2);
            startingIndex = index;
        }

        Console.WriteLine(nameof(Day2Part1) + " result: " + runningTotal);
    }

    private void ProcessIds(long id1, long id2)
    {
        Regex reg = MyRegex();
        while (id1 <= id2)
        {
            if (HalvesMatch(id1.ToString()))
            {
                Console.WriteLine(id1);
                runningTotal += id1;
            }
            id1++;
        }
    }

    private bool HalvesMatch(string s)
    {
        if (s.Length % 2 != 0)
        {
            return false;
        }

        int half = s.Length / 2;
        return s.Substring(0, half) == s.Substring(half, half);
    }

    private (long, long, int) GetRange(int startingIndex)
    {
        p2 = startingIndex;
        while (p2 < data.Length)
        {
            if (data[p2].Equals('-'))
            {
                p1 = p2;
            }
            else if (data[p2].Equals(','))
            {
                break;
            }
            p2++;
        }
        
        string id1 = data.Substring(startingIndex, p1 - startingIndex);
        string id2 = data.Substring(p1 + 1, p2 - p1 - 1);
        
        return (long.Parse(id1), long.Parse(id2), p2 + 1);
    }

    private string ReadFile()
    {
        return File.ReadAllText("Day2/Day2Input.txt");
    }
}
