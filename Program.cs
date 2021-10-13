using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            //instantiating objects to use methods
            TArray tar = new TArray();
            Reverse rev = new Reverse();
            DirectoryRead dr = new DirectoryRead();
            Menu menu = new Menu();
            MySort mySort = new MySort();
            MySearch mySearch = new MySearch();

            //Choose file to analyse
            string file = menu.GreetChoose(dr.GetFiles());
            //read file into an int[] array
            int[] fileArray = tar.ArrayRead(file);

            //i've now got an array that has been chosen

            string order = menu.WhichOrder();//determines ascending or descending
            //if length of array is <= 256, BubbleSort
            if (fileArray.Length <= 256)
            {
                if (order == "a")
                {
                    mySort.BubbleSort(fileArray);
                    menu.printNthValue(fileArray, "ascending", 10);//write 10th values to screen
                }
                if (order == "d")
                {
                    rev.BubbleReverse(fileArray);//reverse bubblesort for descending
                    menu.printNthValue(fileArray, "descending", 10);
                }
            }
            else//else (higher) mergesort
            {
                if (order == "a")
                {
                    mySort.MergeSort(fileArray);
                    menu.printNthValue(fileArray, "ascending", 50);//write 50th values to screen
                }
                if (order == "d")
                {
                    rev.RevMergeSort(fileArray);//reverse mergesort for descending
                    menu.printNthValue(fileArray, "descending", 50);
                }
            }
            

            menu.searcher(order, fileArray); //outputs linear search result(found/error) and binary search result(found/ nearest location) See Menu.searcher()

            //merging section

            Console.WriteLine("==========Merger==========");
            //get names of two files you want to merge (includes ability to merge ANY two data files, including those in tasks 6 and 7)
            string mergeFile1 = menu.Merger(dr.GetFiles(),"first");//creates UI that shows text files in directory, and allows to choose first
            string mergeFile2 = menu.Merger(dr.GetFiles(),"second");
            Console.WriteLine($"You have selected to merge {mergeFile1} and {mergeFile2}");//confirms files chosen

            //convert both files into arrays
            int[] fileArray1 = tar.ArrayRead(mergeFile1);
            int[] fileArray2 = tar.ArrayRead(mergeFile2);

            //Add them to eachother as a new data array 'mergedArray'
            int[] mergedArray = new int[fileArray1.Length + fileArray2.Length];
            Array.Copy(fileArray1, mergedArray, fileArray1.Length);
            Array.Copy(fileArray2,0,mergedArray, fileArray1.Length, fileArray2.Length);

            //ask order(ascending/descending)
            order = menu.WhichOrder();
            if (mergedArray.Length <= 512)//if merged array is small (i.e only contains 2 data arrays of 256 length each or less) use insertionSort
            {
                if (order == "a")
                {
                    mySort.InsertionSort(mergedArray);
                    menu.printNthValue(mergedArray, "ascending", 10);//show every 10th element after insertionSort.
                }
                if (order == "d")
                {
                    rev.RevInSort(mergedArray);
                    menu.printNthValue(mergedArray, "descending", 10);//descending version
                }                
            }
            else //heapsort if higher than small merge (length >512)
            {
                if(order == "a")
                {//heapsort
                    mySort.HeapSort(mergedArray);
                    menu.printNthValue(mergedArray, "ascending", 50);//print every 50th element
                }
                if (order == "d")
                {
                    rev.revHeapSort(mergedArray);
                    menu.printNthValue(mergedArray, "descending", 50);//descending version
                }
            }

            //searches on merged array(linear & binary-- same as FileArray)

            menu.searcher(order, mergedArray);

            //exit program gracefully
            menu.endProgram();
        }
    }
}
