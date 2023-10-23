using System.Diagnostics;
using System.Text;

namespace MrRoboT;
static class ANSIColors
{
    public static string ANSI_DarkYellow = "\u001b[33;1m";
    public static string ANSI_DarkGreen = "\u001b[32;1m";
    public static string ANSI_DarkGray = "\u001b[30;1m";
    public static string ANSI_Reset = "\u001b[0m";

}

class Operations
{
    public void talProgress(int v, char identifier)
    {
        var totalProgress = 30;
        for (var i = 0; i <= totalProgress; i++)
        {
            Console.Write(" \r");
            Console.Write(new string('▐', i));
            Console.Write(new string(' ', totalProgress - i));
            Console.Write(identifier);
            Thread.Sleep(50);
        }
    }
    public void AnimateText(string text)
    {
        // Console window settings
        //Console.WindowHeight = 30;
        //Console.WindowWidth = 80;
        //Console.BufferHeight = 30;
        //Console.BufferWidth = 80;

        // Loop to animate text
        for (var i = Console.WindowHeight - 1; i >= 0; i--)
        {
            Console.Clear(); // Clear the console
            Console.SetCursorPosition(0, i); // Set cursor position for text display
            Console.WriteLine(text);
            Thread.Sleep(100); // Adjust the speed as needed
        }
    }
    public int ShowHorizontalMenu(string[] options, int topPosition)
    {
        var selectedIndex = 0;
        ConsoleKey key;

        do
        {
            // Calculate the left position based on the center of the console window
            var leftPosition = 47;

            Console.SetCursorPosition(leftPosition, topPosition);

            for (var i = 0; i < options.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                Console.Write($"  {options[i]}  "); // Use the text from the options array
                Console.ResetColor();
            }

            key = Console.ReadKey().Key;

            // Handle right arrow key to move to the next option
            if (key == ConsoleKey.RightArrow && selectedIndex < options.Length - 1)
                selectedIndex++;
            // Handle left arrow key to move to the previous option
            else if (key == ConsoleKey.LeftArrow && selectedIndex > 0) selectedIndex--;
        } while (key != ConsoleKey.Enter); // Continue until the Enter key is pressed

        return selectedIndex; // Return the index of the selected option
    }
    public string GetHiddenInput()
    {
        var input = "";
        ConsoleKeyInfo keyInfo;

        do
        {
            keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.Backspace && input.Length > 0)
            {
                input = input[..^1];
                Console.Write("\b \b");
            }
            else if (!char.IsControl(keyInfo.KeyChar))
            {
                input += keyInfo.KeyChar;
                Console.Write("*");
            }
        } while (keyInfo.Key != ConsoleKey.Enter);

