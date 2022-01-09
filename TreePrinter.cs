using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeStructure
{
    public static class TreePrinter<T> where T: IComparable
    {
        static readonly int COUNT = 10;
        private static void Print(Node<T> root, int space)
        {
            if (root == null)
                return;
            space += COUNT;

            Print(root.Right, space);

            Console.Write("\n");
            for (int i = COUNT; i < space; i++)
                Console.Write(" ");
            Console.Write(root.Value + "\n");

            Print(root.Left, space);
        }

        public static void Print(IAbstractTree<T> tree)
        {
            Print(tree.Root, 0);
        }
    }
}
