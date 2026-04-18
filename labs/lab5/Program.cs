namespace OOP_LAB5_
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Region region = new Region(3);

            region[0] = new Village("Ковалівка", 1000, 50000, 10);
            region[1] = new City("Київ", 5000, 200000, 20);
            region[2] = new UrbanVillage("Софіївська Борщагівка", 3000, 100000, 5);

            Console.WriteLine("=== Розвиток ===");
            for (int i = 0; i < region.Length; i++)
            {
                region[i].Develop(100);
                Console.WriteLine(region[i]);
            }

            Console.WriteLine("\n=== Оператори ===");

            Village v1 = new Village("A", 1000, 20000, 5);
            Village v2 = new Village("B", 2000, 30000, 8);

            Console.WriteLine($"v1 > v2: {v1 > v2}");

            City c1 = new City("X", 5000, 100000, 10);
            City c2 = new City("Y", 4000, 90000, 8);

            City c3 = c1 + c2;
            Console.WriteLine("c1 + c2: " + c3);

            c1--;
            Console.WriteLine("c1--: " + c1);

            UrbanVillage u1 = new UrbanVillage("U1", 3000, 50000, 2);
            UrbanVillage u2 = new UrbanVillage("U2", 3000, 60000, 3);

            Console.WriteLine($"u1 == u2: {u1 == u2}");

            Console.ReadLine();
        }
    }
}