using System;

namespace InputOutput
{
    public class Memento
    {
        public string SavedContent { get; }
        public Memento(string content)
        {
            SavedContent = content;
        }
    }
}
