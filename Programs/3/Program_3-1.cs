using System.Text.RegularExpressions;

// Read the input file
string input = File.ReadAllText("input.txt");

// Define the regex pattern
string pattern = @"mul\((\d+),(\d+)\)";

// Create integer to store final value
int calculatedValue = 0;

// Find matches
MatchCollection matches = Regex.Matches(input, pattern);

// Extract the numbers and add to the list
foreach (Match match in matches)
{
    int firstNumber = int.Parse(match.Groups[1].Value);
    int secondNumber = int.Parse(match.Groups[2].Value);
    calculatedValue += firstNumber * secondNumber;
}

// Print final value
Console.WriteLine(calculatedValue);
