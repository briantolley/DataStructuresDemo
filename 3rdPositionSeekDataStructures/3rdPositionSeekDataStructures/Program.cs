using _3rdPositionSeekDataStructures.Class;
using System.Collections.Generic;

static void Heap(int[] numbers)
{
    DateTime start = DateTime.Now;
    Heap heap = new Heap();
    TimeSpan TotalRunTime;
    int ThirdLargestValue;

    foreach (int number in numbers)
    {
        heap.Insert(number);
    }
    ThirdLargestValue = heap.PeekThirdLargest();
    TotalRunTime = DateTime.Now.Subtract(start);

    Console.WriteLine("Using HEAP, 3rd largest is : " + ThirdLargestValue + " and total time in milliseconds was " + TotalRunTime.Milliseconds.ToString());
}
static void Queue(int[] numbers)
{
    DateTime start = DateTime.Now;
    Queue queue = new Queue();
    TimeSpan TotalRunTime;
    int ThirdLargestValue;

    foreach (int number in numbers)
    {
        queue.Enqueue(number);
    }
    ThirdLargestValue = queue.PeekThirdLargest();
    TotalRunTime = DateTime.Now.Subtract(start);

    Console.WriteLine("Using QUEUE, 3rd largest is : " + ThirdLargestValue + " and total time in milliseconds was " + TotalRunTime.Milliseconds.ToString());
}

int[] datatosort = { 70, 80, 90, 100, 110, 120, 130, 10, 20, 30, 40, 50, 60, 140, 150, 160, 170, 180, 190, 200};
Heap(datatosort);
Queue(datatosort);


