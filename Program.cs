using System;
using System.ComponentModel;

namespace InputOutput
{
    public class Program
    {
        private static TextFile myFile = new TextFile("myDoc.txt", "");
        private static TextEditor editor = new TextEditor(myFile);
        private static Indexer indexer = new Indexer();
        private static Search searcher = new Search();

        public static void Main()
        {
            bool running;

            running = true;

            while (running)
            {
                Console.Clear();
                Console.Write($"""
                    --- Console Editor ---
                    Content: {editor.GetCurrentContent()}
                    ---------------------------
                    1. Enter new text
                    2. Undo
                    3. Save in XML
                    4. Save in Binary
                    5. Save in txt
                    6. Search
                    7. Index Files
                    8. Exit
                    Select options: 
                    """);

                string choise;
                
                choise = Console.ReadLine();

                if (!Enum.TryParse(choise, ignoreCase: true, out menuOption result) ||
                    !Enum.IsDefined(typeof(menuOption), result))
                {
                    Console.WriteLine("Incorrect input. Try again");
                    Console.ReadKey();
                    continue;
                }

                switch (result)
                {
                    case menuOption.EnterString:
                        InputString();
                        break;
                    case menuOption.Undo:
                        editor.Undo();
                        break;
                    case menuOption.SaveXml:
                        myFile.SaveXml("file.xml");
                        break;
                    case menuOption.SaveBinary:
                        myFile.SaveBinary("file.bin");
                        break;
                    case menuOption.SaveTxt:
                        myFile.SaveAsText("file.txt");
                        break;
                    case menuOption.Search:
                        InputSearch();
                        break;
                    case menuOption.Indexer:
                        InputIndexing();
                        break;
                    case menuOption.Exit:
                        running = false;
                        break;
                }
            }
        }
        private static void InputString()
        {
            Console.Write("Enter string: ");
            string input;

            input = Console.ReadLine();

            editor.UpdateContent(input);
        }
        private static void InputSearch()
        {
            Console.Write("Enter keyword to search: ");
            string word;

            word = Console.ReadLine();

            searcher.IndexAndPrint(Environment.CurrentDirectory, new[] { word });

            Console.WriteLine("\nSearch complete. Press any key...");
            Console.ReadKey();
        }
        private static void InputIndexing()
        {
            Console.Write("Enter keywords (space separated): ");
            string[] words;

            words = Console.ReadLine().Split(' ');

            indexer.CreateIndex(Environment.CurrentDirectory, words);
            indexer.PrintIndex();

            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }
    
    public enum menuOption
    {
        EnterString = 1,
        Undo,
        SaveXml,
        SaveBinary,
        SaveTxt,
        Search,
        Indexer,
        Exit
    }
}