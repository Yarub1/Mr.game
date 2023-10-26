using System.Reflection.Emit;
using System.Text;
using MrRoboT;

namespace game;

internal class InterFace
{/// <summary>
/// The code above includes the necessary using statements and defines a class called InterFace with an inner class called ConsoleApp.
/// The ConsoleApp class has four private fields of type Box that represent different sections of the console window.
/// The constructor initializes these fields with specific dimensions and colors.
/// </summary>
    private static readonly Operations operationsObject = new();
    private const string ANSI_RESET = "\u001b[0m";
    private const string ANSI_RED = "\u001b[31m";
    private const string ANSI_GREEN = "\u001b[32m";
    private const string ANSI_YELLOW = "\u001b[33m";
    private const string ANSI_CYAN = "\u001b[36m";
    public class ConsoleApp
    {
        private readonly Box aaaBox;
        private readonly Box bbbBox;

        // Create an instance of the Box class for each box
        private readonly Box msgBox;
        private readonly Box backBox;
        public ConsoleApp()
        {
            Console.OutputEncoding = Encoding.Unicode;
            msgBox = new Box(35, 2, 80, 5, ConsoleColor.DarkGreen, ConsoleColor.DarkGreen, "Msg");
            aaaBox = new Box(35, 8, 80, 16, ConsoleColor.DarkGreen, ConsoleColor.DarkGreen, "AAA");
            bbbBox = new Box(35, 25, 80, 2, ConsoleColor.DarkGreen, ConsoleColor.DarkGreen, "BBB");

        }

        public void Run()
        {//The Run method is the entry point of the program. It sets the console window width, draws a section on the console window,
         //and displays the content in each box. It then prompts the user to choose a device from a menu and performs different actions based on the selected index.
         //The Case0, Case1, Case2, and Case3 methods are called depending on the selected index. If the selected index is not valid,
         //an error message is displayed. The program continues to prompt the user until a valid option is selected.

            Console.WindowWidth = 800;
            DrawSection(0, 0, 119, 28, "");

            Console.OutputEncoding = Encoding.Unicode;
            // Define the content for each box
            string[] msgContent =
            {
                //"This is a message box."
            };

            string[] aaaContent =
            {
                @"⠀"
            };

            string[] bbbContent =
            {
                "",
                ""
            };

            // Display the content in each box
            msgBox.DisplayContent(msgContent);
            aaaBox.DisplayContent(aaaContent);
            bbbBox.DisplayContent(bbbContent);

            Thread.Sleep(1000);
            DisplayWorldMap();

            Label:
            var textLeft = msgBox.Left + msgBox.Width / 2 - "First step is that I will show you a group of devices.".Length / 2;
            var textTop = msgBox.Top + 1;
            TypeTextWithEffect(textLeft, textTop + 1, "Your first step is to choose your device.", ConsoleColor.DarkGreen, ConsoleColor.Black);
            TypeTextWithEffect(textLeft, textTop + 2, "Choose one from the list and start setting it up.", ConsoleColor.DarkGreen, ConsoleColor.Black);

            string[] menuOptions =
                { "Windows             ", "Dos                 ", "Linux               ", "KasperskyOs recovery" };
            var newMenu = new Menu(menuOptions);
            var selectedIndex = newMenu.ShowMenu(5, 4, 25, menuOptions.Length);
            bool selectedIndexDoLoop = false;
            do
            {
                DisplayMenuInBox(aaaBox, aaaContent, selectedIndex);
                switch (selectedIndex)
                {
                    case 0:
                        Case0();
                        break;
                        
                    case 1:
                        Case1();
                        break;
                    case 2:
                        Case2(); 
                        Console.Clear();
                        InterFaceTow interFaceTow = new InterFaceTow();
                        interFaceTow.Run();
                        continue;
                    case 3:
                        Case3();
                        
                        break;

                    default:
                        operationsObject.PrintCenteredText(50, 6, $"{ANSI_GREEN}You did not select a valid option");
                        break;
                }
                string[] failMsgContent =
                {
                    $"               ",
                    $"{ANSI_RED}Try again wrong choice",
                    $"{ANSI_RED}Pay attention, time is counting down. You must choose correctly",
                };
                UpdateMsgBox(msgBox, failMsgContent);
                Thread.Sleep(2000);
                msgBox.Clear();
                goto Label;
                
            } while (selectedIndexDoLoop == true);
            

        }


