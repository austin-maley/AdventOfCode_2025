using System.Globalization;

namespace AdventOfCode_2025.Day3;

public class Day3Part1
{
    public void Run()
    {
        long runningTotal = 0;
        List<string> banks = ReadFile();

        foreach (string bank in banks)
        {
            Console.WriteLine(bank);
            int p1 = 0;
            int p2 = 1;

            int value1 = (int)char.GetNumericValue(bank[p1]);
            int value2 = (int)char.GetNumericValue(bank[p2]);
            
            while (p2 < bank.Length)
            {
                char val = bank[p2];
                int bankValue = (int)char.GetNumericValue(val);
                
                if (p2+1 != bank.Length && bankValue > value1)
                { 
                    value1 = bankValue;
                    value2 = (int)char.GetNumericValue(bank[p2+1]);
                }
                else if (bankValue > value2)
                {
                    value2 = bankValue;
                    
                    char prevChar = bank[p1];
                    int prevVal = (int)char.GetNumericValue(prevChar);
                    if (prevVal > value1)
                    {
                        value1 = prevVal;
                    }
                    p1 = p2;
                }

                p2++;
            }
            
            Console.WriteLine("Val1: " + value1);
            Console.WriteLine("Val2: " + value2);
            string str = $"{value1}{value2}";
            
            runningTotal += int.Parse(str);
        }
        
        Console.WriteLine(nameof(Day3Part1) + " result: " + runningTotal);
    }

    private List<string> ReadFile()
    {
        return File.ReadAllLines("Day3/Day3Input.txt").ToList();
    }
}
