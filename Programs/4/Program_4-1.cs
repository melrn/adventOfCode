using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        // Read the input file
        string input = File.ReadAllText("input.txt");

        // Create integer to store final value
        int xmasOccurence = 0;

        // Define the regex patterns
        string pattern1 = @"XMAS";
        string pattern2 = @"SAMX";

        // Read all lines from input.txt
        string[] lines = File.ReadAllLines("input.txt");

        // Determine the dimensions of the array
        int rows = lines.Length;
        int columns = lines[0].Length;

        // Create a 2D array
        char[,] grid = new char[rows, columns];

        // Fill the 2D array with characters from the file
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                grid[i, j] = lines[i][j];
            }
        }

        // Search top-left to bottom-right diagonals
        for (int column = 0; column < columns; column++)
        {
            for (int row = 0; row < rows; row++)
            {
                if (SearchDirection(grid, pattern1, row, column, 1, 0)) xmasOccurence++;// Down diagonal

                if (SearchDirection(grid, pattern2, row, column, 1, 0)) xmasOccurence++;// Up diagonal  

                if (SearchDirection(grid, pattern2, row, column, -1, 1)) xmasOccurence++; // Up-left diagonal
                
                if (SearchDirection(grid, pattern1, row, column, -1, 1)) xmasOccurence++; // Down-left diagonal
                
                if (SearchDirection(grid, pattern2, row, column, 1, 1)) xmasOccurence++; // Up-right diagonal

                if (SearchDirection(grid, pattern1, row, column, 1, 1)) xmasOccurence++; // Down-right diagonal
            }
        }

        // Find matches with regex
        MatchCollection matchesPattern1 = Regex.Matches(input, pattern1);
        xmasOccurence += matchesPattern1.Count;
        MatchCollection matchesPattern2 = Regex.Matches(input, pattern2);
        xmasOccurence += matchesPattern2.Count;
        Console.WriteLine(xmasOccurence);
    }

    static bool SearchDirection(char[,] grid, string word, int startRow, int startColumn, int rowDirection, int columnDirection)
    {
        int rows = grid.GetLength(0);
        int columns = grid.GetLength(1);
        int length = word.Length;

        for (int i = 0; i < length; i++)
        {
            int r = startRow + i * rowDirection;
            int c = startColumn + i * columnDirection;

            if (r < 0 || r >= rows || c < 0 || c >= columns || grid[r, c] != word[i])
            {
                return false;
            }
        }
        return true;
    }
}




