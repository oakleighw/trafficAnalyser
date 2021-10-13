using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficAnalysis
{
    class Reverse
    {//reverse (descending) ordered sorts. I've highlighted the changed lines in comments as DIFFERENCE (from ascending order)
    //counts for complexity analysis
        public int mergeCRev = 0;
        public int minHeapCount=0;
        public int[] BubbleReverse(int[] arr)
        {
            int count = 0;
            int temp;
            for (int j = 0; j <= arr.Length - 2; j++)
            {
                for (int i = 0; i <= arr.Length - 2; i++)
                {
                    if (arr[i] < arr[i + 1])//DIFFERENCE - if left side is smaller, swap
                    {
                        temp = arr[i + 1];
                        arr[i + 1] = arr[i];
                        arr[i] = temp;
                    }
                    count++;
                }
            }
            Console.WriteLine($"bubbleSort reverse count is {count.ToString()}");
            return arr;
        }
        private void Merge(int[] data, int[] temp, int low, int middle, int high)
        {
            int ri = low;
            int ti = low;
            int di = middle;
            while (ti < middle && di <= high)
            {
                if (data[di] > temp[ti])//DIFFERENCE, if left side is smaller
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
        //Merge recursive part
        private void MergeSortRecursive(int[] data, int[] temp, int low, int high)
        {
            int n = high - low + 1;
            int middle = low + n / 2;
            int i;

            if (n < 2) return;
            for (i = low; i < middle; i++)
            {
                temp[i] = data[i];
                mergeCRev++;
            }
            MergeSortRecursive(temp, data, low, middle - 1);
            MergeSortRecursive(data, temp, middle, high);
            Merge(data, temp, low, middle, high);
        }
        public void RevMergeSort(int[] data)
        {
            int[] temp = new int[data.Length];
            MergeSortRecursive(data, temp, 0, data.Length - 1);
            Console.WriteLine($"MergeSort reverse count is {mergeCRev.ToString()}");
        }
        public int[] RevInSort(int[] arr)
        {//function for insertionsort
            int j, i, flag, val;
            int count = 0;
            for (i = 1; i < arr.Length; i++)
            {
                val = arr[i];
                flag = 0;
                for (j = i - 1; j >= 0 && flag != 1;)
                {
                    if (val > arr[j])//DIFFERENCE - if value is bigger, move closer to start of array
                    {
                        arr[j + 1] = arr[j];
                        j--;
                        arr[j + 1] = val;
                    }
                    else flag = 1;
                  count++;
                }
            }
            Console.WriteLine($"insertionSort reverse count is {count.ToString()}");
            return arr;
        }
        public void revHeapSort(int[] Heap)
        {
            int HeapSize = Heap.Length;
            int i;
            for (i = (HeapSize - 1) / 2; i >= 0; i--)
            {//use min heap instead of max for descending -DIFFERENCE
                Min_Heapify(Heap, HeapSize, i);
            }
            for (i = Heap.Length - 1; i > 0; i--)
            {
                int temp = Heap[i];
                Heap[i] = Heap[0];
                Heap[0] = temp;

                HeapSize--;
                Min_Heapify(Heap, HeapSize, 0);
            }
            Console.WriteLine($"min_heap count is {minHeapCount.ToString()}");
        }
        private void Min_Heapify(int[] Heap, int HeapSize, int Index)
        {//as opposed to Max_Heap, this time the smallest is the root
            int Left = (Index + 1) * 2 - 1;
            int Right = (Index + 1) * 2;
            int smallest = Index;

            if (Left < HeapSize && Heap[Left] < Heap[smallest])
            {
                smallest = Left;
            }
            else
            {
                smallest = Index;
            }
            if (Right < HeapSize && Heap[Right] < Heap[smallest])
            {
                smallest = Right;
            }
            if (smallest != Index)
            {
                int temp = Heap[Index];
                Heap[Index] = Heap[smallest];
                Heap[smallest] = temp;
                Min_Heapify(Heap, HeapSize, smallest);
            }
            minHeapCount++;
        }
    }
}
