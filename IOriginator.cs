using System;

namespace InputOutput
{
    public interface IOriginator
    {
        string Content { get; set; }
        
        Memento CreateMemento();
        void Restore(Memento memento);
    }
}