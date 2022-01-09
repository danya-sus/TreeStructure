using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeStructure
{
    public interface IAbstractTree<T>
    {
        void Insert(T element);
        bool Contains(T element);
        IAbstractTree<T> Search(T element);
        ICollection<T> OrderBfs();
        ICollection<T> OrderDfs();
        Node<T> Root { get; }
        Node<T> Left { get; }
        Node<T> Right { get; }
        T value { get; }
    }
}
