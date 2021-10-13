using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficAnalysis
{
    class MySort
    {
        //counts for complexity analysis of algorithms that can't have them internally(due to recursion resetting them to 0)
        public int maxHeapCount = 0;
        public int mergeCount = 0;
        //function for bubblesort
        public int[] BubbleSort(int[] arr)
        {
            int count = 0;//count for complexity analysis
            int temp;
            for (int j = 0;j <= arr.Length - 2; j++)
            {
                for (int i = 0; i <= arr.Length -2; i++)//focuses on two elements at a time
                {
                    if(arr[i] > arr[i + 1])//if left element is bigger than right
                    {//swap them such that bigger element is always to the right
                        temp = arr[i + 1];
                        arr[i + 1] = arr[i];
                        arr[i] = temp;

                    }
                    count++;
                }
            }
            Console.WriteLine($"bubbleSort count is {count.ToString()}");//display count
            return arr;//return sorted array
        }
        public int[] InsertionSort(int[] arr)
        {//function for insertionsort
            int j, i, flag, val;
            int count = 0;//count for complexity analysis
            for (i =1;i < arr.Length;  i++)
            {//store element whose left side is checked for its correct position
                val = arr[i];
                flag = 0;//the pointer that moves bigger numbers to front
                for (j = i-1; j>=0 && flag !=1;)
                {//check whether element on right is bigger than left
                    if (val < arr[j])//if 
                    {//if so move right element to the left
                        arr[j + 1] = arr[j];
                        j--;
                        arr[j + 1] = val;
                    }
                    else flag = 1;
                    count++;
                }
            }
            Console.WriteLine($"insertionSort count is {count.ToString()}");
            return arr;
        }
        //merging algorithm, combines sorted arrays. (1 of 3 merge functions)
        private void Merge(int[] data, int[] temp, int low, int middle, int high)
        {
            int ri = low;
            int ti = low;
            int di = middle;
            while(ti < middle && di <= high)
            {//adds parts together based on how large each is
                if (data[di] < temp[ti])
                {
                    data[ri++] = data[di++];
                }
                else
                {
                    data[ri++] = temp[ti++];
                }
            }
            while (ti < middle)
            {
                data[ri++] = temp[ti++];
            }
        }
        //Merge recursive part, sorts each individual division(2 of 3)
        private void MergeSortRecursive(int[] data, int[] temp, int low, int high)
        {
            int n = high - low + 1;
            int middle = low + n / 2;
            int i;
            

            if (n < 2) return;//when each individual division is "2 elements each to compare"
            for (i=low; i<middle; i++)
            {
                temp[i] = data[i];
                mergeCount++;
            }
            MergeSortRecursive(temp, data, low, middle - 1);
            MergeSortRecursive(data, temp, middle, high);
            Merge(data, temp, low, middle, high);
            
        }
        //merges two functions together to form new array(3 of 3)
        public void MergeSort(int[] data)
        {
            
            int[] temp = new int[data.Length];
            MergeSortRecursive(data, temp, 0, data.Length - 1);
            Console.WriteLine($"MergeSort count is {mergeCount.ToString()}");
        }
        //heapsort
        public void HeapSort(int[] Heap)
        {//adds leaves from each max_heap to array such that they are in order
            int HeapSize = Heap.Length;
            int i;
            for(i = (HeapSize - 1)/2;i >= 0; i--)
            {//build heap
                Max_Heapify(Heap, HeapSize, i);
            }
            for(i = Heap.Length - 1; i > 0; i --)//extract element from heap
            {//move current root to end
                int temp = Heap[i];
                Heap[i] = Heap[0];
                Heap[0] = temp;

                HeapSize--;//call max_heapify on reduced heap
                Max_Heapify(Heap, HeapSize, 0);
            }
            Console.WriteLine($"max_heap count is {maxHeapCount.ToString()}");
        }
        private void Max_Heapify(int[] Heap, int HeapSize, int Index)
        {//sorts heap tree by having highest number as root node and lower numbers as leaf nodes
            int Left = (Index + 1) * 2 - 1;
            int Right = (Index + 1) * 2;
            int largest = 0;//largest is root in max heaps

            if(Left < HeapSize && Heap[Left] > Heap[Index])
            {//if left child larger than root
                largest = Left;
            }
            else
            {
                largest = Index;
            }
            if(Right < HeapSize && Heap[Right] > Heap[largest])
            {//if right child larger than largest 'so far'
                largest = Right;
            }
            if (largest != Index)
            {//if largest is not a root
                int temp = Heap[Index];
                Heap[Index] = Heap[largest];
                Heap[largest] = temp;
                //recursive- keeps making max heaps out of values left(sub-trees) until no nodes left
                Max_Heapify(Heap, HeapSize, largest);
            }
            maxHeapCount++;
        }
    }   
}
