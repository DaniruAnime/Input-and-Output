using System.Collections.Generic;

namespace InputOutput
{
    public class TextEditor
    {
        private TextFile _file;
        private Stack<Memento> _history = new Stack<Memento>();

        public TextEditor(TextFile file)
        { 
            _file = file;
        }

        public void UpdateContent(string newContent)
        {
            _history.Push(_file.CreateMemento());
            _file.Content = newContent;
        }

        public void Undo()
        {
            if (_history.Count > 0)
            {
                _file.Restore(_history.Pop());
            }

            Console.WriteLine("Undo complete. Press any key...");
            Console.ReadKey();
        }

        public string GetCurrentContent()
        {
            return _file.Content;
        }
    }
}