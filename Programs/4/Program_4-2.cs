class Program
{
    static void Main(string[] args)
    {
        // Read the input file
        string input = File.ReadAllText("input.txt");

        // Create integer to store final value
        int xmasOccurence = 0;
 
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
        for (int column = 1; column < columns-1; column++)
        {
            for (int row = 1; row < rows-1; row++)
            {
                if (grid[row, column] == 'A')
                {
                    if (SearchMas(grid, row, column)) xmasOccurence++;// Down diagonal
                }
            }
        }

        Console.WriteLine(xmasOccurence);
    }

    static bool SearchMas(char[,] grid, int row, int column)
    {
        int count = 0;

        if (grid[row + 1, column + 1] == 'S' && grid[row - 1, column - 1] == 'M') count++;       
        if (grid[row + 1, column + 1] == 'M' && grid[row - 1, column - 1] == 'S') count++;
        if (grid[row - 1, column + 1] == 'S' && grid[row + 1, column - 1] == 'M') count++;
        if (grid[row - 1, column + 1] == 'M' && grid[row + 1, column - 1] == 'S') count++;

        if (count == 2)
            return true;
        else
            return false;

    }
}