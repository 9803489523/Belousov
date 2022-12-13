// See https://aka.ms/new-console-template for more information

namespace Belousov
{
    public class Program
    {
        //Запуск программы, если нужно добавить элементы пишем tree.add("имя",число);
        //Для поиска пишем tree.FindNode(число).Data
        //Удаление tree.Remove(число);
        //tree.PrintTree(); Вывод на экран
        public static void Main(String[] args)
        {
            Tree tree=new Tree();
            //добавляем элементы
            tree.Add("Ivan",1);
            tree.Add("Oleg", 5);
            tree.Add("Tom", 4);
            tree.Add("Mattew", 7);
            tree.Add("Dmitry", 2);
            Console.WriteLine("После добавления");
            //выводим дерево на экран
            tree.PrintTree();
            //удаляем 2 уэлемент
            tree.Remove(2);
            Console.WriteLine("После удаления 2 элемента");
            //выводим дерево на экран
            tree.PrintTree();
            Console.WriteLine("Поиск элемента с идентификатором 4");
            //ищем элемент с id=4 и выводим его на экран
            Console.WriteLine(tree.FindNode(4).Data);

        }
    }
}