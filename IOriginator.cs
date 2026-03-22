using System;

namespace InputOutput
{
    public interface IOriginator
    {
        Memento CreateMemento();
        void Restore(Memento memento);
    }
}