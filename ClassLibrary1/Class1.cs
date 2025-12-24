using System;
using ClassLibrary1.Keyboard;

namespace ClassLibrary1;

public class Class1
{
    public static void Main()
    {
        Console.WriteLine("Hello World");
          var eventSender = new EventSender();
        eventSender.OpenChannels();

        var listener = new KeyboardListener();

        listener.OnKeyboardEvent += (sender, inputEvent) =>
        {
            if (inputEvent.type == Constants.EV_KEY)
            {
                if (inputEvent.value == Constants.KEY_DOWN || inputEvent.value == Constants.KEY_REPEAT)
                {

                    Console.WriteLine($"Key: {inputEvent.code} has been pressed");
                }
            }

            Console.WriteLine("Forwarding the event");
            eventSender.SendEvent(inputEvent);
        };

        listener.SetHook();

        Console.WriteLine("Press enter to exit.");
        Console.ReadLine();

        listener.Unhook();
        eventSender.CloseChannels();
    }
}
