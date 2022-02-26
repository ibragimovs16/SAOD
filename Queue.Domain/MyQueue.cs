namespace Queue.Domain;

public class MyQueue<T>
{
    private readonly T[] _array;
    private int _count;
    private int _first;
    private int _last;

    public MyQueue(int length) =>
        _array = new T[length];

    public bool IsEmpty => _count == 0; 

    public void Enqueue(T value)
    {
        if (_count >= _array.Length) throw new OverflowException();

        _array[_last] = value;
        _count++;
        _last = (_last + 1) % _array.Length;
    }

    public T Dequeue()
    {
        if (_count == 0) throw new ArgumentOutOfRangeException();
        
        var currentValue = _array[_first];
        _first = (_first + 1) % _array.Length;
        _count--;
        return currentValue;
    }

    public T Peek()
    {
        if (_count == 0) throw new ArgumentOutOfRangeException();

        return _array[_first];
    }
}