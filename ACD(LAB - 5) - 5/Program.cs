using System;
using System.Collections.Generic;

namespace BinaryTreeStructure
{
    // Клас вузла дерева, що використовується в усіх методах
    public class Node
    {
        public int Key { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node Parent { get; set; }

        public Node(int key)
        {
            Key = key;
            Left = null;
            Right = null;
            Parent = null;
        }
    }

    public class BinaryTree
    {
        // Корінь дерева для нестатичних методів (наприклад, InOrderNonRecursive)
        public Node Root { get; set; }

        // --- 1. Рекурсивні обходи дерева (Зображення 1) ---

        // Прямий обхід (Pre-order): Корінь -> Ліве -> Праве
        public void PreOrder(Node node)
        {
            if (node != null)
            {
                Console.Write(node.Key + " "); // Обробка кореня
                PreOrder(node.Left);           // Рекурсія ліворуч
                PreOrder(node.Right);          // Рекурсія праворуч
            }
        }

        // Зворотний обхід (Post-order): Ліве -> Праве -> Корінь
        public void PostOrder(Node node)
        {
            if (node != null)
            {
                PostOrder(node.Left);          // Рекурсія ліворуч
                PostOrder(node.Right);         // Рекурсія праворуч
                Console.Write(node.Key + " "); // Обробка кореня
            }
        }

        // --- 2. Ітеративний обхід (Зображення 2) ---

        // Центрований нерекурсивний обхід (In-order): Ліве -> Корінь -> Праве
        public void InOrderNonRecursive()
        {
            Stack<Node> stack = new Stack<Node>();
            Node current = Root;

            while (current != null || stack.Count > 0)
            {
                // 1. Спускаємось до найлівішого доступного вузла
                while (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }

                // 2. Повертаємось на крок назад (до батька або вище)
                current = stack.Pop();
                Console.Write(current.Key + " ");

                // 3. Переключаємось на праве піддерево
                current = current.Right;
            }
            Console.WriteLine();
        }

        // --- 3. Пошук мінімуму та максимуму (Зображення 3) ---

        public static Node TreeMinimum(Node x)
        {
            if (x == null) return null;
            if (x.Left == null) return x; // Ліворуч більше нічого немає, це мінімум

            return TreeMinimum(x.Left);
        }

        public static Node TreeMaximum(Node x)
        {
            if (x == null) return null;
            if (x.Right == null) return x; // Праворуч більше нічого немає, це максимум

            return TreeMaximum(x.Right);
        }

        // --- 4. Пошук попередника (Зображення 4 - Завдання 5) ---

        public static Node TreePredecessor(Node x)
        {
            if (x == null) return null;

            // Сценарій 1: Є ліве піддерево
            if (x.Left != null)
            {
                return TreeMaximum(x.Left);
            }

            // Сценарій 2: Лівого піддерева немає
            Node y = x.Parent;
            while (y != null && x == y.Left)
            {
                x = y;
                y = y.Parent;
            }
            return y;
        }

        // --- 5. Рекурсивне вставлення вузла (Зображення 4 - Завдання 6) ---

        public static Node TreeInsert(Node root, Node z, Node parent = null)
        {
            // Якщо дійшли до порожнього місця, створюємо тут вузол
            if (root == null)
            {
                z.Parent = parent;
                return z;
            }

            // Рекурсивно спускаємося ліворуч або праворуч
            if (z.Key < root.Key)
            {
                root.Left = TreeInsert(root.Left, z, root);
            }
            else
            {
                root.Right = TreeInsert(root.Right, z, root);
            }

            return root;
        }
    }
}