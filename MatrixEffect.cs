public class MatrixEffect
{/// <summary>
/// The MatrixEffect class is a C# class that provides functionality for creating a matrix animation effect.
/// It uses the Thread class from the System.Threading namespace to run the animation on a separate thread.
/// The MatrixEffect class has two private fields: running and thread. The running field is a boolean variable that indicates whether the animation is currently running. The thread field is an instance of the Thread class, which will be used to run the MatrixAnimation method.
/// 
/// The constructor of the MatrixEffect class initializes the running field to true and creates a new instance of the Thread class,
/// passing the MatrixAnimation method as a parameter.
/// The Start method starts the animation by calling the Start method of the Thread class. This will execute the MatrixAnimation method on a separate thread.
/// The Stop method stops the animation by setting the running field to false. This will cause the MatrixAnimation method to exit the loop and stop the animation.
/// The MatrixAnimation method is the core of the matrix animation effect. It uses various variables and methods to generate random characters and display them on the console window.
/// 
/// Here's a breakdown of the MatrixAnimation method:
/// 
/// It retrieves the height and width of the console window using the Console.WindowHeight and Console.WindowWidth properties.
/// It creates a new instance of the Random class to generate random numbers.
/// It initializes an array of characters called matrixChars with the characters used in the animation.
/// It enters a while loop that continues as long as the running field is true.
/// Inside the loop, it generates a random column and speed for each iteration.
/// It then enters a for loop that iterates over each row of the console window.
/// Inside the for loop, it generates a random delay and selects a random character from the matrixChars array.
/// It sets the cursor position to the current column and row, sets the console foreground color to green, and writes the random character to the console.
/// It then sleeps for a short duration determined by the speed variable.
/// After sleeping, it sets the cursor position to the current column and row again, and writes a space character to erase the previously displayed character.
/// It increments the row variable and checks if it has reached the end of the console window. If it has, it resets the row to 0.
/// The loop continues until the animation is stopped by setting the running field to false.
/// 
/// To use the MatrixEffect class, you can create an instance of it and call the Start method to start the animation. You can then call the Stop method to stop the animation.
/// 
/// </summary>
    private bool running;
    private readonly Thread thread;

    public MatrixEffect()
    {
        running = true;
        thread = new Thread(MatrixAnimation);
    }

    public void Start()
    {
        thread.Start();
    }

    public void Stop()
    {
        running = false;
    }

    private void MatrixAnimation()
    {
        var windowHeight = Console.WindowHeight;
        var windowWidth = Console.WindowWidth;

        var random = new Random();
        var matrixChars = "0123456789ABCDEF".ToCharArray();

        while (running)
        {
            var column = random.Next(0, windowWidth);
            var speed = random.Next(1, 5);

            for (var row = 0; row < windowHeight; row++)
            {
                var delay = random.Next(10, 100);
                var randomChar = matrixChars[random.Next(0, matrixChars.Length)];

                Console.SetCursorPosition(column, row);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(randomChar);

                Thread.Sleep(speed);
                Console.SetCursorPosition(column, row);
                Console.Write(' ');

                row++;
                if (row >= windowHeight) row = 0;
            }
        }
    }
}