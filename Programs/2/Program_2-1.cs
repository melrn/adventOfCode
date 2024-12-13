using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Path to the text file
string filePath = "input.txt";

// Read all lines from the file
string[] lines = File.ReadAllLines(filePath);

// Declare answer integer
int safeReports = 0;
// int unSafeReports = 0;

for (int i = 0; i < lines.Length; i++)
{
    // Split the line by spaces or tabs
    string[] numbers = lines[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

    // Convert string array to integer array
    int[] report = numbers.Select(int.Parse).ToArray();

    // false for decreasing / true for increasing values
    bool increasing = false;

    // remembers direction from first and second value
    bool sameDirection = false;

    for (int j = 1; j < report.Length; j++)
    {

        // Setting direction
        if (j == 1)
        {
            if (report[0] < report[1])
            {
                increasing = true;
                sameDirection = true;
                // Console.WriteLine("First Increasing");
            }
            else
            {
                increasing = false;
                sameDirection = false;
                // Console.WriteLine("First Decreasing");
            }
        } 
        else 
        {
          if (report[j-1] < report[j])
            {
                increasing = true;
                // Console.WriteLine("Increasing");
            }
            else
            {
                increasing = false;
                // Console.WriteLine("Decreasing");
            }  
        }

        // Checks if not safe
        if (report[j] == report[j - 1] || Math.Abs(report[j] - report[j - 1]) > 3 || increasing != sameDirection)
        {
            Console.WriteLine(lines[i]);
            // Console.ReadLine();
            // unSafeReports++;
            break;
        }

        // Safe reports
        if (j == report.Length-1)
        {
            safeReports++;
            Console.WriteLine("Safe");
        }
    }
}

Console.WriteLine(safeReports);
// Console.WriteLine(unSafeReports);