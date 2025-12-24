using System.Diagnostics;
using DistributedComputing.Workers;
using System.IO;

namespace DistributedComputing;

public class Start
{

    public static void Main()
    {
        ConsoleKey pressedKey;
        Console.WriteLine("Press A to run in async\nPress S to run synchronously\nPress esc to quit\n\n");

        while ((pressedKey = Console.ReadKey().Key) != ConsoleKey.Escape)
        {
            switch (pressedKey)
            {
                case ConsoleKey.A:
                    Console.WriteLine("Clearing output file...");
                    File.WriteAllText("OutputFile.txt", string.Empty);
                    Console.WriteLine("Finished...\n");

                    Stopwatch stopwatch = Stopwatch.StartNew();

                    Console.WriteLine("#### Distributed Computing ASYNC ####");
                    Console.WriteLine("".PadRight(31, '#'));

                    MasterNode masterNodeAsync = new(true);

                    Console.WriteLine($"Total Time: {stopwatch.ElapsedMilliseconds} ms or {stopwatch.ElapsedMilliseconds / 1000} s");
                    Console.WriteLine("".PadRight(31, '#'));

                    break;

                case ConsoleKey.S:
                    Console.WriteLine("Not implemented...");
                    Console.WriteLine("Clearing output file...");
                    File.WriteAllText("OutputFile.txt", string.Empty);
                    Console.WriteLine("Finished...\n");

                    Stopwatch stopwatch2 = Stopwatch.StartNew();

                    Console.WriteLine("#### Distributed Computing ####");
                    Console.WriteLine("".PadRight(31, '#'));

                    MasterNode masterNode = new(false);

                    Console.WriteLine($"Total Time: {stopwatch2.ElapsedMilliseconds} ms or {stopwatch2.ElapsedMilliseconds / 1000} s");
                    Console.WriteLine("".PadRight(31, '#'));

                    break;
                default:
                    Console.WriteLine("Running..");
                    break;
            }

        }


    }
}
