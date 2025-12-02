using System.Text.RegularExpressions;

namespace AdventOfCode_2025.Day2;

public partial class Day2Part2
{
    private int _p1;
    private int _p2;
    private string _data = "";
    private long _runningTotal;
    
    [GeneratedRegex("^(\\d+)\\1+$")]
    private static partial Regex MyRegex();
    
    public void Run()
    {
        _data = ReadFile();
        
        int startingIndex = 0;
        while (startingIndex < _data.Length)
        {
            (long id1, long id2, int index) = GetRange(startingIndex);
            ProcessIds(id1, id2);
            startingIndex = index;
        }

        Console.WriteLine(nameof(Day2Part1) + " result: " + _runningTotal);
    }

    private void ProcessIds(long id1, long id2)
    {
        Regex reg = MyRegex();
        while (id1 <= id2)
        {
            if (reg.Match(id1.ToString()).Success || HalvesMatch(id1.ToString()))
            {
                Console.WriteLine(id1);
                _runningTotal += id1;
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
        _p2 = startingIndex;
        while (_p2 < _data.Length)
        {
            if (_data[_p2].Equals('-'))
            {
                _p1 = _p2;
            }
            else if (_data[_p2].Equals(','))
            {
                break;
            }
            _p2++;
        }
        
        string id1 = _data.Substring(startingIndex, _p1 - startingIndex);
        string id2 = _data.Substring(_p1 + 1, _p2 - _p1 - 1);
        
        return (long.Parse(id1), long.Parse(id2), _p2 + 1);
    }

    private string ReadFile()
    {
        return File.ReadAllText("Day2/Day2Input.txt");
    }
}
