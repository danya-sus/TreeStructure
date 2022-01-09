using System;

namespace TreeStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            IAbstractTree<int> bst = new Tree<int>();
            bst.Insert(12);
            bst.Insert(21);
            bst.Insert(5);
            bst.Insert(4);
            bst.Insert(8);
            bst.Insert(18);
            bst.Insert(23);
            bst.Insert(3);
            bst.Insert(9);
            bst.Insert(1);

            Console.WriteLine("Tree:");
            TreePrinter<int>.Print(bst);
            
            int element = 5;
            Console.WriteLine($"\n\n\nTree from element {element}:");
            TreePrinter<int>.Print(bst.Search(element));

            Console.Write("\n\n\nBFS: ");
            foreach (var item in bst.OrderBfs())
            {
                Console.Write($"{item.ToString()} - ");
            }
            
            Console.Write("\n\n\nDFS: ");
            foreach (var item in bst.OrderDfs())
            {
                Console.Write($"{item.ToString()} - ");
            }
        }
    }
}
