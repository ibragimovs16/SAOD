using Stack.Domain;

while (true)
{
    var ans = Console.ReadLine();
    if (ans is null) break;
    
    Console.WriteLine(Tasks.CheckBracketsMethod(ans));
}