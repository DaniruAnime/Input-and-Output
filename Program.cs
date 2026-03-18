using System;

namespace InputOutput
{
    public class Program
    {
        public static void Main()
        {
            TextFile myFile = new TextFile("myDoc.txt", "");
            TextEditor editor = new TextEditor(myFile);
            Indexer indexer = new Indexer();
            Search searcher = new Search();

            bool running = true;

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
                    5. Search
                    6. Index Files
                    7. Exit
                    Select options: 
                    """);

                string choise = Console.ReadLine();

                if (!Enum.TryParse(choise, ignoreCase: true, out menuOption result) ||
                    !Enum.IsDefined(typeof(menuOption), result))
                {
                    Console.WriteLine("Incorrect input. Try again");
                    continue;
                }

                switch (result)
                {
                    case menuOption.EnterString:
                        Console.Write("Enter string: ");
                        string input = Console.ReadLine();
                        editor.UpdateContent(input);
                        break;

                    case menuOption.Undo:
                        editor.Undo();
                        Console.WriteLine("Undo complete. Press any key...");
                        Console.ReadKey();
                        break;

                    case menuOption.SaveXml:
                        myFile.SaveXml("file.xml");
                        break;

                    case menuOption.SaveBinary:
                        myFile.SaveBinary("file.bin");
                        break;

                    case menuOption.Search:
                        searcher.IndexAndPrint();
                        break;

                    case menuOption.Indexer:
                        Console.Write("Enter keywords (space separated): ");
                        string[] words = Console.ReadLine().Split(' ');
                        indexer.CreateIndex(Environment.CurrentDirectory, words);
                        Console.WriteLine("Press any key...");
                        indexer.PrintIndex();
                        Console.ReadKey();
                        break;

                    case menuOption.Exit:
                        running = false;
                        break;
                }
            }
        }
    }

    public enum menuOption
    {
        EnterString = 1,
        Undo,
        SaveXml,
        SaveBinary,
        Search,
        Indexer,
        Exit
    }
}