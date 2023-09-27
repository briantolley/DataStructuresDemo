using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rdPositionSeekDataStructures.Class
{
    public class Queue
    {
        // A sorted set to store the three largest elements
        private SortedSet<int> set;

        // A constructor to create an empty queue
        public Queue()
        {
            set = new SortedSet<int>();
        }

        // A method to enqueue an element into the queue
        public void Enqueue(int value)
        {
            // Add the value to the sorted set
            set.Add(value);

            // If the size of the set exceeds three
            if (set.Count > 3)
            {
                // Remove the smallest element from the set
                set.Remove(set.Min);
            }
        }

        // A method to dequeue and return an element from the queue
        public int Dequeue()
        {
            // If the queue is empty, throw an exception
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty");
            }

            // Store the smallest element in the set
            int value = set.Min;

            // Remove the smallest element from the set
            set.Remove(value);

            // Return the value
            return value;
        }

        // A method to check if the queue is empty
        public bool IsEmpty()
        {
            return set.Count == 0;
        }

        // A method to return the third largest element in the queue without removing it
        public int PeekThirdLargest()
        {
            // If the queue has less than three elements, throw an exception
            if (set.Count < 3)
            {
                throw new InvalidOperationException("Queue has less than three elements");
            }

            // Return the smallest element in the set
            return set.Min;
        }
    }
}
