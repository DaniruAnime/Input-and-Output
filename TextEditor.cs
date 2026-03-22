using System.Collections.Generic;

namespace InputOutput
{
    public class TextEditor
    {
        private IOriginator _originator;
        private Stack<Memento> _history = new Stack<Memento>();

        public TextEditor(TextFile originator)
        { 
            _originator = originator;
        }

        public void UpdateContent(string newContent)
        {
            _history.Push(_originator.CreateMemento());
            _originator.Content = newContent;
        }

        public void Undo()
        {
            if (_history.Count > 0)
            {
                _originator.Restore(_history.Pop());
            }

            Console.WriteLine("Undo complete. Press any key...");
            Console.ReadKey();
        }

        public string GetCurrentContent()
        {
            return _originator.Content;
        }
    }
}