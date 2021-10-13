using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficAnalysis
{
    class Menu
    {   //this class contains all the UI of the console
        //greets and returns chosen data value. Takes in directory list made in DirectoryRead Class.
        public string GreetChoose(List<string> directory)
        {//pick which array to be analysed
            Console.WriteLine("Welcome to the Traffic Analyser");
            Console.WriteLine("Which data set would you like to analyse?");
            //n is bullet point e.g. '1.'
            int n = 1;
            foreach(string file in directory)
            {
                Console.WriteLine($"{n}. {file}");
                n++;
            }
            //get input as number in menu
            int input = 0;
            try
            {
                input = Int32.Parse(Console.ReadLine());
            }
            catch(Exception)
            {
                Console.WriteLine("That number wasn't one of the options, the program will now close");//closes program gracefully if character/space entered
                endProgram();
            }
            //assign input to it's value in directory array
            string data = "default";
            try
            {
                data = directory[input - 1];//converts choice to directory array number
            }
            catch(Exception)
            {
                Console.WriteLine("That number wasn't one of the options, the program will now close");//closes program gracefully if not one of the numbered options is entered
                endProgram();
            }
            return data;
            
        }
        private int IntChoose()//used for searcher UI menu.searcher, picks a number to search
        {           
            Console.WriteLine("Please Enter a number to search, we will try to see where it exists in the current ordered array");
            int choice = 0;
            try
            {
                choice = (Int32.Parse(Console.ReadLine()));//converts string input to int to search
            }
            catch(Exception)
            {
                Console.WriteLine("That is not a valid number, the program will now close");//closes program gracefully if a number is not entered
                endProgram();
            }
            return choice;
        }
        public string WhichOrder()//gets order(ascending/descending) from input
        {
            Console.WriteLine("Would you like to Sort in ascending or descending order? (a/d)");
            string input = Console.ReadLine();
            while (true)
            {
                if (input == "a" || input == "d")
                    return input;
                else
                {
                    Console.WriteLine("Sorry, that isn't an option - please type 'a' for ascending or 'd' for descending");
                    input = Console.ReadLine();//if a or d isn't entered, program will ask user again to enter correct input
                }
            }
        }
        //UI for merging two arrays in directory
        public string Merger(List<string> directory, string number)//number relates to whether it's the first/second array etc.
        {
            Console.WriteLine($"==========\nPlease choose {number} file to merge\n==========");
            int n = 1;
            foreach (string file in directory)
            {
                Console.WriteLine($"{n}. {file}");//creates menu of options similar to greetChoose()
                n++;
            }
            //get input as number in menu
            int input = 0;
            try
            {
                input = Int32.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("That number wasn't one of the options, the program will now close");
                endProgram();//ends program if number not entered
            }
            //assign input to it's value in directory array
            string data = "default";
            try
            {
                data = directory[input - 1];
            }
            catch (Exception)
            {
                Console.WriteLine("That number wasn't one of the options, the program will now close");
                endProgram();//ends program if number not one of options given
            }
            return data;
        }
        //program termination with polite message
        public void endProgram()
        {
            Console.WriteLine("Thank you for using Traffic Analyser.\nPress any key to exit");
            Console.ReadLine();
            System.Environment.Exit(0);
        }
        //printing values of array (e.g every 10th..)
        public void printNthValue(int[] array, string order,int increment)
        {
            Console.WriteLine($"Here is every {increment.ToString()}th value of this data in {order} order:");
            for(int value = (increment-1); value <= array.Length; value+=increment)
            {
                Console.WriteLine(array[value].ToString());
            }
        }
        //searching UI, used for both standard data and merged data in Program.cs
        public void searcher(string order,int[] fileArray)
        {
            MySearch mySearch = new MySearch();//using search class
            //search, error if not there
            Console.WriteLine("==========Exact Search==========");
            int choice = IntChoose();//chooses int to search
            string result = mySearch.LinSearch(fileArray, fileArray.Length - 1, choice);//linear search
            if (result == "none")//search item not found
            {
                try
                {
                    throw new Exception("ItemNotFound");
                }
                catch (Exception)
                {
                    Console.WriteLine("That data is not in this array");//creates error if not there, handled by telling user item not found
                }
            }
            else
            {
                Console.WriteLine(result);//result returns sentence if its there, see LinSearch in mySearch class.
            }
            //search, near values if not there
            Console.WriteLine("==========Similar Search==========\nSimilar Values if choice not in array\n==================================");//'===' makes console window easier to read
            choice = IntChoose();//overwrite choice with new choice
            if (order == "a")
            {
                Console.WriteLine(mySearch.BinarySearch(fileArray, choice));//binary search for item 'choice' in array 'fileArray'
            }
            if (order == "d")
            {
                Console.WriteLine(mySearch.revBinarySearch(fileArray, choice));//binary search doesn't work for descending unless tweaked- see MySearch.BinarySearch               
            }

        }

    }   

}
