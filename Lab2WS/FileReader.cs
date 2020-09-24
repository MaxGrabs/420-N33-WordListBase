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

            string[] content  = File.ReadAllLines(@filename);
            
           
                return content;

            }
            else
            {
                return null;
            }

        }
    }
}
