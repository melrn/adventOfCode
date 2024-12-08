using System.Text.RegularExpressions;

// Read the input file
string input = File.ReadAllText("input.txt");

// Define the regex pattern
string pattern = @"mul\((\d+),\s*(\d+)\)|\bdo\(\)|\bdon't\(\)";

// Create integer to store final value
int calculatedValue = 0;

// Find matches
MatchCollection matches = Regex.Matches(input, pattern);

// Create bool for Do() command, it starts active.
bool doCommand = true;

// Extract the numbers and add to the list
foreach (Match match in matches)
    if (match.Value.StartsWith("mul") && doCommand)
    {
        // If it's a mul(number,number), extract numbers
        string firstNumber = match.Groups[1].Value;
        string secondNumber = match.Groups[2].Value;
        calculatedValue += int.Parse(firstNumber) * int.Parse(secondNumber);
    }
    else if (match.Value == "do()")
    {
        // If it's a do()
        doCommand = true;
    }
    else if (match.Value == "don't()")
    {
        // If it's a don't()
        doCommand = false;
    }

// Print final value
Console.WriteLine(calculatedValue);
