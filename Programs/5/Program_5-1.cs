class Program
{
    public static void Main(string[] args)
    {
        // answer
        int answer = 0;

        // Read all lines from rules and input
        string[] rules = File.ReadAllLines("rules.txt");
        string[] orders = File.ReadAllLines("input.txt");

        // Run through every order.
        foreach (string order in orders)
        {
            // Make integer arrays of print orders
            int[] numbers = order.Split(',').Select(int.Parse).ToArray();

            // Check if the rules are upheld
            if (CheckRules(numbers, rules))
            answer += numbers[numbers.Length/2];
        }

        // Journey before destination
        Console.WriteLine(answer);

    }

    public static bool CheckRules(int[] numbers, string[] rules)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = i+1; j < numbers.Length; j++)
            {
                foreach (string rule in rules)
                {
                    if ($"{numbers[j]}|{numbers[i]}" == rule)
                    {
                        // Rules broken
                        return false;
                    }
                }
            }
        }
        // Rules upheld
        return true;
    }
}