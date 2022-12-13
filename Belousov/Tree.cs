using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belousov
{
    internal class Tree
    {
        
       //Корень В-дерева  
        public Node RootNode { get; set; }

       
        //Функция добавления узла
        private Node Add(Node node, Node currentNode = null)
        {
            if (RootNode == null)
            {
                node.ParentNode = null;
                return RootNode = node;
            }

            currentNode = currentNode ?? RootNode;
            node.ParentNode = currentNode;
            int result;
            return (result = node.Id.CompareTo(currentNode.Id)) == 0
                ? currentNode
                : result < 0
                    ? currentNode.LeftNode == null
                        ? (currentNode.LeftNode = node)
                        : Add(node, currentNode.LeftNode)
                    : currentNode.RightNode == null
                        ? (currentNode.RightNode = node)
                        : Add(node, currentNode.RightNode);
        }

       //Добавление элемента в В-дерево (для пользователя)   
        public Node Add(string data, int id)
        {
            return Add(new Node(data, id));
        }

        
         //Поиск узла по идентификатору
        public Node FindNode(int id, Node startWithNode = null)
        {
            startWithNode = startWithNode ?? RootNode;
            int result;
            return (result = id.CompareTo(startWithNode.Id)) == 0
                ? startWithNode
                : result < 0
                    ? startWithNode.LeftNode == null
                        ? null
                        : FindNode(id, startWithNode.LeftNode)
                    : startWithNode.RightNode == null
                        ? null
                        : FindNode(id, startWithNode.RightNode);
        }


        
        //Вывод В-дерева на консоль (для пользователей)
        public void PrintTree()
        {
            PrintTree(RootNode);
        }

        
        //Вывод В-дерева на консоль
        private void PrintTree(Node startNode, string indent = "", Side? side = null)
        {
            if (startNode != null)
            {
                var nodeSide = side == null ? "+" : side == Side.Left ? "L" : "R";
                Console.WriteLine($"{indent} [{nodeSide}]- {startNode.Id}:{startNode.Data}");
                indent += new string(' ', 3);
                //рекурсивный вызов для левой и правой веток
                PrintTree(startNode.LeftNode, indent, Side.Left);
                PrintTree(startNode.RightNode, indent, Side.Right);
            }
        }
        //Удаление элемента по узлу, пользовательская функция
        public void Remove(int data)
        {
            var foundNode = FindNode(data);
            Remove(foundNode);
        }

        //Удаление узла по ключу
        public void Remove(Node node)
        {
            if (node == null)
            {
                return;
            }

            var currentNodeSide = node.NodeSide;
            if (node.LeftNode == null && node.RightNode == null)
            {
                if (currentNodeSide == Side.Left)
                {
                    node.ParentNode.LeftNode = null;
                }
                else
                {
                    node.ParentNode.RightNode = null;
                }
            }
            else if (node.LeftNode == null)
            {
                if (currentNodeSide == Side.Left)
                {
                    node.ParentNode.LeftNode = node.RightNode;
                }
                else
                {
                    node.ParentNode.RightNode = node.RightNode;
                }

                node.RightNode.ParentNode = node.ParentNode;
            }
            else if (node.RightNode == null)
            {
                if (currentNodeSide == Side.Left)
                {
                    node.ParentNode.LeftNode = node.LeftNode;
                }
                else
                {
                    node.ParentNode.RightNode = node.LeftNode;
                }

                node.LeftNode.ParentNode = node.ParentNode;
            }
            else
            {
                switch (currentNodeSide)
                {
                    case Side.Left:
                        node.ParentNode.LeftNode = node.RightNode;
                        node.RightNode.ParentNode = node.ParentNode;
                        Add(node.LeftNode, node.RightNode);
                        break;
                    case Side.Right:
                        node.ParentNode.RightNode = node.RightNode;
                        node.RightNode.ParentNode = node.ParentNode;
                        Add(node.LeftNode, node.RightNode);
                        break;
                    default:
                        var bufLeft = node.LeftNode;
                        var bufRightLeft = node.RightNode.LeftNode;
                        var bufRightRight = node.RightNode.RightNode;
                        node.Data = node.RightNode.Data;
                        node.RightNode = bufRightRight;
                        node.LeftNode = bufRightLeft;
                        Add(bufLeft, node);
                        break;
                }
            }
        }
    }
}
