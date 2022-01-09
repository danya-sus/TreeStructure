using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeStructure
{
    public class Node<T>
    {
        public T Value;
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public Node(T value, Node<T> left, Node<T> right)
        {
            this.Value = value;
            this.Left = left;
            this.Right = right;
        }
    }
}
