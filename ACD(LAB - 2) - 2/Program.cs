using System;
using System.Text;
using System.Collections.Generic;

class Program
{
    //генератор випадкових чисел для randomized quicksort
    static Random rand = new Random();

    static void Main()
    {
       
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;

        Console.WriteLine("   ЛАБОРАТОРНА РОБОТА №2 - SORT");

        //patrition для масиву
        //початковий масив
        int[] arr1 = { 13, 19, 9, 5, 12, 8, 7, 4, 21, 2, 6, 11 };

        Console.WriteLine("1. PARTITION:");

        //виклик процедури partition
        int q = Partition(arr1, 0, arr1.Length - 1);

        //вивід позиції pivot
        Console.WriteLine("Індекс опорного елемента: " + q);

        Console.WriteLine("Масив після Partition:");

        //вивід масиву
        PrintArray(arr1);

        //quick sort для масиву
        //новий масив
        int[] arr2 = { 13, 19, 9, 5, 12, 8, 7, 4, 21, 2, 6, 11 };

        //сортування по спадання
        QuickSortDesc(arr2, 0, arr2.Length - 1);

        Console.WriteLine("\n2. QUICK SORT (незростаючий порядок):");

        PrintArray(arr2);



        //randomized quicksort для нового масиву
        int[] arr3 = { 13, 19, 9, 5, 12, 8, 7, 4, 21, 2, 6, 11 };

        //quicksort з випадковим pivot
        RandomizedQuickSort(arr3, 0, arr3.Length - 1);

        Console.WriteLine("\n3. RANDOMIZED QUICK SORT:");

        PrintArray(arr3);

        //counting sort для цілих чисел від 0 до 6
        int[] arr4 = { 6, 0, 2, 0, 1, 3, 4, 6, 1, 3, 2 };

        //сортування підрахунком
        int[] sortedCounting = CountingSort(arr4, 6);

        Console.WriteLine("\n4. COUNTING SORT:");

        PrintArray(sortedCounting);

        //prefix sum для arr4
        //побудова префіксного масиву
        int[] prefix = Preprocess(arr4, 6);

        //підрахунок чисел у діапазоні
        Console.WriteLine("\n5. Кількість чисел на відрізку [1..3]: "
            + RangeQuery(prefix, 1, 3));

        //radix sort для рядків
        string[] words = {
            "COW","DOG","SEA","RUG","ROW","MOB","BOX","TAB",
            "BAR","EAR","TAR","DIG","BIG","TEA","NOW","FOX"
        };

        //сортування слів
        RadixSort(words, 3);

        Console.WriteLine("\n6. RADIX SORT:");

        PrintArray(words);



        //bucket sort для дробових чисел від 0 до 1
        double[] arr5 = { .79, .13, .16, .64, .39, .20, .89, .53, .71, .42 };

        //сортування дробових чисел
        BucketSort(arr5);

        Console.WriteLine("\n7. BUCKET SORT:");

        PrintArray(arr5);
    }

    //patrition ділить масив на дві частини
    static int Partition(int[] A, int p, int r)
    {
        bool allEqual = true;

        //перевірка чи всі елементи однакові
        for (int i = p; i < r; i++)
        {
            if (A[i] != A[r])
            {
                allEqual = false;
                break;
            }
        }

        //якщо всі однакові то повертаємо середину
        if (allEqual)
            return (p + r) / 2;

        //pivot = останній елемент
        int pivot = A[r];

        //індекс елементів менших pivot
        int iIndex = p - 1;

        //прохід по масиву
        for (int j = p; j < r; j++)
        {
            if (A[j] <= pivot)
            {
                iIndex++;

                //міняємо місцями
                Swap(A, iIndex, j);
            }
        }

        //ставимо pivot на правильне місце
        Swap(A, iIndex + 1, r);

        return iIndex + 1;
    }

    //quick sort для спадання
    static void QuickSortDesc(int[] A, int p, int r)
    {
        if (p < r)
        {
            int q = PartitionDesc(A, p, r);

            //сортуємо ліву частину
            QuickSortDesc(A, p, q - 1);

            //сортуємо праву частину
            QuickSortDesc(A, q + 1, r);
        }
    }


