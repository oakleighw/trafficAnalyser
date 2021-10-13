using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TrafficAnalysis 
{
    class TArray
    {//reading text files into arrays
        public int[] ArrayRead(string textFile)
        {
            string[] arrText = File.ReadAllLines($@"{textFile}", Encoding.UTF8);//reads textfile and adds lines to array
            int[] intArrText = Array.ConvertAll(arrText, int.Parse);//converts string lines to numbers 'int's
            return intArrText;
        }
    }
}
