using Queue.Domain;

while (true)
{
    bool isCorrect;
    int n;

    do
    {
        Console.Write("N: ");
        isCorrect = int.TryParse(Console.ReadLine(), out n);
        if (!isCorrect) Console.WriteLine("Incorrect value.");
        else switch (n)
        {
            case -1:
                return;
            case < 0:
                Console.WriteLine("The value cannot be less than 0.");
                isCorrect = false;
                break;
        }
        
    } while (!isCorrect);

    Console.Write("Primary numbers, separated by commas: ");
    var primaryNumbersRaw = Console.ReadLine();
    if (primaryNumbersRaw is null) Console.WriteLine("Specify at least 1 prime number");
    else
    {
        try
        {
            var primaryNumbers = primaryNumbersRaw
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(string.Join(", ", Tasks.Task(n, primaryNumbers)));
        }
        catch (FormatException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}