        // methods here
        private static void UpdateMsgBox(Box msgBox, string newMsgOneContent)
        {//The UpdateMsgBox method is responsible for updating the content of a message box. It clears the message box,
         //sets the background color to black, and calculates the position to center the text. It then iterates over each character in the new content,
         //writes it to the console, and adjusts the position. After typing the content, it resets the colors of the message box.
            msgBox.Clear(); // Clear the message box
            msgBox.BackgroundColor = ConsoleColor.Black; // Reset background color

            var top = msgBox.Top + 2;
            var boxWidth = msgBox.Width - 2;
            var left = msgBox.Left + 1 +
                       (boxWidth - newMsgOneContent.Length) / 2; // Calculate left position to center the text

            foreach (var c in newMsgOneContent)
            {
                var partialLine = new string(c, 1);
                Console.SetCursorPosition(left, top);
                Console.Write(partialLine);
                Thread.Sleep(50); // Adjust the sleep duration to control the typing speed
                left++;
            }

            msgBox.ResetColors(); // Reset colors when done typing
        }

        //The DisplayMenuInBox method is responsible for displaying a menu inside a box.
        //It calculates the maximum number of menu options that can fit inside the box and adjusts the starting and ending indices based on the selected index.
        //It then clears the box content, displays the menu options inside the box, and updates the content of the box.
        public static void DisplayMenuInBox(Box box, string[] options, int selectedIndex)
        {
            // Calculate the maximum number of menu options that can fit inside the box
            var maxOptions = box.Height - 2;

            // Calculate the starting index based on the selected index
            var start = Math.Max(0, selectedIndex - maxOptions / 2);

            // Calculate the ending index based on the starting index and the maximum options
            var end = Math.Min(options.Length - 1, start + maxOptions - 1);

            // Adjust the starting and ending indices if they exceed the bounds of the options array
            if (start < 0)
            {
                start = 0;
                end = Math.Min(options.Length - 1, maxOptions - 1);
            }
            else if (end >= options.Length)
            {
                end = options.Length - 1;
                start = Math.Max(0, end - maxOptions + 1);
            }

            // Clear the box content
            var emptyContent = new string[box.Height - 2];
            box.DisplayContent(emptyContent);

            // Display the menu options inside the box
            var menuContent = new string[end - start + 1];
            Array.Copy(options, start, menuContent, 0, menuContent.Length);
            box.DisplayContent(menuContent);
        }


        //The DrawSection method is responsible for drawing a section on the console window. It sets the background color to dark green,
        //writes the title with padding to the specified position, and sets the background color back to black.
        //It then draws the vertical lines and the bottom line of the section using the characters '║' and '═'.
        public static void DrawSection(int left, int top, int width, int height, string title)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;

            Console.SetCursorPosition(left, top);
            Console.Write(" " + title.PadRight(width ));
            Console.BackgroundColor = ConsoleColor.Black;

            for (var i = top + 1; i < top + height; i++)
            {
                Console.ForegroundColor=ConsoleColor.DarkGreen;
                Console.SetCursorPosition(left, i);
                Console.Write("║"); 
                Console.SetCursorPosition(left + width, i);
                Console.Write("║");
            }

