/*const char toWrite = '*';
int x = 119;
int y = 10;

Write(toWrite, x, y);
Console.WriteLine(Console.WindowWidth);
while (true)
{
    if (Console.KeyAvailable)
    {
        var command = Console.ReadKey().Key;
        switch (command)
        {
            case ConsoleKey.DownArrow:
                y++;
                break;
            case ConsoleKey.LeftArrow:
                if (x > 0)
                {
                    x--;
                }
                break;
            case ConsoleKey.RightArrow:
                x++;
                break;
            case ConsoleKey.UpArrow:
                if (y > 0)
                {
                    y--;
                }
                break;
        }
        Write(toWrite, x, y);
    }
    else
    {
        Thread.Sleep(100);
    }
}*/

/*public static void Write(char toWrite, int x = 100, int y = 100)
{
    try
    {
        if (x >= 0 && y >= 0)
        {
            Console.Clear();
            Console.SetCursorPosition(x, y);
            Console.Write(toWrite);
        }
    }
    catch (Exception e)
    {

    }
}*/