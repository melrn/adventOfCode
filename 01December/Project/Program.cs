using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


    // Path to the text file
    string filePath = "input.txt";

    // Read all lines from the file
    string[] lines = File.ReadAllLines(filePath);

    // Initialize two lists for the numbers
    List<int> list1 = new List<int>();
    List<int> list2 = new List<int>();

    // Parse the file content
    foreach (string line in lines)
    {
        // Split the line by spaces or tabs
        string[] numbers = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        if (numbers.Length == 2)
        {
            // Add numbers to their respective lists
            list1.Add(int.Parse(numbers[0]));
            list2.Add(int.Parse(numbers[1]));
        }
    }

    // Sort each list
    list1.Sort();
    list2.Sort();

    int totalDistance = 0;

    // Calculate total distance
    for (int i = 0; i < list1.Count; i++)
    {
        totalDistance += Math.Abs(list1[i] - list2[i]);
    }

    // Show total distance
    Console.WriteLine(totalDistance);
