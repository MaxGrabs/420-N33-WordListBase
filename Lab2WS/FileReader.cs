using System;
using System.IO;

namespace Lab2WS
{
    class FileReader
    {
        public string[] Read(string filename) 
        {
           // try {
            // Implement this using info from the slides.
            //return array of strings-----delete null obviously
            string [] content  = File.ReadAllLines(@filename);
            
          //  }
           // catch(FileNotFoundException e)
            //{
               //Console.WriteLine(e.Message);
                return content;
           // }

        }
    }
}
