using System;

class Program
{
    static void Main(string[] args)
    {
        AVLTree tree = new AVLTree();

        // Тестова послідовність, яка б без балансування виродилась у список
        int[] elements = { 10, 20, 30, 40, 50, 25 };

        Console.WriteLine("=== Вставка елементів в AVL-дерево ===");
        foreach (var el in elements)
        {
            Console.WriteLine($"\nВставляємо: {el}");
            tree.Insert(el);
            tree.Print();
            Console.WriteLine(new string('-', 30));
        }
    }
}

// Клас вузла AVL-дерева
public class AVLNode
{
    public int Key;
    public int Height; // Висота вузла в дереві (потрібна для розрахунку балансу)
    public AVLNode Left;
    public AVLNode Right;

    public AVLNode(int key)
    {
        Key = key;
        Height = 1; // Новий вузол спочатку має висоту 1
    }
}

// Клас AVL-дерева
public class AVLTree
{
    private AVLNode root;

    // Допоміжний метод для отримання висоти вузла (захист від null)
    private int GetHeight(AVLNode node)
    {
        return node == null ? 0 : node.Height;
    }

    // Розрахунок коефіцієнта балансу (Balance Factor)
    private int GetBalance(AVLNode node)
    {
        return node == null ? 0 : GetHeight(node.Left) - GetHeight(node.Right);
    }

    // 1. Правий поворот (для усунення лівого перекосу - LL)
    private AVLNode RightRotate(AVLNode y)
    {
        AVLNode x = y.Left;
        AVLNode T2 = x.Right;

        // Виконуємо поворот
        x.Right = y;
        y.Left = T2;

        // Перераховуємо висоти (спочатку для нижнього y, потім для верхнього x)
        y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
        x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;

        return x; // Повертаємо новий корінь піддерева
    }

    // 2. Лівий поворот (для усунення правого перекосу - RR)
    private AVLNode LeftRotate(AVLNode x)
    {
        AVLNode y = x.Right;
        AVLNode T2 = y.Left;

        // Виконуємо поворот
        y.Left = x;
        x.Right = T2;

        // Перераховуємо висоти
        x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
        y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;

        return y; // Повертаємо новий корінь піддерева
    }

    // Публічний метод вставки
    public void Insert(int key)
    {
        root = InsertRecursive(root, key);
    }

    // Рекурсивна вставка вузла з подальшим балансуванням
    private AVLNode InsertRecursive(AVLNode node, int key)
    {
        // 1. Стандартна BST-вставка
        if (node == null)
            return new AVLNode(key);

        if (key < node.Key)
            node.Left = InsertRecursive(node.Left, key);
        else if (key > node.Key)
            node.Right = InsertRecursive(node.Right, key);
        else
            return node; // Дублікати в дерево не додаємо

        // 2. Оновлюємо висоту поточного вузла по дорозі назад (з рекурсії)
        node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));

        // 3. Отримуємо коефіцієнт балансу, щоб перевірити, чи немає перекосу
        int balance = GetBalance(node);

        // --- БАЛАНСУВАННЯ (4 випадки) ---

        // Випадок 1: LL (Ліве-Ліве порушення) -> потрібен один Правий поворот
        if (balance > 1 && key < node.Left.Key)
            return RightRotate(node);

        // Випадок 2: RR (Праве-Праве порушення) -> потрібен один Лівий поворот
        if (balance < -1 && key > node.Right.Key)
            return LeftRotate(node);

        // Випадок 3: LR (Ліве-Праве порушення) -> Подвійний поворот (Лівий + Правий)
        if (balance > 1 && key > node.Left.Key)
        {
            node.Left = LeftRotate(node.Left);
            return RightRotate(node);
        }

        // Випадок 4: RL (Праве-Ліве порушення) -> Подвійний поворот (Правий + Лівий)
        if (balance < -1 && key < node.Right.Key)
        {
            node.Right = RightRotate(node.Right);
            return LeftRotate(node);
        }

        return node; // Повертаємо незмінний вузол, якщо баланс в нормі
    }

    // Публічний метод для красивого виведення дерева в консоль
    public void Print()
    {
        PrintHelper(root, "", true);
    }

    private void PrintHelper(AVLNode node, string indent, bool last)
    {
        if (node != null)
        {
            Console.Write(indent);
            if (last)
            {
                Console.Write("└── ");
                indent += "    ";
            }
            else
            {
                Console.Write("├── ");
                indent += "│   ";
            }

            Console.WriteLine($"{node.Key} (H:{node.Height}, B:{GetBalance(node)})");
            PrintHelper(node.Left, indent, false);
            PrintHelper(node.Right, indent, true);
        }
    }
}