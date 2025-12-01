using AdventOfCode_2025.Day1;

namespace AdventOfCode_2025;

public static class Program
{
    public static void Main()
    {
        Day1Part1 day1Part1 = new(startingValue: 50);
        day1Part1.Run();
        
        Day1Part2 day1Part2 = new(startingValue: 50);
        day1Part2.Run();
    }
}
