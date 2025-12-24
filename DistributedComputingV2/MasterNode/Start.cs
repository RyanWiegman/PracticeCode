namespace MasterNode;

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
                    Send send = new();
                    send.CreateConnectionAsync();

                    break;

                default:
                    Console.WriteLine("Waiting..");
                    break;
            }



        }
    }
}
