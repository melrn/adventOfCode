using System.Transactions;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        // Some logic likes to do their thing day in day out.
        // Not this one, what an escape it will be!
        bool theGreatEscape = true;

        // read input
        string[] input = File.ReadAllLines("input.txt");

        int rowCount = input.Length;
        int colCount = input[0].Length;
        
        // declare and build map array
        char[,] map = new char[rowCount, colCount];

        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < colCount; j++)
            {
                map[i, j] = input[i][j];
            }
        }

        // Everyone needs a start
        int currPosX = 37;
        int currPosY = 65;
        map[currPosX, currPosY] = 'X';

        // lets give this one a try
        try
        {
            while (theGreatEscape)
            {
                // up
                for (int i = 1; i < rowCount + 1; i++)
                {
                    if (map[currPosX - i, currPosY] != '#')
                    {
                        map[currPosX - i, currPosY] = 'X';
                    }
                    else
                    {
                        currPosX -= i-1;
                        break;
                    }
                }
                // rigth
                for (int i = 1; i < rowCount + 1; i++)
                {
                    if (map[currPosX, currPosY + i] != '#')
                        map[currPosX, currPosY + i] = 'X';
                    else
                    {
                        currPosY += i-1;
                        break;
                    }

                }
                // down
                for (int i = 1; i < rowCount + 1; i++)
                {
                    if (map[currPosX + i, currPosY] != '#')
                    {
                        map[currPosX + i, currPosY] = 'X';
                    }
                    else
                    {
                        currPosX += i-1;
                        break;
                    }

                }
                // left
                for (int i = 1; i < rowCount + 1; i++)
                {
                    if (map[currPosX, currPosY - i] != '#')
                    {
                        map[currPosX, currPosY - i] = 'X';
                    }
                    else
                    {
                        currPosY -= i-1;
                        break;
                    }

                }
            }
        }
        catch (System.IndexOutOfRangeException ex)
        {
            int amountMapped = 0;
            StringBuilder sb = new();

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    sb.Append(map[i, j]);
                    if (map[i, j] == 'X')
                    {
                        amountMapped += 1;
                    }
                }
                sb.AppendLine();
            }
            Console.WriteLine($"Error: {ex.Message}");
            File.WriteAllText("output.txt", sb.ToString());
            Console.WriteLine($"The logic managed to escape after taking {amountMapped} steps."); // 5409
            Console.WriteLine("The logic believes you can escape too. Good luck!");
        }
    }   
}





