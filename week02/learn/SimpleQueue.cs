public class SimpleQueue {
    public static void Run() {
        // Test 1
        Console.WriteLine("Test 1");
        var queue = new SimpleQueue();
        queue.Enqueue(100);
        var value = queue.Dequeue();
        Console.WriteLine(value);

        Console.WriteLine("------------");

        // Test 2
        Console.WriteLine("Test 2");
        queue = new SimpleQueue();
        queue.Enqueue(200);
        queue.Enqueue(300);
        queue.Enqueue(400);
        Console.WriteLine(queue.Dequeue());
        Console.WriteLine(queue.Dequeue());
        Console.WriteLine(queue.Dequeue());

        Console.WriteLine("------------");

        // Test 3
        Console.WriteLine("Test 3");
        queue = new SimpleQueue();
        try {
            queue.Dequeue();
            Console.WriteLine("Oops ... This shouldn't have worked.");
        }
        catch (IndexOutOfRangeException) {
            Console.WriteLine("I got the exception as expected.");
        }
    }

    private readonly List<int> _queue = new();

    private void Enqueue(int value) {
        // FIX 1: Add to the back of the queue
        _queue.Add(value);
    }

    private int Dequeue() {
        // FIX 2: Proper empty check
        if (_queue.Count == 0)
            throw new IndexOutOfRangeException();

        // FIX 3: Remove from the front of the queue
        var value = _queue[0];
        _queue.RemoveAt(0);
        return value;
    }
}