public class MatrixEffect
{
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