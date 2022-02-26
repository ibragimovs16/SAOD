namespace Stack.Domain;

public class MyStack<T>
{
    private readonly T[] _stack;
    private int _count;

    public MyStack(int length) =>
        _stack = new T[length];

    public bool IsEmpty =>
        _count == 0;

    public void Push(T data)
    {
        if (_count == _stack.Length) throw new StackOverflowException();

        _stack[_count++] = data;
    }

    public T Pop()
    {
        if (IsEmpty) throw new ArgumentOutOfRangeException();
        return _stack[--_count];
    }

    public T Peek()
    {
        if (IsEmpty) throw new ArgumentOutOfRangeException();
        return _stack[_count - 1];
    }

    public void Clear() =>
        _count = 0;

    public override string ToString()
    {
        if (_count == 0) return "[]";

        return _stack[.._count]
            .Reverse()
            .Aggregate("[", (cur, item) => cur + $"{item}, ")[..^2] + "]";
    }
}