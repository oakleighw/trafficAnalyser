using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficAnalysis
{
    class MySearch
    {   //counts for assessing complexity
        public int linSearchCount = 0;
        public int binSearchCount = 0;
        public int rBinSearchCount = 0;
        //basic linear search for small arrays

        public string LinSearch(int[] arr, int n, int key)
        {//add any locations to list
            List<string> locations = new List<string>();
            int i;
            for (i = 0; i <= n; i++)//loops through ints in list
            {
                if (arr[i] == key)//picks ones that match key
                    locations.Add((i + 1).ToString()); //adding +1 to location to show 'n'th location as opposed to index number (which starts at 0)
                linSearchCount++;
            }
            Console.WriteLine($"linear search count is {linSearchCount.ToString()}");
            if (locations.Count > 0)//return locations if found
                return $"The data is at location(s): {string.Join(",", locations)}";
            else
                return "none";  //return none if not located             
        }
        public string BinarySearch(int[] arr,int key)
        {
            List<string> locations = new List<string>();
            int start = 0;
            int mid = 0;
            int end = arr.Length - 1;
            while (start <= end)
            {//divide array in half
                mid = start + (end - start) / 2;
                if (key > arr[mid])//if key is bigger than middle- focus on end array (the one with bigger values)
                    start = mid + 1;
                else
                    end = mid - 1;//else focus on start array
                if (arr[mid] == key)//check if middle is key
                    locations.Add((mid+1).ToString()); //adding +1 to location to show 'n'th location as opposed to index number (which starts at 0)
                binSearchCount++;
            }
            Console.WriteLine($"bin search count is {binSearchCount.ToString()}");
            if (locations.Count == 0)//return locations if found
                return $"Data not in Array. The nearest number is: {arr[mid].ToString()} at location {(mid + 1).ToString()}";

            else//return last value where binary search expected key to be(last midpoint)
                return $"The data is at location(s): {string.Join(",", locations)}";
        }
        public string revBinarySearch(int[] arr,int key)
        {
            List<string> locations = new List<string>();
            int start = 0;
            int mid = 0;
            int end = arr.Length - 1;
            while (start <= end)
            {
                mid = start + (end - start) / 2;
                //changed to reflect descending order(is key lower than middle value)
                if (key < arr[mid])
                    start = mid + 1;
                else
                    end = mid - 1;
                if (arr[mid] == key)
                    locations.Add((mid + 1).ToString()); //adding +1 to location to show 'n'th location as opposed to index number (which starts at 0)
                rBinSearchCount++;
            }
            Console.WriteLine($"Reverse Binary Search Count is {rBinSearchCount.ToString()}");
            if (locations.Count == 0)//return locations if found
                return $"Data not in Array. The nearest number is: {arr[mid].ToString()} at location {(mid + 1).ToString()}";

            else
                return $"The data is at location(s): {string.Join(",", locations)}";
        }
    }
}
