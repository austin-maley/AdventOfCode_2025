using System.Xml;

namespace AdventOfCode_2025.Day3;

public class Day3Part2
{
    public void Run()
    {
        long runningTotal = 0;
        List<string> banks = ReadFile();
        
        foreach (string bank in banks)
        {
            long value = ProcessBank(bank);
            runningTotal += value;
        }
        
        Console.WriteLine(nameof(Day3Part1) + " result: " + runningTotal);
    }

    private static long ProcessBank(string bank)
    {
        int[] nums = bank.Select(c => (int)char.GetNumericValue(c)).ToArray();
        int arrLength = 12;
        int[] arr = new int[arrLength];
        
        int endIndex = 0;
        for (int i = 0; i < arrLength; i++)
        {
            int startingIndex = (nums.Length - arrLength) + i;
            int tempNum = -1;
            int tempIndex = startingIndex;
            
            for (int j = startingIndex; j >= endIndex; j--)
            {
                int val = nums[j];
                if (tempNum <= val)
                {
                    tempNum = val;
                    tempIndex = j;
                }
            }
            arr[i] = tempNum;
            endIndex = tempIndex + 1;
        }

        return long.Parse(string.Join("", arr.Select(x => x)));
    }

    private List<string> ReadFile()
    {
        return File.ReadAllLines("Day3/Day3Input.txt").ToList();
    }
}
