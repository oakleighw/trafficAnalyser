# Traffic Analyser
Level 1 C# Assignment which reads from a text file and uses various sort and search algorithms

# Design for Application
## Application Description
The user is presented with an initial menu showing data text files within the bin/debug folder of the project. If an incorrect input(letters/blank/spaces) is given, or a number outside the menu scope, the program closes gracefully with a message.

The user is asked if they would like to order the data in ascending or descending order, only taking ‘a’ or ‘d’ values, otherwise the user is asked again.

The Program lists every 10th value for data files <= 256 lines or every 50th value for data files over that limit.

“Exact Search” searches the data for the location/locations of the prompt, otherwise states “data not found”. “Similar search” Searches for the location of the prompt, however, gives the closest result if it is not found.

The user is then provided with two menus; choosing two data sets to merge. Following that they are asked for the order (ascending/descending). If the new merged data set is equal or less than 512 in length, every 10th element is displayed, otherwise every 50th is.

The searches occur again, similar in fashion to the unique data sets. The User finally receives a farewell, followed by a prompt to close the program.

A count counts the steps and displays the result to the user after each algorithm has run.

## Implementation of Tasks
1.	The Menu.GreetChoose() method takes in directory files ending with ‘.txt’(DirectoryRead.GetFiles()). The file chosen is read into an array through Tarray.ArrayRead(). ‘Menu’ is the class that holds all the methods used in providing a user interface.
2.	If the array is 256 lines in length, MySort.bubbleSort() sorts the array into ascending order, while a manipulation of bubble-sort (Reverse.BubbleReverse()) converts to descending. Every 10th value is displayed through the Menu.PrintNthValue() method (which takes in the array, order for display purposes and the specified increment,10 in this case).
3.	 A linear search method (“Exact Search”) is used to find the user’s prompt and display the location to the user. If the value cannot be found, an error is thrown and is caught by giving the user a notification of this.
4.	Binary search is used to display values in “Similar Search”. This shows the locations where the user’s value is in the data set otherwise displays the nearest value and its location. Multiple locations can be achieved in my linear and binary search functions by adding each location to a dynamic list.
5.	The application can initially choose data sets of size 2048 and above. A merge-sort method is used for ascending and an altered one for descending. Every 50th value is displayed this time through the printNthValue method with ‘50’ as a parameter. Searching works the same as the smaller data sets.
6.	A Merger section of the application occurs nearer the end of the program. The user can choose ANY two values to merge, including two 256 files. An Insertion-Sort method is used to sort in ascending order and a variation for descending. Searching occurs the same.
7.	The merger section can take two 2048 length data sets if chosen by user. However, as the resulting array is >512 in size, HeapSort is used for ascending order, whilst a min-heap version is used for descending.	

# Description of Algorithmic choices
## Justification & evaluation of Searching & Sorting Algorithms

**Bubble-Sort**: Bubble-Sort was very easy to implement and had the least amount of code compared to the other algorithms I have used. It was easy to understand how the code worked, such that I could change the formula to sort an array in descending order (swap the biggest element out of each two to the left as opposed to the right). I used it to sort the smaller arrays (of length 256) as the algorithm works best with smaller arrays. The best case would invoke an O(n) in time complexity, however O(n^2) time complexity if I let the algorithm work on the larger data sets. Memory wise, however, the space complexity in the worst case would be O(1), which is not a problem.

**Insertion-Sort**: Similarly, insertion sort was easy to implement and did not include much code. I used it to sort merged arrays of length 512 or less. Insertion sort would have been impractical to use on the larger merged arrays because of the number of loops that would have arose. The best time complexity of the algorithm is O(n) as opposed to O(n^2) if I let it work on larger data (worst-case). The space complexity for the worst case only sits at O(1) though.

**Merge-Sort**: Merge-Sort was more difficult to implement, and it contained much more code than the likes of bubble and insertion-sort(O(n) for worst space complexity). It consists of three different methods that are used together to output the sorted array. It was used on the large single data sets (of length 2048) with great success (having even less loops than bubble-Sort on 256-length data sets). It was difficult to find how to change the formula to sort in descending order. However, on further study I was able to change the ‘if’ statement within the merging method to check if the left was less than the right and swap them. The O(n log(n)) nature of worst case time complexity means that it works well with larger data sets without compromising the time taken for the algorithm to run.

