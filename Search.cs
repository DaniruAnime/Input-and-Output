using System;
using System.IO;
using System.Collections.Generic;

namespace InputOutput
{
    public class Search
    {
        public void IndexAndPrint(string directory, string[] keywords)
        {
            if (!Directory.Exists(directory)) 
            {
                return;
            }

            string[] files = Directory.GetFiles(directory, "file.*");
            string word;
            string path;
            string fileContent;
            bool foundAny;

            for (int keywordIndex = 0; keywordIndex < keywords.Length; ++keywordIndex)
            {
                word = keywords[keywordIndex];

                Console.WriteLine($"\nKeyword: [{word}]");

                foundAny = false;

                for (int fileIndex = 0; fileIndex < files.Length; ++fileIndex)
                {
                    path = files[fileIndex];
                    fileContent = File.ReadAllText(path).ToLower();

                    if (fileContent.Contains(word.ToLower()))
                    {
                        Console.WriteLine($"  - Found in: {Path.GetFileName(path)}");
                        foundAny = true;
                    }
                }
                
                if (!foundAny)
                {
                    Console.WriteLine("  - Not found");
                }
            }
        }
    }
}