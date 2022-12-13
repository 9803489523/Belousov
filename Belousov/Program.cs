// See https://aka.ms/new-console-template for more information

namespace Belousov
{
    public class Program
    {
        public static void Main(String[] args)
        {
            Tree tree=new Tree();
            tree.Add("Ivan",1);
            tree.Add("Oleg", 5);
            tree.Add("Tom", 4);
            tree.Add("Mattew", 7);
            tree.Add("Dmitry", 2);
            Console.WriteLine("После добавления");
            tree.PrintTree();
            tree.Remove(2);
            Console.WriteLine("После удаления 2 элемента");
            tree.PrintTree();
            Console.WriteLine("Поиск элемента с идентификатором 4");
            Console.WriteLine(tree.FindNode(4).Data);

        }
    }
}