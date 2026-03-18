using System;
using System.Collections.Generic;
using System.IO;

namespace InputOutput
{
    public class Indexer
    {
        private Dictionary<string, List<string>> _index = new Dictionary<string, List<string>>();
    
        public void CreateIndex(string directoryPath, string[] keywords)
        {
            _index.Clear();
            
            if (!Directory.Exists(directoryPath)) return;
    
            foreach (string word in keywords)
            {
                _index[word] = new List<string>();
            }
    
            string[] files = Directory.GetFiles(directoryPath, "*.txt");
    
            foreach (string filePath in files)
            {
                string content = File.ReadAllText(filePath).ToLower();
    
                foreach (string word in keywords)
                {
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
            foreach (var entry in _index)
            {
                Console.WriteLine($"Keyword '{entry.Key}' found in files:");
                if (entry.Value.Count == 0) Console.WriteLine("  - not found");
                
                foreach (string file in entry.Value)
                {
                    Console.WriteLine($"  - {Path.GetFileName(file)}");
                }
            }
        }
    }
}