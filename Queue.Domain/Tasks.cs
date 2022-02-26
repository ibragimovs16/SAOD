namespace Queue.Domain;

public static class Tasks
{
    // Вывести в порядке возрастания n целых чисел, которые при разложении на простые сомножители давали бы
    // только исходные простые числа
    
    // 1 этап - создать столько очередей, сколько у нас простых чисел и положить в него это простое число
    // 2 этап - цикл на n итераций
    // 1) Ищем минимальную голову очереди
    // 2) Извлекаем из всех очередей это значение и кладем его в ответ
    // 3) это значение умножаем на исходные простые числа и запихиваем в соответствующие очереди

    public static IEnumerable<int> Task(int n, int[] primaryNumbers)
    {
        var queuesArray = new MyQueue<int>[primaryNumbers.Length];
        
        for (var i = 0; i < primaryNumbers.Length; i++)
        {
            queuesArray[i] = new MyQueue<int>(n * 100);
            queuesArray[i].Enqueue(primaryNumbers[i]);
        }

        var result = new List<int>();

        for (var i = 0; i < n; i++)
        {
            var min = queuesArray.Min(q => q.Peek());

            foreach (var currentQueue in queuesArray)
            {
                if (currentQueue.IsEmpty) continue;
                if (currentQueue.Peek() == min) currentQueue.Dequeue();
            }

            for (var j = 0; j < queuesArray.Length; j++)
                queuesArray[j].Enqueue(min * primaryNumbers[j]);
            
            result.Add(min);
        }

        return result;
    }
}