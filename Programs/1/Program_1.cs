using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


    // Path to the text file
    string filePath = "input.txt";

    // Read all lines from the file
    string[] lines = File.ReadAllLines(filePath);

    // Initialize arrays based on the number of lines
    int[] list1 = new int[lines.Length];
    int[] list2 = new int[lines.Length];


    // Parse the file content
    for (int i = 0; i < lines.Length; i++)
        {
            // Split the line by spaces or tabs
            string[] numbers = lines[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            if (numbers.Length == 2)
            {
                // Add numbers to arrays
                list1[i] = int.Parse(numbers[0]);
                list2[i] = int.Parse(numbers[1]);
            }
        }

    // Sort lists
    Array.Sort(list1);
    Array.Sort(list2);

    // Initialize integers for AOC answers
    int totalDistance = 0;
    int similarityScore = 0;

    // Calculate total distance
    for (int i = 0; i < list1.Length; i++)
    {
        totalDistance += Math.Abs(list1[i] - list2[i]);

        // Calculate similarity score
        int countSimilar = 0;
        for (int j = 0; j < list2.Length; j++)
        {
            if (list1[i] == list2[j])
            {
                countSimilar++;
            }
        }
        similarityScore += list1[i] * countSimilar;
    }

    // Show total distance
    Console.WriteLine(totalDistance);

    // Show similarity score
    Console.WriteLine(similarityScore);