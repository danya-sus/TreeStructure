using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeStructure
{
    public class Tree<T> : IAbstractTree<T> where T : IComparable
    {
        public Tree()
        {
        }
        public Tree(Node<T> node)
        {
            this.Root = node;
            this.Left = node.Left;
            this.Right = node.Right;
        }
        public Node<T> Root { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public T value => this.Root.Value;

        public bool Contains(T element)
        {
            var temp = this.Root;
            while(temp != null)
            {
                if (element.CompareTo(temp.Value) < 0)
                {
                    temp = temp.Left;
                }
                else if (element.CompareTo(temp.Value) > 0)
                {
                    temp = temp.Right;
                }
                else break;
            }
            return temp != null;
        }
        public void Insert(T element)
        {
            var newElement = new Node<T>(element, null, null);

            if (this.Root == null)
            {
                this.Root = newElement;
            }
            else
            {
                var childElement = this.Root;
                Node<T> parentElement = null;

                while (childElement != null)
                {
                    parentElement = childElement;

                    if (newElement.Value.CompareTo(childElement.Value) < 0)
                    {
                        childElement = childElement.Left;
                    }
                    else if (newElement.Value.CompareTo(childElement.Value) > 0)
                    {
                        childElement = childElement.Right;
                    }
                    else
                    {
                        return;
                    }
                }

                if (parentElement.Value.CompareTo(newElement.Value) < 0)
                {
                    parentElement.Right = newElement;
                }
                else
                {
                    parentElement.Left = newElement;
                }
            }
        }
        public IAbstractTree<T> Search(T element)
        {
            var current = this.Root;

            while (current != null)
            {
                if (element.CompareTo(current.Value) < 0)
                {
                    current = current.Left;
                }
                else if (element.CompareTo(current.Value) > 0)
                {
                    current = current.Right;
                }
                else break;
            }
            return new Tree<T>(current);
        }
        public ICollection<T> OrderBfs()
        {
            var result = new List<T>();
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                Tree<T> subtree = queue.Dequeue();
                result.Add(subtree.value);
                if (subtree.Root.Left != null)
                {
                    queue.Enqueue((Tree<T>)subtree.Search(subtree.Root.Left.Value));
                }
                if (subtree.Root.Right != null)
                {
                    queue.Enqueue((Tree<T>)subtree.Search(subtree.Root.Right.Value));
                }
            }
            return result;
        }

        public ICollection<T> OrderDfs()
        {
            var result = new List<T>();
            this.Dfs(this, result);
            return result;
        }
        private void Dfs(Tree<T> tree, List<T> result)
        {
            if (tree.Root.Left != null)
            {
                tree.Dfs((Tree<T>)tree.Search(tree.Root.Left.Value), result);
            }
            if (tree.Root.Right != null)
            {
                tree.Dfs((Tree<T>)tree.Search(tree.Root.Right.Value), result);
            }
            result.Add(tree.value);
        }
    }
}
