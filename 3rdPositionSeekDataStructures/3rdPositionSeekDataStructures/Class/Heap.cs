using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace _3rdPositionSeekDataStructures.Class
{
public class Heap
    {
        // A list to store the heap elements
        private List<int> heap;

        // A constructor to create an empty heap
        public Heap()
        {
            heap = new List<int>();
        }

        // A method to get the size of the heap
        public int Size()
        {
            return heap.Count;
        }

        // A method to check if the heap is empty
        public bool IsEmpty()
        {
            return heap.Count == 0;
        }

        // A method to get the index of the parent of a node at a given index
        private int Parent(int i)
        {
            return (i - 1) / 2;
        }

        // A method to get the index of the left child of a node at a given index
        private int Left(int i)
        {
            return 2 * i + 1;
        }

        // A method to get the index of the right child of a node at a given index
        private int Right(int i)
        {
            return 2 * i + 2;
        }

        // A method to swap two elements in the heap
        private void Swap(int i, int j)
        {
            int temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }

        // A method to heapify up a node at a given index
        private void HeapifyUp(int i)
        {
            // If the node is not the root and its value is greater than its parent
            while (i > 0 && heap[i] > heap[Parent(i)])
            {
                // Swap the node with its parent
                Swap(i, Parent(i));
                // Update the index to the parent's index
                i = Parent(i);
            }
        }

        // A method to heapify down a node at a given index
        private void HeapifyDown(int i)
        {
            // While the node has at least one child
            while (Left(i) < Size())
            {
                // Find the index of the larger child
                int larger = Left(i);
                if (Right(i) < Size() && heap[Right(i)] > heap[larger])
                {
                    larger = Right(i);
                }
                // If the node's value is smaller than its larger child
                if (heap[i] < heap[larger])
                {
                    // Swap the node with its larger child
                    Swap(i, larger);
                    // Update the index to the larger child's index
                    i = larger;
                }
                else
                {
                    // The node is in the right position
                    break;
                }
            }
        }

        // A method to insert a value into the heap
        public void Insert(int value)
        {
            // Add the value to the end of the list
            heap.Add(value);
            // Heapify up the last node
            HeapifyUp(Size() - 1);
        }

        // A method to remove and return the maximum value from the heap
        public int RemoveMax()
        {
            // If the heap is empty, throw an exception
            if (IsEmpty())
            {
                throw new InvalidOperationException("Heap is empty");
            }
            // Store the maximum value
            int max = heap[0];
            // Replace the root with the last element
            heap[0] = heap[Size() - 1];
            // Remove the last element
            heap.RemoveAt(Size() - 1);
            // Heapify down the root
            HeapifyDown(0);
            // Return the maximum value
            return max;
        }

        // A method to return the maximum value from the heap without removing it
        public int PeekMax()
        {
            // If the heap is empty, throw an exception
            if (IsEmpty())
            {
                throw new InvalidOperationException("Heap is empty");
            }
            // Return the root value
            return heap[0];
        }

        // A method to return the third largest element from the heap without removing it
        public int PeekThirdLargest()
        {
            // If the heap has less than three elements, throw an exception
            if (Size() < 3)
            {
                throw new InvalidOperationException("Heap has less than three elements");
            }
            // Create a copy of the heap
            Heap copy = new Heap();
            foreach (int value in heap)
            {
                copy.Insert(value);
            }
            // Remove the first two largest elements from the copy
            copy.RemoveMax();
            copy.RemoveMax();
            // Return the third largest element from the copy
            return copy.PeekMax();
        }
    }
}