    //Partition для спадання
    static int PartitionDesc(int[] A, int p, int r)
    {
        int pivot = A[r];

        int iIndex = p - 1;

        for (int j = p; j < r; j++)
        {
            //якщо число більше pivot
            if (A[j] >= pivot)
            {
                iIndex++;

                Swap(A, iIndex, j);
            }
        }

        Swap(A, iIndex + 1, r);

        return iIndex + 1;
    }

    //randomized quicksort з випадковим pivot
    static void RandomizedQuickSort(int[] A, int p, int r)
    {
        if (p < r)
        {
            int q = RandomizedPartition(A, p, r);

            RandomizedQuickSort(A, p, q - 1);
            RandomizedQuickSort(A, q + 1, r);
        }
    }


    static int RandomizedPartition(int[] A, int p, int r)
    {
        //випадковий pivot
        int randomIndex = rand.Next(p, r + 1);

        //міняємо pivot місцями
        Swap(A, randomIndex, r);

        return Partition(A, p, r);
    }



    //counting sort для цілих чисел
    static int[] CountingSort(int[] A, int k)
    {
        int[] count = new int[k + 1];
        int[] result = new int[A.Length];

        //рахуємо кількість кожного числа
        for (int i = 0; i < A.Length; i++)
            count[A[i]]++;

        int index = 0;

        //формуємо відсортований масив
        for (int i = 0; i <= k; i++)
        {
            while (count[i] > 0)
            {
                result[index++] = i;
                count[i]--;
            }
        }

        return result;
    }

    //префіксна сумма
    static int[] Preprocess(int[] A, int k)
    {
        int[] prefix = new int[k + 1];

        //рахуємо кількість
        for (int i = 0; i < A.Length; i++)
            prefix[A[i]]++;

        //префіксна сума
        for (int i = 1; i <= k; i++)
            prefix[i] += prefix[i - 1];

        return prefix;
    }


    //підрахунок чисел у діапазоні
    static int RangeQuery(int[] prefix, int a, int b)
    {
        if (a == 0)
            return prefix[b];

        return prefix[b] - prefix[a - 1];
    }

    //редікс сорт для рядків
    static void RadixSort(string[] A, int length)
    {
        //сортуємо по кожній букві
        for (int pos = length - 1; pos >= 0; pos--)
            CountingSortByChar(A, pos);
    }


    //counting sort для символів
    static void CountingSortByChar(string[] A, int pos)
    {
        int n = A.Length;

        string[] output = new string[n];

        int[] count = new int[256];

        //підрахунок кількості символів
        for (int i = 0; i < n; i++)
            count[A[i][pos]]++;

        for (int i = 1; i < 256; i++)
            count[i] += count[i - 1];

        for (int i = n - 1; i >= 0; i--)
        {
            output[count[A[i][pos]] - 1] = A[i];
            count[A[i][pos]]--;
        }

        for (int i = 0; i < n; i++)
            A[i] = output[i];
    }

    //бакет сорт
    static void BucketSort(double[] A)
    {
        int n = A.Length;

        //створення корзин
        List<double>[] buckets = new List<double>[n];

        for (int i = 0; i < n; i++)
            buckets[i] = new List<double>();

        //розподіл чисел по корзинах
        for (int i = 0; i < n; i++)
        {
            int index = (int)(A[i] * n);

            buckets[index].Add(A[i]);
        }

        int k = 0;

        //сортуємо корзини
        for (int i = 0; i < n; i++)
        {
            buckets[i].Sort();

            foreach (double num in buckets[i])
                A[k++] = num;
        }
    }


    //вивід масиву
    static void PrintArray<T>(T[] array)
    {
        Console.WriteLine(string.Join(", ", array));
    }


    //обмін елементів місцями
    static void Swap(int[] A, int i, int j)
    {
        int temp = A[i];
        A[i] = A[j];
        A[j] = temp;
    }

}