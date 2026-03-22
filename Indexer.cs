using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace InputOutput
{
    public class Indexer
    {
        private Dictionary<string, List<string>> _index = new Dictionary<string, List<string>>();
    
        public void CreateIndex(string directoryPath, string[] keywords)
        {
            _index.Clear();
            
            if (!Directory.Exists(directoryPath))
            {
                return;
            }
    
            for (int wordIndex = 0; wordIndex < keywords.Length; ++wordIndex)
            {
                string word;
                word = keywords[wordIndex];
                _index[word] = new List<string>();
            }
    
            string[] files = Directory.GetFiles(directoryPath, "file.*");
    
            for (int fileIndex = 0; fileIndex < files.Length; ++fileIndex)
            {
                string filePath;
                string content;

                filePath = files[fileIndex];
                content = File.ReadAllText(filePath).ToLower();
    
                for (int keywordIndex = 0; keywordIndex < keywords.Length; ++keywordIndex)
                {
                    string word;

                    word = keywords[keywordIndex];

                    if (content.Contains(word.ToLower()))
                    {
                        _index[word].Add(filePath);
                    }
                }
            }
        }

        public void PrintIndex()
        {
            Console.WriteLine("\n--- Indexer result ---");

            string[] keysArray;

            keysArray = _index.Keys.ToArray();

            for (int keyIndex = 0; keyIndex < keysArray.Length; ++keyIndex)
            {
                string currentKey;

                currentKey = keysArray[keyIndex];
                List<string> fileList = _index[currentKey];

                Console.WriteLine($"Keyword: [{currentKey}]");

                if (fileList.Count == 0) 
                {
                    Console.WriteLine("  - Not found");
                }
                
                for (int fileResultIndex = 0; fileResultIndex < fileList.Count; ++fileResultIndex)
                {
                    string file;

                    file = fileList[fileResultIndex];
                    
                    Console.WriteLine($"  - Found in: {Path.GetFileName(file)}");
                }
            }
        }
    }
}