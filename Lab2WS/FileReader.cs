using System;
using System.IO;

namespace Lab2WS
{
    class FileReader
    {
        public string[] Read(string filename) 
        {
            // Implement this using info from the slides.
            //checks if file exists, reads file and returns array of each word if not returns null
            if (File.Exists(filename))
            {
                //Console.WriteLine("test2");
            string[] content  = File.ReadAllLines(@filename);
              // testing if file is read  Console.WriteLine(content[0]);

                return content;

            }
            else
            {
                //Console.WriteLine("test3");
                return null;
            }

        }
    }
}
