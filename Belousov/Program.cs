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

            Tree tree = new Tree();
            tree.Menu(tree);

        }
    }
}