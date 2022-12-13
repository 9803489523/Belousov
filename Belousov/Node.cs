using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belousov
{
    //Перечисление для определения положения узла в дереве 
    public enum Side
    {
        Left,
        Right
    }


    //Класс узла бинарного дерева
    public class Node
    {
        //Конструктор
        public Node(string data, int id)
        {
            Data = data;
            Id = id;
        }

        //Данные узла

        public string Data { get; set; }

        //Идентификатор узла
        public int Id { get; set; }

        //Левая ветка
        public Node LeftNode { get; set; }

        
        //Правая ветка
        public Node RightNode { get; set; }


        //Родительский узел
        public Node ParentNode { get; set; }

        
        //Расположение узла относительно родителя  
        public Side? NodeSide =>
            ParentNode == null
            ? (Side?)null
            : ParentNode.LeftNode == this
                ? Side.Left
                : Side.Right;

    }
}
