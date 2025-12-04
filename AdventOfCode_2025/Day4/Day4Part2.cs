namespace AdventOfCode_2025.Day4;

public class Day4Part2
{
    public void Run()
    {
        Grid2 grid2 = new();
        List<string> input = File.ReadAllLines("Day4/Day4Input.txt").ToList();
        int columnCount = input[0].Length;
        
        foreach (char c in input.SelectMany(str => str))
        {
            grid2.Rolls.Add(new Roll2 {Value = c});
        }

        long runningTotal = 0;
        long result = -1;
        while (result != 0)
        {
            result = grid2.GetAccessibleRolls(columnCount, 4);
            runningTotal += result;
            foreach (Roll2 roll in grid2.Rolls.Where(r => r.CanGrab))
            {
                roll.Value = '.';
                roll.CanGrab = false;
            }
        }

        Console.WriteLine(nameof(Day4Part2) + " result: " + runningTotal);
    }
}

public class Grid2
{
    public List<Roll2> Rolls = new();

    public long GetAccessibleRolls(int columnCount, int threshold)
    {
        int index = 0;
        foreach (Roll2 roll in Rolls)
        {
            if (roll.IsRoll == 0)
            {
                index++;
                continue;   
            }
            
            int count = 0;

            int mod = index % columnCount;
            
            if (mod != 0)
            {
                count += Process(index-1);  
                count += Process(index+columnCount-1);
                count += Process(index-columnCount-1);
            }
            
            if (mod != columnCount - 1)
            {
                count += Process(index+1);  
                count += Process(index+columnCount+1);
                count += Process(index-columnCount+1);
            }
            
            count += Process(index-columnCount);
            count += Process(index+columnCount);

            if (count < threshold)
            {
                roll.CanGrab = true;
            }
            
            index++;
        }
        
        return Rolls.Count(r => r.CanGrab);
    }

    private int Process(int index)
    {
        try
        {
            return Rolls[index].IsRoll;
        }
        catch
        {
            return 0;
        }
    }
}

public class Roll2
{
    public char Value = ' ';
    public int IsRoll => '@'.Equals(Value) ? 1 : 0;
    public bool CanGrab;
}
