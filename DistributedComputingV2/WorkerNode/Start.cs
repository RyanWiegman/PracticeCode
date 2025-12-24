namespace WorkerNode;

public class Start
{
    public static void Main(string[] args)
    {
        ConsoleKey keyPress;

        Console.WriteLine("Press S to start running..");

        while ((keyPress = Console.ReadKey().Key) != ConsoleKey.Escape)
        {
            switch (keyPress)
            {
                case ConsoleKey.S:
                    Receive receive = new();
                    receive.CreateConnection();

                    break;

                default:
                    Console.WriteLine("Waiting..");
                    break;
            }



        }
    }

}
