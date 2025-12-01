using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode_2025.Day1
{
	public class Day1Part1(int startingValue)
	{
		private const int MaxValue = 99;
		private const int MinValue = 0;
		
		public void Run()
		{
			int val = startingValue;
			int zeroCount = 0;
			List<string> input;
			try
			{
				input = File.ReadAllLines("C:\\Users\\austin.maley\\Documents\\Advent of Code\\Puzzle_1_Input.txt").ToList();
			}
			catch (Exception e)
			{
				Console.WriteLine("Failed to read input file: " + e.Message);
				throw;
			}
			
			foreach(string item in input)
			{
				if(item.StartsWith('L'))
				{
					val = ClickLeft(val, GetInt(item));
				}
				else if(item.StartsWith('R'))
				{
					val = ClickRight(val, GetInt(item));
				}
				
				if(val == 0)
					zeroCount++;
			}
		
			Console.WriteLine(nameof(Day1Part1) + " result: " + zeroCount);
		}
	
		private static int GetInt(string code)
		{
			bool success = int.TryParse(code.AsSpan(1), out int val);
			if(!success)
				Console.WriteLine("failed to parse " + code);
			return val;
		}
	
		private static int ClickLeft(int currentValue, int clicks)
		{	
			int value = currentValue;
			for(int i = 0; i < clicks; i++)
			{
				if(value == MinValue)
				{
					value = MaxValue;
				}
				else
				{
					value--;
				}
			}
		
			return value;
		}
	
		private static int ClickRight(int currentValue, int clicks)
		{	
			int value = currentValue;
			for(int i = 0; i < clicks; i++)
			{
				if(value == MaxValue)
				{
					value = MinValue;
				}
				else
				{
					value++;
				}
			}
		
			return value;
		}
	}	
}
