using MrRoboT;
using System;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Text;
using static game.InterFace;

class Program
{

    static void Main(string[] args)
    {

        MatrixEffect matrixEffect = new MatrixEffect();
        LoginManager loginManager = new LoginManager();
        ConsoleApp app = new ConsoleApp();
        Operations operationsObject = new Operations();
        operationsObject.Matrix();
        Console.CursorVisible = false;
        Console.Clear();
        Console.ResetColor();
        Console.CursorVisible = false;

        operationsObject.PrintCenteredTextWithBorder("Mr. Robot 2.0", '\u2502', ConsoleColor.DarkGreen);
        Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
        //operationsObject.PrintCenteredText("  Press any key to begin...");
        Console.ReadKey(true);
        Console.Clear();
        Console.Clear();
        LoginManager.Show();
        app.Run();
        

    }

  
}

