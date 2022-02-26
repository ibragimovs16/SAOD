namespace Stack.Domain;

public static class Tasks
{
    // Валидация скобочной последовательности

    public static bool CheckBracketsMethod(string str)
    {
        if (str.Length == 0) return true;
    
        var stack = new MyStack<char>(str.Length);
        var bracketsDict = new Dictionary<char, char>
        {
            ['('] = ')',
            ['['] = ']',
            ['{'] = '}',
            ['<'] = '>'
        };

        foreach (var item in str)
        {
            if (bracketsDict.ContainsKey(item)) stack.Push(item);
            else if (stack.IsEmpty) return false;
            else if (bracketsDict[stack.Peek()] == item) stack.Pop();
            else return false;
        }

        return stack.IsEmpty;
    }
}