**Heap-Sort**: Heap-Sort was the most interesting to implement as it created ‘tree’ structures to sort the array. On further understanding I changed the algorithm such that instead of creating a ‘max heap’, the algorithm created a ‘min heap’ for descending order. This means the tree structures created had the smallest node sorted into the root, and pulled the larger ‘leaf’ nodes into the start of the array(as opposed to larger roots and smaller leaf nodes for ascending order). Subtrees are created recursively. Even though this algorithm was partially recursive in nature, it was still more efficient on the larger merged arrays than bubble and insertion sort were on the smaller ones. This is due to the O(n log(n)) worst time complexity of the algorithm, similar to that of Merge-Sort(Kamboj 2018). Time taken for big sets of data will be more reasonable. The bonus is the worst case for space complexity is O(1) so it takes up even less memory to run for big data as opposed to Merge-Sort.

**Linear Search**: I used a linear search algorithm to find exact matches for the key. It is one of the most basic algorithms as it loops through the whole list to find the match. From this it was very easy to implement and had little code. Unfortunately, linear search loops increase for every line of data added (worst case O(n) time complexity) so would be impractical for larger data sets that are greater than those in this assessment. However as it is an iterative function the worst space complexity is only O(1).

**Binary-search**: Binary search was great to use for finding the nearest value if the user’s key was not in the data set. Because of the divide-and-conquer nature of the algorithm, the search happens in halves, picking only the half with the numbers nearer to the key each time. That way, when the algorithm reaches the area it ‘thinks’ the value would be, the nearest value can be printed out to the user. The only downside to the use of this algorithm is that unlike linear-search, it must be altered for a descending-ordered array. Thereby the algorithm can check the ‘lower’ side if the middle value is greater than that of the key. Fortunately on evaluation, the steps taken for binary search are much lower than that of linear search as the data size increases, as worse case for the algorithm is O(log n)(Lambrou 2020). Worst case for space complexity is only O(1) for the algorithm so it makes it a good choice to use for searching.

# Table for steps(count)



# References
## Learning
•	Amjad K. 2017. Algorithm-Searching-Binary Search-Problem Solving-Optimum Solution. [ONLINE] Available at: https://social.technet.microsoft.com/wiki/contents/articles/50945.algorithm-searching-binary-search-problem-solving-optimum-solution.aspx. [Accessed 2 March 2020].

•	Danziger, P. 2010 Big O notation. [ONLINE] Available at: https://www.cs.ryerson.ca/~mth210/Handouts/PD/bigO.pdf. [Accessed 2 March 2020].

•	GeeksForGeeks. 2020. Bubble Sort. [ONLINE] Available at: https://www.geeksforgeeks.org/bubble-sort/. [Accessed 3 March 2020].

•	Kamboj, R. 2018. Time Complexities Reference Charts. [ONLINE] Available at : https://medium.com/@rrkk.hd/time-complexities-reference-charts-117ab399356a. [Accessed 2 March 2020].

•	Lambrou, T. 2020. Lecture 5 – Searching & Sorting, lecture notes, CMP1124M Algorithms and Complexity, University of Lincoln, delivered 17 February 2020.

•	SoloLearn. 2020. Development Essentials: Algorithms ver.3.1.2 SoloLearn[APPLICATION]. [Accessed 6 March 2020].

## Code
•	(Merge-Sort) University of Lincoln, Computer Science: Workshop .2020. CMP1124M – Algorithms and Complexity, Workshop 5 – Sorting, 3.

•	(LinearSearch) GeeksForGeeks. 2020. Linear Search. [ONLINE] Available at: https://www.geeksforgeeks.org/linear-search/. [Accessed 2 March 2020].

•	(InsertionSort)TutorialsPoint. 2020. Insertion Sort. [ONLINE] Available at: https://www.tutorialspoint.com/insertion-sort-in-chash. [Accessed 3 March 2020].

•	(HeapSort) University of Lincoln, Computer Science: Workshop. 2020. CMP1124M - Algorithms and Complexity, Workshop 6 – Quicksort and Heapsort, 2-3.

•	(BubbleSort)TutorialsPoint. 2018. Bubble Sort. [ONLINE] Available at: https://www.tutorialspoint.com/Bubble-Sort-program-in-Chash. [Accessed 2 March 2020].

•	(BinarySearch) Tripathi P.(C# Corner). 2017. Binary Search Implementation Using C#. [ONLINE] Available at : https://www.c-sharpcorner.com/blogs/binary-search-implementation-using-c-sharp1. [Accessed 2 March 2020].