            Console.SetCursorPosition(left, top + height);
            Console.Write("╚" + new string('═', width - 1) + "╝");

        }
        //The DisplayContentAt method is responsible for displaying content at a specific position on the console window.
        //It sets the cursor position, foreground color, and background color, writes the content, and resets the colors.
        public static void DisplayContentAt(int left, int top, string content, ConsoleColor foregroundColor,
            ConsoleColor backgroundColor)
        {
            Console.SetCursorPosition(left, top);
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.WriteLine(content);
            Console.ResetColor();
        }
        //The TypeTextWithEffect method is responsible for typing text with a typing effect on the console window.
        //It sets the cursor position, foreground color, and background color, iterates over each character in the text,
        //writes the character, and sleeps for a specified duration to control the typing speed. After typing the text, it resets the colors.
        public static void TypeTextWithEffect(int left, int top, string text, ConsoleColor foregroundColor,
            ConsoleColor backgroundColor)
        {
            Console.SetCursorPosition(left, top);
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;

            foreach (var c in text)
            {
                Console.Write(c);
                Thread.Sleep(50); // Adjust the delay to control the typing speed
            }

            Console.ResetColor();
        }
        //The UpdateMsgBox method is responsible for updating the content of a message box with multiple lines.
        //It clears the message box, sets the background color to black, and calculates the position to center the text.
        //It then iterates over each line in the new content, writes the partial line to the console, and adjusts the position.
        //After typing the content, it resets the colors of the message box.
        private static void UpdateMsgBox(Box msgBox, string[] newContent)
        {
            msgBox.Clear(); // Clear the message box
            msgBox.BackgroundColor = ConsoleColor.Black; // Reset background color

            var top = msgBox.Top + 1;
            var boxWidth = msgBox.Width - 2;

            foreach (var line in newContent)
            {
                var left = msgBox.Left + 1 + (boxWidth - line.Length) / 2; // Calculate left position to center the text
                for (var i = 0; i <= line.Length; i++)
                {
                    var partialLine = line.Substring(0, i);
                    Console.SetCursorPosition(left, top);
                    Console.Write(partialLine);
                    Thread.Sleep(50); // Adjust the sleep duration to control the typing speed
                }

                top++;
            }

            msgBox.ResetColors(); // Reset colors when done typing
        }