        Console.WriteLine();
        return input;
    }
    public void PrintCenteredTextWithBorder(string text, char borderChar, ConsoleColor borderColor)
    {
        // Save the current console settings
        var originalBackgroundColor = Console.BackgroundColor;
        var originalForegroundColor = Console.ForegroundColor;
        var originalLeft = Console.CursorLeft;
        var originalTop = Console.CursorTop;

        var screenWidth = Console.WindowWidth;
        var screenHeight = Console.WindowHeight;

        var textWidth = text.Split('\n')[0].Length;
        var textHeight = text.Split('\n').Length;

        var borderPadding = 2; // Adjust this value to increase or decrease the border padding

        var leftPadding = Math.Max((screenWidth - textWidth - borderPadding) / 2, 0); // Subtract the border width from the calculation
        var topPadding = Math.Max((screenHeight - textHeight - borderPadding) / 2, 0); // Subtract the border height from the calculation

        // Set the console colors and clear the screen
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = borderColor;
        Console.Clear();

        Console.SetCursorPosition(leftPadding - 1, topPadding - 1);
        Console.Write(new string(borderChar, Math.Max(textWidth + borderPadding, 0))); // Ensure the width is not negative

        var lines = text.Split('\n');
        for (var i = 0; i < lines.Length; i++)
        {
            Console.SetCursorPosition(leftPadding - 1, topPadding + i);
            Console.Write(borderChar);
            Console.Write(lines[i]);
            Console.SetCursorPosition(leftPadding + textWidth, topPadding + i);
            Console.Write(borderChar);
        }

        Console.SetCursorPosition(leftPadding - 1, topPadding + textHeight);
        Console.Write(new string(borderChar, Math.Max(textWidth + borderPadding, 0))); // Ensure the width is not negative

        // Restore the original console settings
        Console.BackgroundColor = originalBackgroundColor;
        Console.ForegroundColor = originalForegroundColor;
        Console.SetCursorPosition(originalLeft, originalTop);
    }
    public void Matrix()
    {
        Console.WindowHeight = Console.WindowHeight;
        Console.WindowWidth = Console.WindowWidth;

        var matrixChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()_+<>?:{}|";
        var random = new Random();
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        while (stopwatch.Elapsed < TimeSpan.FromMinutes(0.03))
        {
            for (var i = 0; i < Console.WindowWidth; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(matrixChars[random.Next(matrixChars.Length)]);
                Console.SetCursorPosition(i / 4, random.Next(Console.WindowHeight));
                Console.Write("               Hh  ck                                 ");
                Console.SetCursorPosition(i * 1, random.Next(Console.WindowHeight));
                Console.Write(matrixChars[random.Next(matrixChars.Length)]);
                Console.WriteLine("                       Er ");

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.SetCursorPosition(i * 1, random.Next(Console.WindowHeight));
                Console.Write(matrixChars[random.Next(matrixChars.Length)]);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("M  3426   r h   H    Aa   Cc       Kk   eE   Rr");
                Console.WriteLine(matrixChars.Length);
            }

            Thread.Sleep(50);
        }

        stopwatch.Stop();
    }

    public void PrintCenteredText(int left, int top, string text)
    {
        var screenWidth = Console.WindowWidth;
        var textLength = text.Length;

        if (textLength > screenWidth)
        {
            Console.WriteLine(text);
        }
        else
        {
            var leftPadding = (screenWidth - textLength) / 2;
            Console.SetCursorPosition(left, top);

            foreach (var c in text)
            {
                Console.Write(c);
                Thread.Sleep(50);
            }

            Console.WriteLine();
        }
    }
    public void PrintCentered(string text)
    {
        var screenWidth = Console.WindowWidth;
        var stringWidth = text.Length;

        // Split the text into multiple lines if it's too long for the screen width
        if (stringWidth > screenWidth)
        {
            var lines = SplitTextIntoLines(text, screenWidth);
            foreach (var line in lines)
            {
                var leftPadding = (screenWidth - line.Length) / 2;
                Console.SetCursorPosition(leftPadding, Console.CursorTop);
                Console.WriteLine(line);
            }
        }
        else
        {
            var leftPadding = (screenWidth - stringWidth) / 2;
            Console.SetCursorPosition(leftPadding, Console.CursorTop);
            Console.WriteLine(text);
        }
    }
    private string[] SplitTextIntoLines(string text, int maxWidth)
    {
        var lines = new List<string>();
        var words = text.Split(' ');
        var currentLine = "";

        foreach (var word in words)
            if ((currentLine + word).Length <= maxWidth)
            {
                currentLine += word + " ";
            }
            else
            {
                lines.Add(currentLine.Trim());
                currentLine = word + " ";
            }

        if (!string.IsNullOrWhiteSpace(currentLine)) lines.Add(currentLine.Trim());

        return lines.ToArray();
    }
    public int PlayAgainMenu()
    {
        //PrintCentered("Would you like to play again? Y/N");
        //var yesNo = "";
        //var leftPadding3 = (Console.WindowWidth - yesNo.Length) / 2;
        //Console.SetCursorPosition(leftPadding3, Console.CursorTop);
        //yesNo = Console.ReadLine().ToLower();
        //if (yesNo == "y") return 0; // Return 0 for "Y" to continue playing
        ////break;
        //if (yesNo == "n")
        //{
        //    Console.Clear();
        //    Console.ForegroundColor = ConsoleColor.Blue;
        //    PrintCenteredText(@" _____           _ _           ");
        //    PrintCenteredText(@"|   __|___ ___ _| | |_ _ _ ___ ");
        //    PrintCenteredText(@"|  |  | . | . | . | . | | | -_|");
        //    PrintCenteredText(@"|_____|___|___|___|___|_  |___|");
        //    PrintCenteredText(@"                      |___|    ");
        //    Console.ForegroundColor = ConsoleColor.White;
        //    PrintCenteredText("Thank you for playing!");
        //    Thread.Sleep(2000); // Wait for 2 seconds before exiting
        //    Environment.Exit(0); // Exit the game when "N" is selected
        //}
        //else
        //{
        //    PrintCenteredText("Invalid choice. Please select 'Y' or 'N'.");
        //    return PlayAgainMenu(); // Repeat the menu if an invalid choice is made
        //}

        return -1; // Return -1 for any other input
    } //1/5 good 
    public void PrintChatStyle(string text)
    {
        Console.ForegroundColor = ConsoleColor.Green; // Set text color
        Console.Write("Mr.Robot: ");

        foreach (var c in text)
        {
            Console.Write(c);
            Thread.Sleep(50); // Adjust the speed as needed (50 milliseconds in this example)
        }

        Console.ResetColor(); // Reset text color
        Console.WriteLine(); // Add a newline to simulate a chat message
    }
    public void FlashAndContinue(string[] lines, int interval)
    {
        var originalLeft = 400 - lines[0].Length / 2;
        var originalTop = Console.WindowHeight / 2 - lines.Length / 2;
        var isFlashing = true;
        var totalLines = lines.Length;
        var currentLine = totalLines - 1; // Start flashing from the last line

        while (isFlashing)
        {
            Console.SetCursorPosition(originalLeft, originalTop);
            for (var i = 0; i < totalLines; i++) Console.Write(new string(' ', lines[i].Length)); // Clear the line

            Thread.Sleep(interval);

            Console.SetCursorPosition(originalLeft, originalTop);
            for (var i = 0; i < totalLines; i++)
            {
                Console.Write(lines[i]); // Display the line
                if (i < totalLines - 1) Console.WriteLine(); // Add newline for all lines except the last one
            }

            Thread.Sleep(interval);

            if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter) isFlashing = false;
            Console.Clear();
        }
    }
    public void FlashScreen(int durationMilliseconds)
    {
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.White;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Black;

        Thread.Sleep(durationMilliseconds);

        Console.ResetColor();
        Console.Clear();
    }
    public void Chatting()
    {
        string username = LoginManager.userName;
        Console.OutputEncoding = Encoding.Unicode;
        var operationsObject = new Operations();

        Console.OutputEncoding = Encoding.Unicode;
        var continueLoop1 = true;

        while (continueLoop1)
        {
            Thread.Sleep(2000);

            Console.Clear();
            Thread.Sleep(2500);
            Console.OutputEncoding = Encoding.UTF8;

            DisplayMessage("Darlene", "I see he has opened the message.");
            Thread.Sleep(3000);

            DisplayMessage("Mr.Robot", "This means he has accepted the first mission.");
            Thread.Sleep(2876);

            DisplayMessage("Darlene", "Is he with us now?");
            Thread.Sleep(3001);

            DisplayMessage("Mr.Robot", "Not yet or yes, I don't know. We will see later.");
            Thread.Sleep(3000);

            DisplayMessage("Darlene", "Should we ask him?");
            Thread.Sleep(2550);

            DisplayMessage("Mr.Robot", "You ask him.");
            Thread.Sleep(2000);

            DisplayMessage("Darlene", "Why me? You're the one who invited him!");
            Thread.Sleep(2950);

            DisplayMessage("Mr.Robot", "What does he do, see all this and still no shit.");
            Thread.Sleep(2750);

            DisplayMessage("Mr.Robot", "What are you doing? Say something.");
            Thread.Sleep(2000);

            Console.Write(ANSIColors.ANSI_DarkGray);
            Console.Write($"[{ username}]");
            Console.ResetColor();
            Console.ReadLine();

            Thread.Sleep(3050);

            DisplayMessage("Mr.Robot", "Finally, you said something.");
            Thread.Sleep(2000);

            DisplayMessage("Darlene", "Do you know what's happening?");
            Console.Write(ANSIColors.ANSI_DarkGray);
            Console.Write($"[{username}]");
            Console.ResetColor();
            var urAns = Console.ReadLine();


            string[] words = urAns.Split(' ');
            bool containsYes = words.Any(word => word.Equals("yes", StringComparison.OrdinalIgnoreCase));

            if (words.Length < 5 || (containsYes && words.Length >= 5) || urAns.Contains("yes", StringComparison.OrdinalIgnoreCase))
            {
                Thread.Sleep(2550);
                DisplayMessage("Darlene", "Are you sure that you can??");
                Console.Write(ANSIColors.ANSI_DarkGray);
                Console.Write($"[{username}]");
                Console.ResetColor();
                var urAns1 = Console.ReadLine();

                if (urAns1.Equals("yes", StringComparison.OrdinalIgnoreCase) || urAns1.Equals("Yes", StringComparison.OrdinalIgnoreCase))
                {
                    Thread.Sleep(3050);
                    DisplayMessage("Mr.Robot", "So I will send an information. Read it carefully and try to reach a solution.");
                    Thread.Sleep(200);
                    ProgressBar(50, ' ');
                    Thread.Sleep(2000);
                    Console.Write(ANSIColors.ANSI_DarkGray);
                    Console.WriteLine("File has been sent.");
                    Console.Write("Press Enter to open it.");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.Clear();
                    break;
                }
                else
                {
                    Thread.Sleep(4050);
                    DisplayMessage("Mr.Robot", "Goodbye!!");
                    Thread.Sleep(2500);

                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();

                    var errorMessage = "Your PC ran into a problem and needs to restart.";
                    Console.SetCursorPosition((Console.WindowWidth - errorMessage.Length) / 2, Console.WindowHeight / 2);
                    Console.WriteLine(errorMessage);

                    Thread.Sleep(3000);
                    Environment.Exit(0);
                }
            }
            else
            {
                Thread.Sleep(4050);
                DisplayMessage("Mr.Robot", "I told you he would let us down!");
                Thread.Sleep(5000);

                DisplayMessage("Darlene", "I do not know what to say.");
                Thread.Sleep(3000);

                DisplayMessage("Darlene", "We are sorry, we do not believe you are capable.");
                Thread.Sleep(3000);

                Console.Clear();
                Console.Title = "Blue Screen of Death";

                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Clear();

                Console.WriteLine("A problem has been detected and Windows has been shut down");
                Console.WriteLine("to prevent damage to your computer.");
                Console.WriteLine();
                Console.WriteLine("The problem seems to be caused by the following file: YOUR_FILE");
                Console.WriteLine();
                Console.WriteLine("If this is the first time you've seen this stop error screen,");
                Console.WriteLine("restart your computer. If this screen appears again, follow");
                Console.WriteLine("these steps:");
                Console.WriteLine();
                Console.WriteLine("Check to make sure any new hardware or software is properly installed.");
                Console.WriteLine("If this is a new installation, ask your hardware or software");
                Console.WriteLine("manufacturer for any Windows updates you might need.");
                Console.WriteLine();
                Console.WriteLine("If problems continue, disable or remove any newly installed");
                Console.WriteLine("hardware or software. Disable BIOS memory options such as caching");
                Console.WriteLine("or shadowing. If you need to use Safe Mode to remove or disable");
                Console.WriteLine("components, restart your computer, press F8 to select Advanced");
                Console.WriteLine("Startup Options, and then select Safe Mode.");
                Console.WriteLine();
                Console.WriteLine("Technical information:");
                Console.WriteLine();
                Console.WriteLine("*** STOP: 0x00000000 (0x00000000, 0x00000000, 0x00000000, 0x00000000)");
                Console.WriteLine();
                Console.WriteLine("Beginning dump of physical memory");
                Console.WriteLine("Physical memory dump complete.");
                Console.WriteLine("Contact your system administrator or technical support group");
                Console.WriteLine("for further assistance.");
                Console.WriteLine();
                Console.WriteLine("Press any key to reboot.");

                Console.ReadKey();
                Environment.Exit(0);
            }

        }
    }
    public void ScanForVulnerabilities()


    {
        Console.WriteLine("Welcome to OpenVAS Wi-Fi Scanner");
        Console.WriteLine("Scanning for Wi-Fi networks...");

        // Simulate scanning for available Wi-Fi networks
        string[] availableNetworks = { "PublicWi-Fi", "CoffeeShopNet", "AirportFree", "HotelGuestNet" };

        Console.WriteLine("Available Wi-Fi networks:");
        for (int i = 0; i < availableNetworks.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {availableNetworks[i]}");
        }

        Console.Write("Select a Wi-Fi network to scan (1-4): ");
        int selectedNetworkIndex = int.Parse(Console.ReadLine()) - 1;

        string selectedNetwork = availableNetworks[selectedNetworkIndex];

        Console.WriteLine($"Scanning network '{selectedNetwork}' for vulnerabilities...");

        // Simulate running OpenVAS scan
        Console.WriteLine("Running OpenVAS scan...");
        Console.WriteLine("Vulnerabilities found:");
        Console.WriteLine("1. Weak WPA2 Encryption");
        Console.WriteLine("2. Open Port 80");
        Console.WriteLine("3. Outdated Router Firmware");

        Console.Write("Select a vulnerability to exploit (1-3): ");
        int selectedVulnerabilityIndex = int.Parse(Console.ReadLine());

        if (selectedVulnerabilityIndex >= 1 && selectedVulnerabilityIndex <= 3)
        {
            string selectedVulnerability = $"Vulnerability {selectedVulnerabilityIndex}";
            Console.WriteLine($"Exploiting {selectedVulnerability} on network '{selectedNetwork}'...");

            // الآن نسمح للاعب بإدخال أوامر حقيقية
            Console.WriteLine("Enter the command to exploit the vulnerability:");
            string exploitCommand = Console.ReadLine();

            // تحقق من صحة الأمر وقم بتنفيذه إذا كان صحيحًا
            if (ExecuteExploit(selectedVulnerabilityIndex, exploitCommand))
            {
                Console.WriteLine($"Successfully exploited {selectedVulnerability} for '{selectedNetwork}'!");
            }
            else
            {
                Console.WriteLine($"Exploit failed for {selectedVulnerability}. Exiting.");
            }
        }
        else
        {
            Console.WriteLine("Invalid vulnerability selection. Exiting.");
        }

        Console.WriteLine("Thank you for using OpenVAS Wi-Fi Scanner!");
    }
    static bool ExecuteExploit(int vulnerabilityIndex, string exploitCommand)
    {
        switch (vulnerabilityIndex)
        {
            case 1:
                // تحقق من الأمر وقم بتنفيذ الثغرة لضعف التشفير WPA2
                if (exploitCommand == "exploit_wpa2")
                {
                    // قم بتنفيذ الثغرة وإرجاع نتيجة نجاحها أو فشلها
                    return ExploitWeakWPA2();
                }
                break;
            case 2:
                // تحقق من الأمر وقم بتنفيذ الثغرة لفتح المنفذ 80
                if (exploitCommand == "exploit_port_80")
                {
                    // قم بتنفيذ الثغرة وإرجاع نتيجة نجاحها أو فشلها
                    return ExploitOpenPort80();
                }
                break;
            case 3:
                // تحقق من الأمر وقم بتنفيذ تحديث البرامج الثابتة للجهاز
                if (exploitCommand == "update_firmware")
                {
                    // قم بتنفيذ تحديث البرامج الثابتة وإرجاع نتيجة نجاحه أو فشله
                    return UpdateRouterFirmware();
                }
                break;
            default:
                break;
        }

        // إذا كان الأمر غير صحيحًا أو غير مدعومًا، اعتبره فشلاً
        return false;
        // تنفيذ الثغرة لضعف التشفير WPA2
        static bool ExploitWeakWPA2()
        {
            Console.WriteLine("Exploiting Weak WPA2 Encryption...");
            // هنا يمكنك تنفيذ الأمر الفعلي لاختراق ضعف التشفير WPA2
            // إذا نجح الاختراق، قم بإرجاع true، وإلا قم بإرجاع false
            return true;
        }

        // تنفيذ الثغرة لفتح المنفذ 80
        static bool ExploitOpenPort80()
        {
            Console.WriteLine("Exploiting Open Port 80...");
            // هنا يمكنك تنفيذ الأمر الفعلي لفتح المنفذ 80
            // إذا نجح الاختراق، قم بإرجاع true، وإلا قم بإرجاع false
            return true;
        }

        // تنفيذ تحديث البرامج الثابتة للجهاز
        static bool UpdateRouterFirmware()
        {
            Console.WriteLine("Updating Router Firmware...");
            // هنا يمكنك تنفيذ الأمر الفعلي لتحديث البرامج الثابتة للجهاز
            // إذا نجح التحديث، قم بإرجاع true، وإلا قم بإرجاع false
            return true;
        }
    }
    public void InstallMetasploit()
    {
        Console.Clear();
        Console.WriteLine("Running: 'sudo apt-get install metasploit-framework'");
        Thread.Sleep(1500);

        Console.WriteLine("Reading package lists... Done");
        Thread.Sleep(1000);

        Console.WriteLine("Building dependency tree... Done");
        Thread.Sleep(1000);

        Console.WriteLine("Reading state information... Done");
        Thread.Sleep(1000);

        Console.WriteLine("The following NEW packages will be installed:");
        Console.WriteLine("  metasploit-framework ...");
        Thread.Sleep(1500);

        Console.WriteLine("0 upgraded, 1 newly installed, 0 to remove and 0 not upgraded.");
        Thread.Sleep(1500);

        Console.WriteLine("Need to get 200 MB of archives.");
        Thread.Sleep(1500);

        Console.WriteLine("After this operation, 400 MB of additional disk space will be used.");
        Thread.Sleep(1500);

        Console.WriteLine("Get:1 http://http.kali.org/kali kali-rolling/main amd64 metasploit-framework all 6.0.0 [200 MB]");
        Thread.Sleep(2500);

        Console.WriteLine("Fetched 200 MB in 5s (40.0 MB/s)");
        Thread.Sleep(1000);

        Console.WriteLine("Selecting previously unselected package metasploit-framework.");
        Thread.Sleep(1500);

        Console.WriteLine("(Reading database ... 123456 files and directories currently installed.)");
        Thread.Sleep(1500);

        Console.WriteLine("Preparing to unpack .../metasploit-framework_6.0.0_all.deb ...");
        Thread.Sleep(1500);

        Console.WriteLine("Unpacking metasploit-framework (6.0.0) ...");
        Thread.Sleep(2000);

        Console.WriteLine("Setting up metasploit-framework (6.0.0) ...");
        Thread.Sleep(2000);

        Console.WriteLine("Processing triggers for libc-bin (2.27-3kali.4) ...");
        Thread.Sleep(2000);

        Console.WriteLine("Processing triggers for systemd (237-3kali.47) ...");
        Thread.Sleep(2000);

        Console.WriteLine("Processing triggers for man-db (2.8.3-2kali.1) ...");
        Thread.Sleep(2000);

        Console.WriteLine("Metasploit has been successfully installed on Kali Linux!");
        Thread.Sleep(1500);

        Console.WriteLine("You can now use the 'msfconsole' command to start Metasploit.");
        Thread.Sleep(1500);

        Console.WriteLine("root@Kali: Installation completed successfully. You are now ready to use Metasploit.");
        MetasploitGame metasploitGame = new MetasploitGame();
        MetasploitGame metasploit = new MetasploitGame();

    }
    public int ShowVMenu(string[] options, int topPosition)
    {
        var selectedIndex = 0;
        ConsoleKey key;

        do
        {
            // Calculate the center position based on the console window height
            var centerY = Console.WindowHeight / 2;

            for (var i = 0; i < options.Length; i++)
            {
                // Calculate the top position for each option
                var optionTop = centerY + i - options.Length / 2;

                Console.SetCursorPosition(Console.WindowWidth / 2 - options[i].Length / 2, optionTop);

                if (i == selectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                Console.WriteLine(options[i]); // Use the text from the options array
                Console.ResetColor();
            }

            key = Console.ReadKey().Key;

            // Handle down arrow key to move to the next option
            if (key == ConsoleKey.DownArrow && selectedIndex < options.Length - 1)
                selectedIndex++;
            // Handle up arrow key to move to the previous option
            else if (key == ConsoleKey.UpArrow && selectedIndex > 0) selectedIndex--;
        } while (key != ConsoleKey.Enter); // Continue until the Enter key is pressed

        return selectedIndex; // Return the index of the selected option
    }
    public void VASConsoleExpert()
    {
        Console.Clear();
        //Console.WriteLine("Welcome to OpenVAS Expert Simulator!");
        Console.WriteLine("Type a command to show you a list of available commands.");

        var vulnerabilities = new List<string>
            {
                "Vulnerability 1",
                "Vulnerability 2",
                "Vulnerability 3",
                "Vulnerability 4",
                "Vulnerability 5",
                "Vulnerability 6",
                "Vulnerability 7",
                "Vulnerability 8",
                "Vulnerability 9",
                "Vulnerability 10 (The Real One)"
            };
        var hosts = new List<string>();
        var isRunning = true;
        var attempts = 0;
        var startTime = DateTime.Now;

        bool nmapScanned = false; //  nmap
        bool scanCompleted = false; //  OpenVAS

        while (isRunning)
        {
            Console.Write("> ");
            string input = Console.ReadLine();

            switch (input.ToLower())
            {
                case "open":
                    Console.WriteLine("Initializing OpenVAS...");
                    Thread.Sleep(1000); // Simulate initialization time.
                    Console.WriteLine("OpenVAS initialized successfully.");
                    break;
                case "nmap":
                    if (!nmapScanned)
                    {
                        Console.WriteLine("Enter target host (IP or domain) to scan with nmap:");
                        string targetHostNmap = Console.ReadLine();
                        Console.WriteLine($"Scanning {targetHostNmap} with nmap...");
                        Thread.Sleep(2000); // Simulate scanning time.
                        Console.WriteLine($"nmap scan of {targetHostNmap} complete.");
                        nmapScanned = true; //  nmap
                    }
                    else
                    {
                        Console.WriteLine("You've already scanned with nmap. Use the result with 'scan' command.");
                    }
                    break;
                case "scan":
                    if (nmapScanned && !scanCompleted)
                    {
                        Console.WriteLine("Enter target host (IP or domain) from nmap results:");
                        string targetHost = Console.ReadLine();
                        hosts.Add(targetHost);
                        Console.WriteLine($"Scanning {targetHost} for vulnerabilities with OpenVAS...");
                        Thread.Sleep(2000); // Simulate scanning time.
                        Console.WriteLine($"Scan of {targetHost} complete.");
                        Console.WriteLine("Detected vulnerabilities:");
                        foreach (var vuln in vulnerabilities)
                        {
                            Console.WriteLine("- " + vuln);
                            string targetIpAddress = "192.168.0.1";
                            Console.WriteLine("Active Internet connections (servers and established)\r\nProto Recv-Q Send-Q Local Address           Foreign Address         State       PID/Program name");
                            Console.WriteLine("tcp        0      0 127.0.0.1:6379          0.0.0.0:*               LISTEN      3692/redis-server 1");
                            Console.WriteLine("tcp        0      0 0.0.0.0:9391            0.0.0.0:*               LISTEN      13806/openvassd: Wa");
                            Console.WriteLine("tcp        0      0 0.0.0.0:1337            0.0.0.0:*               LISTEN      3656/sshd");
                            Console.WriteLine("tcp6       0      0 :::9390                 :::*                    LISTEN      13804/openvasmd");
                            Console.WriteLine("tcp6       0      0 :::443                  :::*                    LISTEN      28020/gsad");

                        }
                        scanCompleted = true; //  OpenVAS
                    }
                    else if (!nmapScanned)
                    {
                        Console.WriteLine("You must scan with nmap first using 'nmap' command.");
                    }
                    else if (scanCompleted)
                    {
                        Console.WriteLine("You've already completed the OpenVAS scan. Try 'exploit' now.");
                    }
                    break;
                case "list":
                    Console.WriteLine("List of scanned hosts:");
                    foreach (var host in hosts)
                    {
                        Console.WriteLine("- " + host);
                    }
                    break;
                case "exploit":
                    if (scanCompleted)
                    {
                        Console.WriteLine("Enter the target vulnerability number to exploit:");
                        int vulnIndex;
                        if (int.TryParse(Console.ReadLine(), out vulnIndex) && vulnIndex >= 0 && vulnIndex < vulnerabilities.Count)
                        {
                            Console.WriteLine($"Exploiting vulnerability: {vulnerabilities[vulnIndex]}");
                            Thread.Sleep(3000); // Simulate exploitation time.
                            Console.WriteLine($"Vulnerability {vulnIndex} exploited successfully.");
                            if (vulnerabilities[vulnIndex] == "Vulnerability 10 (The Real One)")
                            {
                                Console.WriteLine("Congratulations! You have successfully exploited the real vulnerability.");
                                Console.WriteLine("You are now a certified OpenVAS Expert!");
                                isRunning = false;
                            }
                            else
                            {
                                Console.WriteLine("Exploitation failed. Keep searching for the real vulnerability.");
                                vulnerabilities.RemoveAt(vulnIndex); // Remove the exploited vulnerability.
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid vulnerability number.");
                        }
                        attempts++;
                    }
                    else
                    {
                        Console.WriteLine("You must complete the OpenVAS scan using 'scan' command before exploiting vulnerabilities.");
                    }
                    break;
                case "exit":
                    isRunning = false;
                    break;
                case "help":
                    Console.WriteLine("Available commands:");
                    Console.WriteLine("- open: Initialize OpenVAS.");
                    Console.WriteLine("- nmap: Scan with nmap to find target IP.");
                    Console.WriteLine("- scan: Start a vulnerability scan with OpenVAS.");
                    Console.WriteLine("- list: List scanned hosts.");
                    Console.WriteLine("- exploit: Exploit a detected vulnerability.");
                    Console.WriteLine("- exit: Exit the program.");
                    break;
                default:
                    Console.WriteLine("Unknown command. Type 'help' for available commands.");
                    break;
            }
        }

        // Time
        TimeSpan elapsedTime = DateTime.Now - startTime;
        Console.WriteLine($"You completed the game in {elapsedTime.TotalSeconds} seconds.");
        Console.WriteLine($"You made {attempts} attempts.");

        if (attempts <= 2)
        {
            Console.WriteLine("Congratulations! You are an OpenVAS Expert!");
        }
        else
        {
            Console.WriteLine("You couldn't solve the challenge in time. Better luck next time!");
        }

        Console.WriteLine("Goodbye!");
    }
    static void DisplayMessage(string sender, string message)
    {

        string username = LoginManager.userName;
        string senderColor = ANSIColors.ANSI_Reset; // Reset color after sender
        if (sender == "Darlene")
        {
            senderColor = ANSIColors.ANSI_DarkYellow;
        }
        else if (sender == "Mr.Robot")
        {
            senderColor = ANSIColors.ANSI_DarkGreen;
        }
        if (sender != "Mr.Robot")
        {
            sender = username;
            senderColor = ANSIColors.ANSI_DarkGray;

        }


        Console.Write(senderColor);
        Console.Write($"[{sender}]");
        Console.ResetColor(); // Reset color after sender
        Console.WriteLine($" > {message}");
    }
    static void ProgressBar(int progress, char icon)
    {
        var totalProgress = 30;
        for (var i = 0; i <= totalProgress; i++)
        {
            Console.Write(" \r");
            Console.Write(new string('▐', i));
            Console.Write(new string(' ', totalProgress - i));
            Console.Write(icon);
            Thread.Sleep(50);
        }
    }

    int ShowVLMenu(string[] options)
    {
        var selectedIndex = 0;
        ConsoleKey key;

        do
        {
            // Calculate the center position based on the console window height
            var centerY = Console.WindowHeight / 2;
            var centerX = Console.BufferWidth / 2;

            for (var i = 0; i < options.Length; i++)
            {
                // Calculate the top position for each option
                var optionTop = i;
                var optionLeft = 0;


                Console.SetCursorPosition(optionLeft, optionTop);
                if (i == selectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                Console.WriteLine(options[i]); // Use the text from the options array
                Console.ResetColor();
            }

            key = Console.ReadKey().Key;

            // Handle down arrow key to move to the next option
            if (key == ConsoleKey.DownArrow && selectedIndex < options.Length - 1)
                selectedIndex++;
            // Handle up arrow key to move to the previous option
            else if (key == ConsoleKey.UpArrow && selectedIndex > 0) selectedIndex--;
        } while (key != ConsoleKey.Enter); // Continue until the Enter key is pressed

        return selectedIndex; // Return the index of the selected option
    }

     public void SimulateInstallation(Box aaaBox)
     {
         ConsoleKeyInfo keyInfo;

         aaaBox.Clear();

        string[] installationContent = new string[]
   {
       $"The device started initializing",
       $" ",
        "Reading package lists... Done",
        "Building dependency tree",
        "Reading state information... Done",
        "Suggested packages:",
        "ctags vim-doc vim-scripts",
        "The following NEW packages will be installed:",
        "vim",
        "0 upgraded, 1 newly installed, 0 to remove and 82 not upgraded.",
        "Inst vim (2:8.0.1453-1Kali1.1 Kali:18.04/bionic-updates, Kali:18.04/bionic-security [amd64])",
        "Conf vim (2:8.0.1453-1Kali1.1 Kali:18.04/bionic-updates, Kali:18.04/bionic-security [amd64])",
        "Reading package lists... Done",
        "Building dependency tree",
        "Reading state information... Done",
        "The following packages will be REMOVED:",
        "vim",
        "0 upgraded, 0 newly installed, 1 to remove and 82 not upgraded.",
        "Remv vim [2:8.0.1453-1Kali1.1]",
        "Reading package lists... Done",
        "Building dependency tree",
        "Reading state information... Done",
        "Calculating upgrade... Done",
        "The following packages will be upgraded:",
        "apt apt-utils base-files bash bsdutils cloud-init console-setup console-setup-linux debconf debconf-i18n dmeventd dmsetup dpkg fdisk friendly-recovery grep",
        "grub-common grub-pc grub-pc-bin grub2-common initramfs-tools initramfs-tools-bin initramfs-tools-core iputils-ping iputils-tracepath keyboard-configuration",
        "landscape-common language-selector-common libapt-inst2.0 libapt-pkg5.0 libblkid1 libdevmapper-event1.02.1 libdevmapper1.02.1 libdrm-common libdrm2 libfdisk1",
        "libldap-2.4-2 libldap-common liblvm2app2.2 liblvm2cmd2.02 libmount1 libnss-systemd libpam-systemd libprocps6 libpython3.6 libpython3.6-minimal libpython3.6-stdlib",
        "libsmartcols1 libsystemd0 libudev1 libuuid1 linux-firmware lvm2 mdadm mount netplan.io nplan open-vm-tools procps python-apt-common python3-apt python3-debconf",
        "python3-distupgrade python3-gdbm python3-software-properties python3.6 python3.6-minimal snapd software-properties-common sosreport systemd systemd-sysv thermald",
        "Kali-minimal Kali-release-upgrader-core Kali-standard udev unattended-upgrades update-notifier-common util-linux uuid-runtime xkb-data",
        "82 upgraded, 0 newly installed, 0 to remove and 0 not upgraded.",
        "Inst base-files [10.1Kali2.4] (10.1Kali2.7 Kali:18.04/bionic-updates [amd64])",
        "Conf base-files (10.1Kali2.7 Kali:18.04/bionic-updates [amd64])",
        "Inst bash [4.4.18-2Kali1] (4.4.18-2Kali1.2 Kali:18.04/bionic-updates [amd64])",
        "Conf bash (4.4.18-2Kali1.2 Kali:18.04/bionic-updates [amd64])",
        "Inst bsdutils [1:2.31.1-0.4Kali3.3] (1:2.31.1-0.4Kali3.4 Kali:18.04/bionic-updates [amd64])",
        "..."
       // Add the remaining installation content
   };


        int maxLines = aaaBox.Height - 2;

         int currentIndex = 0;
         while (currentIndex < installationContent.Length)
         {
             aaaBox.Clear();

             var chunk = new List<string>();
             int remainingSpace = maxLines;

             while (currentIndex < installationContent.Length && remainingSpace > 0)
             {
                 string line = installationContent[currentIndex];
                 if (line.Length > aaaBox.Width - 2)
                 {
                     while (line.Length > aaaBox.Width - 2)
                     {
                         chunk.Add(line.Substring(0, aaaBox.Width - 2));
                         line = line.Substring(aaaBox.Width - 2);
                     }
                     chunk.Add(line);
                 }
                 else
                 {
                     chunk.Add(line);
                 }

                 currentIndex++;
                 remainingSpace--;
             }

             aaaBox.DisplayContent(chunk.ToArray());

             for (int i = 0; i < 2500; i += 100)
             {
                 if (Console.KeyAvailable)
                 {
                     keyInfo = Console.ReadKey(intercept: true);
                     if (keyInfo.Key == ConsoleKey.DownArrow)
                     {
                         i += 500;
                     }
                 }

                 Thread.Sleep(100);
             }

             Thread.Sleep(2500);
         }
     }


}




