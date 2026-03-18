using System;
using System.IO;
using System.Collections.Generic;

namespace InputOutput
{
    public class Search
    {
        public void IndexAndPrint(string directory, string[] keywords)
        {
            if (!Directory.Exists(directory)) return;

            string[] files = Directory.GetFiles(directory, "file.*");
            
            foreach (string word in keywords)
            {
                Console.WriteLine($"\nKey word: [{word}]");
                bool foundAny = false;

                foreach (string path in files)
                {
                    string fileContent = File.ReadAllText(path).ToLower();

                    if (fileContent.Contains(word.ToLower()))
                    {
                        Console.WriteLine($"  - Found in: {Path.GetFileName(path)}");
                        foundAny = true;
                    }
                }
                if (!foundAny) Console.WriteLine("  - Not found");
            }
        }
    }
}