        public static void FlashAndContinue(string[] lines, int interval, int top, int left)
        {
            //var originalLeft = Console.CursorLeft;
            //var originalTop = Console.CursorTop;
            var isFlashing = true;
            var totalLines = lines.Length;
            var currentLine = totalLines - 2; // Start flashing from the last line
            Console.SetCursorPosition(left, top);
            while (isFlashing)
            {
                Console.SetCursorPosition(left, top);
                for (var i = 0; i < totalLines; i++) Console.Write(new string(' ', lines[i].Length)); // Clear the line

                Thread.Sleep(interval);

                Console.SetCursorPosition(left, top);
                for (var i = 0; i < totalLines; i++)
                {
                    Console.Write(lines[i]); // Display the line
                    if (i < totalLines - 1) Console.WriteLine(); // Add newline for all lines except the last one
                }

                Thread.Sleep(interval);

                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter) isFlashing = false;
                //Console.Clear();
                //Console.WriteLine("\n\n\n");
            }
        }

        private void DisplayWorldMap()
        {
            var worldMap = @"⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣄⣠⣀⡀⣀⣠⣤⣤⣤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⢠⣠⣼⣿⣿⣿⣟⣿⣿⣿⣿⣿⣿⣿⣿⡿⠋⠀⠀⠀⢠⣤⣦⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠰⢦⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⣼⡧⣟⣾⣿⣽⣿⣿⣅⠈⠉⠻⣿⣿⣿⣿⣿⡿⠇⠀⠀⠀⠀⠀⠉⠀⠀⠀⠀⠀⢀⡶⠒⢉⡀⢠⣤⣶⣶⣿⣷⣆⣀⡀⠀⢲⣖⠒⠀⠀⠀⠀⠀⠀⠀
⢀⣤⣾⣶⣦⣤⣤⣶⣷⢿⣿⣿⣿⣿⣽⡿⠻⣷⣀⠀⢻⣿⣿⣿⡿⠟⠀⠀⠀⠀⠀⠀⣤⣶⣶⣤⣀⣀⣬⣷⣦⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣶⣦⣤⣦⣼⣀⠀
⠀⠸⠟⠋⠀⠈⠙⣿⣿⣿⡽⣿⣿⣗⣦⡄⣿⣿⣿⣆⠀⠀⠀⠀⠀⠀⠀⠀⣼⣆⢘⣿⣯⣼⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡉⠉⢱⡿⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀   ⠹⣿⣯⣿⠽⠿⣿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣾⣿⣿⣷⣦⣶⣦⣼⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⠈⠛⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠻⣿⣤⡖⠛⠶⠤⡀⠀⠀⠀⠀⠀⠀⠀⢰⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠁⠙⣿⣿⠿⢻⣿⣿⡿⠋⢩⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠧⣤⣦⣤⣄⡀⠀⠀⠀⠀⠀⠘⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⠘⣧⠀⠈⣹⡻⠇⢀⣿⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⣿⣿⣿⣿⣤⣀⡀⠀⠀⠀⠀⠀⠀⠈⢽⣿⣿⣿⣿⣿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠹⣷⣴⣿⣷⢲⣦⣤⡀⢀⡀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀  ⠀⠘⣿⣿⣿⣿⠉⣿⠃⠀⠀⠀⠀⠀⠀⠀⢹⣿⡿⠃         ⣤⣾⣿⣿⣿⣿⣆⠀⠰⠄⠀⠉⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣸⢿⣿⡿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀ ⠙⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⣿⠿⠿⣿⣿⣿⠇⠀⠀⢀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⡷⠛⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢻⡇⠀⠀⢀⣼⠗⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⠃⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠁⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠒⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀";
            var mapLines = worldMap.Split('\n');
            // Calculate the maximum available width and height within the aaaBox
            var maxDisplayWidth = aaaBox.Width - 2; // Subtract 2 for the left and right borders
            var maxDisplayHeight = aaaBox.Height;

            // Ensure the map does not exceed the available width
            for (var i = 0; i < mapLines.Length; i++)
                if (mapLines[i].Length > maxDisplayWidth)
                    mapLines[i] = mapLines[i].Substring(0, maxDisplayWidth);

            // Calculate the vertical position to center the map within the aaaBox
            var verticalPosition = aaaBox.Top + (maxDisplayHeight - mapLines.Length) / 2;

            // Calculate the horizontal position to center the map within the aaaBox
            var horizontalPosition = aaaBox.Left + (maxDisplayWidth - maxDisplayWidth) / 2;

            // Display the map centered within the aaaBox
            for (var i = 0; i < mapLines.Length; i++)
                DisplayContentAt(43, verticalPosition + i, mapLines[i], ConsoleColor.DarkGreen, ConsoleColor.Black);
        }

        private void DisplaySystemInitializationOutput()
        {
            string[] initializationLines =
            {
                $"{ANSI_YELLOW}System initialization",
                @"C\:System initialization output",
                @"C\:Loading modules...",
                @"C\:Configuring settings...",
                @"C\:Establishing connections...",
                @"C\:Initializing components...",
                $"{ANSI_RED}Failed to install the system."
            };

            DisplayTextInAaaBoxWithSleep(initializationLines,TimeSpan.FromSeconds(2)); // Sleep for 1 second between lines
        }


        private void DisplayTextInAaaBoxWithSleep(string[] textLines, TimeSpan sleepDuration)
        {
            // Calculate the maximum available width and height within the aaaBox
            var maxDisplayWidth = aaaBox.Width - 4; // 2 characters for the left and right border
            var maxDisplayHeight =
                aaaBox.Height - 2; // 1 character for the top border and 1 character for the bottom border

            // Ensure the text does not exceed the available width and height
            for (var i = 0; i < textLines.Length; i++)
                if (textLines[i].Length > maxDisplayWidth)
                    textLines[i] = textLines[i].Substring(0, maxDisplayWidth);

            // Calculate the vertical position to center the text within the aaaBox
            var verticalPosition = aaaBox.Top + (maxDisplayHeight - textLines.Length) / 2 + 1;

            // Display the text centered within the aaaBox with its border
            for (var i = 0; i < textLines.Length; i++)
            {
                var horizontalPosition = aaaBox.Left + 2; // Start after the left border
                DisplayContentAt(horizontalPosition, verticalPosition + i, textLines[i], ConsoleColor.White,
                    ConsoleColor.Black);

                Thread.Sleep(sleepDuration); // Sleep for the specified duration between lines
            }
        }

        public static void BackgroundEffect()
        {
            // Define the matrix characters and colors
            char[] matrixChars = { '0', '1' };
            ConsoleColor[] matrixColors = { ConsoleColor.Green, ConsoleColor.DarkGreen };

            var bufferWidth = Console.BufferWidth;
            var bufferHeight = Console.BufferHeight;

            var random = new Random();

            while (true)
            {
                // Create a buffer for the matrix effect
                var buffer = new char[bufferWidth][];
                var bufferColors = new ConsoleColor[bufferWidth][];

                for (var x = 0; x < bufferWidth; x++)
                {
                    buffer[x] = new char[bufferHeight];
                    bufferColors[x] = new ConsoleColor[bufferHeight];
                }

                // Generate random falling characters
                for (var x = 0; x < bufferWidth; x++)
                {
                    var length = random.Next(2, 10);
                    var y = random.Next(bufferHeight - length);

                    for (var i = 0; i < length; i++)
                    {
                        buffer[x][y + i] = matrixChars[random.Next(matrixChars.Length)];
                        bufferColors[x][y + i] = matrixColors[random.Next(matrixColors.Length)];
                    }
                }

                // Display the buffer content to create the matrix effect
                for (var x = 0; x < bufferWidth; x++)
                for (var y = 0; y < bufferHeight; y++)
                {
                    var character = buffer[x][y];
                    var color = bufferColors[x][y];

                    if (character != 0)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.ForegroundColor = color;
                        Console.Write(character);
                    }
                }

                // Sleep to control the speed of the effect
                Thread.Sleep(50); // Adjust this value to control the speed
            }
        }

        public static void DrawSection(int left, int top, int width, int height, string title, Func<string[]> getContentMethod)
        {
            Console.SetCursorPosition(left, top);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write(" " + title.PadRight(width - 1));
            Console.BackgroundColor = ConsoleColor.Black;

            for (var i = top + 1; i < top + height; i++)
            {
                Console.SetCursorPosition(left, i);
                Console.Write("║");
                Console.SetCursorPosition(left + width, i);
                Console.Write("║");
            }

            Console.SetCursorPosition(left, top + height);
            Console.Write("╚" + new string('═', width - 1) + "╝");

            // Call the provided getContentMethod to get the content to display
            var content = getContentMethod();

            // Display the provided content within the section
            for (var i = 0; i < content.Length; i++)
            {
                if (i < height - 2)
                {
                    Console.SetCursorPosition(left + 1, top + i + 1);
                    Console.Write(content[i].PadRight(width - 2));
                }
            }
        }

        public void Case0()
        {
            string[] Content =
            {
                ""
            };
            Thread.Sleep(1000);
            aaaBox.Clear();
            aaaBox.DisplayContent(Content);
            Thread.Sleep(4000);
            DisplaySystemInitializationOutput();
            aaaBox.Clear();

        }
        public void Case1()
        {
            aaaBox.Clear();
            string[] contentToDisplay =
            {
                "Reading package lists... Done",
                "Building dependency tree",
                "Reading state information... Done",
                "Suggested packages:"
            };

           
            var failedMessage = $"{ANSI_RED}Installation failed.";

            aaaBox.DisplayContent(contentToDisplay);
            Thread.Sleep(2000); // 

            aaaBox.Clear(); //
            aaaBox.DisplayContent(new[] { failedMessage });

            Thread.Sleep(2000);
        }
        public void Case2()
        {
            // Define the new content for the "Msg" box
            string[] newMsgContent =
            {
                        $"{ANSI_GREEN}Good choice, Looks like you're on the right track",
                        "I'd like to ask you some questions before we get started",
                        "Which distribution will you choose?"
                    };

            //Update the "Msg" box with the new content
            UpdateMsgBox(msgBox, newMsgContent);

            // Continue with the rest of the code
            // ...
            var distributionChoice = "";

            // Replace Console.ReadLine() with the following code
            var inputLeft = bbbBox.Left + 1; // Adjust the left position within the bbbBox
            var inputTop = bbbBox.Top + 1; // Adjust the top position within the bbbBox

            Console.SetCursorPosition(inputLeft, inputTop);
            distributionChoice = Console.ReadLine();

            // Display the user input in the bbbBox
            bbbBox.DisplayContent(new[] { "You chose: " + distributionChoice });

            string[] newMsgOneContent = { $"{distributionChoice}{ANSI_GREEN} Nice.It looks like you know what you're doing!!" };
        Label1:
            if (distributionChoice.Contains("kali", StringComparison.OrdinalIgnoreCase) || distributionChoice.Contains("Kali", StringComparison.OrdinalIgnoreCase))
            {
                UpdateMsgBox(msgBox, newMsgOneContent);
                Thread.Sleep(1500);
            }
            else if (distributionChoice == "")
            {
                var inputLeftEmpty = bbbBox.Left + 1; // Adjust the left position within the bbbBox
                var inputTopEmpty = bbbBox.Top + 1; // Adjust the top position within the bbbBox
                string[] emptyMsgContent =
                {
                                $"{ANSI_GREEN}!!",
                                $"{ANSI_GREEN}You must choose any distribution to continue"
                            };
                //Update the "Msg" box with the new content
                UpdateMsgBox(msgBox, emptyMsgContent);
                Console.SetCursorPosition(inputLeft, inputTop);
                distributionChoice = Console.ReadLine();

                goto Label1;
            }
            else
            {
                UpdateMsgBox(msgBox, $"{distributionChoice}{ANSI_GREEN}I'm not sure about it. But it is Ok!.");
            }

            Thread.Sleep(2000);
            UpdateMsgBox(msgBox, "Now sit relaxed and stay ready.");
            Thread.Sleep(2500);
            operationsObject.SimulateInstallation(aaaBox); // Call your method with the aaaBox as a parameter
            UpdateMsgBox(msgBox, $"{ANSI_YELLOW}Your Divice is Rady.");
            Thread.Sleep(1500);
            aaaBox.Clear();
            //
            Console.Clear();
            Thread.Sleep(2000);
            //Console.WriteLine("\n\n\n\n\n\n\n");
            string[] notificationMessage =
            {
                @"                                        ╭────────────────────────────────────────╮",
                @"                                       │   New Message Received                 │",
                @"                                       │   Hello,                               │",
                @"                                       │   You have a new message from Mr.Robt. │",
                @"                                       ╰────────────────────────────────────────╯"
            };
            operationsObject.FlashAndContinue(notificationMessage, 500);
            Console.ReadKey();
            Thread.Sleep(1000); // For example, sleep for 1 second between iterations
        }
        public void Case3()
        {
            aaaBox.Clear();
            var arrestMessage = $"{ANSI_RED}You are under arrest because that was so WRONG!!";
            for (var i = 0; i < 10; i++)
            {
                // Clear the aaaBox
                aaaBox.Clear();

                // Display the message if it's an even iteration
                if (i % 2 == 0)
                {
                    aaaBox.DisplayContent(new[] { arrestMessage });
                }

                Thread.Sleep(500); // Adjust the sleep duration as needed
            }

            // Clear the aaaBox after the flashing is complete
            aaaBox.Clear();
        }
    
    }
}