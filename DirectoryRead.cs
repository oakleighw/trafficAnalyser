using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficAnalysis
{
    class DirectoryRead
    {//this class reads bin/debug for data txt files, and adds them to a list
        public List<String> GetFiles()
        {   //new empty list to add text files to
            List<string> TFiles = new List<string>();
            //read directory into array
            string[] arr = System.IO.Directory.GetFiles(".");
            //check if .txt files in directory
            foreach (string i in arr)
            {
                if(i.EndsWith(".txt"))//filters out text files
                {//add to list if .txt, and removes "./"
                   string a = i.Remove(0,2);
                   TFiles.Add(a);
                }
            }
            return TFiles;
        }
    }
}
