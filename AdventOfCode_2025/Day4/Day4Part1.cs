namespace AdventOfCode_2025.Day4;

public class Day4Part1
{
    public void Run()
    {
        Grid grid = new();
        List<string> input = File.ReadAllLines("Day4/Day4Input.txt").ToList();
        var columnCount = input[0].Length;
        
        foreach (string str in input)
        {
            foreach (char c in str)
            {
                grid.Rolls.Add(new Roll {Value = c});
            }
        }

        var result = grid.GetAccessibleRolls(columnCount, 4);
        Console.WriteLine(nameof(Day4Part1) + " result: " + result);
    }
}

public class Grid
{
    public List<Roll> Rolls = new();

    public long GetAccessibleRolls(int columnCount, int threshold)
    {
        int index = 0;
        foreach (Roll roll in Rolls)
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

public class Roll
{
    public char Value = ' ';
    public int IsRoll => '@'.Equals(Value) ? 1 : 0;
    public bool CanGrab;
}
