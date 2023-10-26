using MrRoboT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using static System.Net.Mime.MediaTypeNames;

namespace game
{
    internal class InterFaceTow
    {
        private static readonly Operations operationsObject = new();
        private readonly Box aaaBox;
        private readonly Box bbbBox;
        // Create an instance of the Box class for each box
        private readonly Box msgBox;
        private Box zzzBox;
        private Box eeeBox;
        private Box oooBox;


        public InterFaceTow()
        
        {
            Console.OutputEncoding = Encoding.Unicode;
            msgBox = new Box(2, 2, 75, 23, ConsoleColor.DarkGreen, ConsoleColor.DarkGreen, "Msg");
            bbbBox = new Box(2, 25, 75, 2, ConsoleColor.DarkGreen, ConsoleColor.DarkGreen, "BBB");

        }
        public void Run()
        {
            InterFace interFace = new InterFace();
            InterFaceTow interFaceTow = new InterFaceTow();
            Console.WindowWidth = 2000;
            Console.WindowHeight = 2000;
            InterFace.ConsoleApp.DrawSection(0, 0, 119, 28, "");
            Console.OutputEncoding = Encoding.Unicode;

            // Define the content for each box
            string[] msgContent =
            {
                //"This is a message box."
            };

            //string[] aaaContent =
            //{
            //    @"⠀"
            //};

            string[] bbbContent =
            {
                //"BBB box content line 1",
                //"BBB box content line 2"
            };
           
            // Display the content in each box
            msgBox.DisplayContent(msgContent);
            bbbBox.DisplayContent(bbbContent);

            Chatting(msgBox);








            Thread.Sleep(1000);
            Console.Clear();
            InterFace.ConsoleApp.DrawSection(0, 0, 119, 28, "");
            zzzBox = new Box(42, 2, 75, 24, ConsoleColor.DarkGreen, ConsoleColor.DarkGreen, "Msg");
            eeeBox = new Box(5, 2, 35, 17, ConsoleColor.DarkGreen, ConsoleColor.DarkGreen, "Msg");
            oooBox = new Box(5, 20, 37, 7, ConsoleColor.DarkGreen, ConsoleColor.DarkGreen, "Msg");





            MetasploitGame metasploitGame = new MetasploitGame();
            string[] oooContent =
            {
                "",
                " 0x00 0x41 0x42 0x43 0x44 0x45 0x49 ",
                " 0x46 0x47 0x48 0x49 0x4A 0x4B 0x4D",
                " 0x56 0x43 Ex11 0x49 0x4A 0x4B 0x56",
                " 0x4C 0x4D 0x4E 0x4F 0x50 0x51 0x53",
                " 0x00 0x41 0x42 0x43 0x44 0x45 0x49 ",
                " 0x4C 0x4D 0x4E 0x4F 0x50 0x51 0x54",
                " Ax52 0x53 0x54 0x55 Cx56 0x57 0x00"

            };
            oooBox.DisplayContent(oooContent);

            zzzBox.DisplayContent(bbbContent);
            eeeBox.DisplayContent(bbbContent);

            string[] newMsgContent =
            {
                //"",

                //"The first mission",
            };
            UpdateMsgBox(zzzBox, newMsgContent);
            Thread.Sleep(2000);

            zzzBox.Clear();

            string[] helpContent =
            {
                " ",
                "There is an abandoned warehouse that we will use as ",
                "our headquarters. It is very convenient as it is far " ,
                "from the crowd and no one is there most of the time,it is quiet",
                "and most importantly, it is dark like our days. Your task is to",
                "prepare the headquarters for us.",
                "We cannot make any mistake whatsoever, and after this step you",
                "withdraw. You are now about to create your army. You may be",
                "uninterested or you may mock this mission, but changing the" ,
                " world depends on you. So my directions are to you",
                "There is an electric gate at the entrance, which is not" ,
                " guarded by anyone, and the fence cannot be penetrated because it is",
                "very high. I have done research on the place and how the portal works",
                "have done research on the place and how the portal works" ,
                "so I will make it easier for you or consider it cooperation between us.",
                "You must provide us with the ability to pass through it." ,
                "I forgot to tell you that it works via Bluetooth.",
                "I do not know if this thing is important to you.",
                "Press Enter to start the task"

            };
            UpdateMsgBox(zzzBox, helpContent);
            Console.ReadKey();
            zzzBox.Clear();

            string[] newMsgContent1 =
            {
                $"Now You have to choose which tools you will help the scenario",
                "Here are some tools that I was able to get them from a Dark Web.",
                "Try to find what suits you"
            };
            UpdateMsgBox(zzzBox, newMsgContent1);
            Thread.Sleep(2000);

            zzzBox.Clear();
            Label:

            string[] menuOptions =
                { "Scan for Vulnerabilities ", "Social Engineering", "Sneak Inside" };
            var selectedIndex = operationsObject.ShowHorizontalMenu(menuOptions,5);

            switch (selectedIndex)
            {
                case 0:
                string[] newMsgContent2 =
                {
                    "Ok, I'm interested",
                    "Try to Log in as Admin Permissions"
                };
                UpdateMsgBox(zzzBox, newMsgContent2);

                // Replace Console.ReadLine() with the following code
                var inputLeft =  18; // Adjust the left position within the bbbBox
                var inputTop = 5; // Adjust the top position within the bbbBox
                Console.SetCursorPosition(inputLeft, inputTop);
                string sudo1 = Console.ReadLine();

                    if (sudo1 == "sudo")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        //root pass
                        UpdateMsgBox(eeeBox, "password for kali:");
                        
                        // Replace Console.ReadLine() with the following code
                         inputLeft = 18; // Adjust the left position within the bbbBox
                        inputTop = 5; // Adjust the top position within the bbbBox
                        Console.SetCursorPosition(inputLeft, inputTop);
                        string passwordInput = Console.ReadLine();

                        if (passwordInput == "root")
                        {
                           zzzBox.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            UpdateMsgBox(eeeBox, "Authentication successful.");
                            Thread.Sleep(1000);
                            UpdateMsgBox(eeeBox, "Root access granted.");
                            Thread.Sleep(1000);
                            UpdateMsgBox(eeeBox, "root@Mr.Robot:");
                            var textLeft = zzzBox.Left + zzzBox.Width / 2 - "-root@Mr.Robot:I'm impressed with the level you've reached.".Length / 2;
                            var textTop = zzzBox.Top + 1;
                            TypeTextWithEffect(textLeft, textTop + 1, "-root@Mr.Robot:I'm impressed with the level you've reached.", ConsoleColor.DarkGreen, ConsoleColor.Black);
                            TypeTextWithEffect(textLeft, textTop + 2, "-root@Mr.Robot:(H) for help Or you can Start your attack. ", ConsoleColor.DarkGreen, ConsoleColor.Black);

                            do
                            {
                                string help;
                                // Replace Console.ReadLine() with the following code
                                inputLeft = 18; // Adjust the left position within the bbbBox
                                inputTop = 5; // Adjust the top position within the bbbBox
                                Console.SetCursorPosition(inputLeft, inputTop);
                                help = Console.ReadLine();
                                if (help == "H")
                                {
                                    zzzBox.Clear();
                                    UpdateMsgBox(zzzBox,"We will install Metasploit Then we start");
                                    Thread.Sleep(2000);
                                    operationsObject.InstallMetasploit();
                                }
                                else if (help == "msfconsole")
                                {
                                    Console.Clear();
                                    metasploitGame = new MetasploitGame();
                                    metasploitGame.Metasploit();
                                }
                                else
                                {
                                    UpdateMsgBox(zzzBox, "What are you trying to do?");

                                }
                            } while (passwordInput == "root"); break;

                        }
                        //break;

                        //root
                        else
                        {
                            zzzBox.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            UpdateMsgBox(eeeBox, "Authentication failed.");
                            Console.ResetColor();
                            Thread.Sleep(2000);

                            UpdateMsgBox(eeeBox, "Invalid command.");
                            Thread.Sleep(2000);
                            zzzBox.Clear();
                            goto Label;
                        }//root

                    }
                    else
                    {
                        zzzBox.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        UpdateMsgBox(eeeBox, "Authentication failed.");
                        Console.ResetColor();
                        Thread.Sleep(2000);

                        UpdateMsgBox(eeeBox, "Invalid command.");
                        Thread.Sleep(2000);
                        zzzBox.Clear();
                        goto Label;

                    }
                    break;   

            ;

                case 1:
                    goto Label;

                    break;
                case 2:
                    goto Label;

                    break;
            }
        }


        public void Chatting(Box msgBox )
        {
            string username = LoginManager.userName;
            Console.OutputEncoding = Encoding.Unicode;
            var operationsObject = new Operations();

            Console.OutputEncoding = Encoding.Unicode;
            var continueLoop1 = true;
            Console.CursorTop = msgBox.Top + 2;
            Console.CursorLeft = msgBox.Left + 2;
            while (continueLoop1)
            {
                Console.WriteLine("Official Kali Support Channel | IRC Guidlines : http//goTohell/WTF");
                Console.CursorLeft = msgBox.Left + 2;
                Console.WriteLine("13:20 #KingOfNothing: <K0N> | ");
                Console.CursorLeft = msgBox.Left + 2;
                Console.WriteLine("------------------------------------------------------------------------");

                Console.CursorTop = msgBox.Top + 5;
                Console.CursorLeft = msgBox.Left + 2;
                Thread.Sleep(2500);
                Console.OutputEncoding = Encoding.UTF8;

                DisplayMessage("Darlene", "I see he has opened the message.");
                Thread.Sleep(3000);
                Console.CursorLeft = msgBox.Left + 2;

                DisplayMessage("Mr.Robot", "This means he has accepted the first mission.");
                Thread.Sleep(2876);
                Console.CursorLeft = msgBox.Left + 2;

                DisplayMessage("Darlene", "Is he with us now?");
                Thread.Sleep(3001);
                Console.CursorLeft = msgBox.Left + 2;

                DisplayMessage("Mr.Robot", "Not yet or yes, I don't know. We will see later.");
                Thread.Sleep(3000);
                Console.CursorLeft = msgBox.Left + 2;

                DisplayMessage("Darlene", "Should we ask him?");
                Thread.Sleep(2550);
                Console.CursorLeft = msgBox.Left + 2;

                DisplayMessage("Mr.Robot", "You ask him.");
                Thread.Sleep(2000);
                Console.CursorLeft = msgBox.Left + 2;

                DisplayMessage("Darlene", "Why me? You're the one who invited him!");
                Thread.Sleep(2950);
                Console.CursorLeft = msgBox.Left + 2;

                DisplayMessage("Mr.Robot", "What does he do, see all this and still no shit.");
                Thread.Sleep(2750);
                Console.CursorLeft = msgBox.Left + 2;

                DisplayMessage("Mr.Robot", "What are you doing? Say something.");
                // Replace Console.ReadLine() with the following code
                var inputLeft = bbbBox.Left + 1; // Adjust the left position within the bbbBox
                var inputTop = bbbBox.Top + 1; // Adjust the top position within the bbbBox
                Console.SetCursorPosition(inputLeft, inputTop);
                string whatAreYouDoing = Console.ReadLine();
                bbbBox.Clear();

                Console.CursorLeft = msgBox.Left + 2;
                Console.CursorTop = 16;
                Console.Write($"[{username}] {whatAreYouDoing}");



                Thread.Sleep(3050);
                Console.CursorLeft = msgBox.Left + 2;
                Console.CursorTop = 17;
                DisplayMessage("Mr.Robot", "Finally, you said something.");

                Thread.Sleep(2000);
                Console.CursorLeft = msgBox.Left + 2;
                Console.CursorTop = 18;
                DisplayMessage("Darlene", "Do you know what's happening?");

                // Replace Console.ReadLine() with the following code
                Console.Write(ANSIColors.ANSI_DarkGray);
                inputLeft = bbbBox.Left + 1; // Adjust the left position within the bbbBox
                inputTop = bbbBox.Top + 1; // Adjust the top position within the bbbBox
                Console.SetCursorPosition(inputLeft, inputTop);
                var urAns = Console.ReadLine();
                bbbBox.Clear();

                Console.CursorLeft = msgBox.Left + 2;
                Console.CursorTop = 19;
                Console.Write($"[{username}] {urAns}");


                string[] words = urAns.Split(' ');
                bool containsYes = words.Any(word => word.Equals("yes", StringComparison.OrdinalIgnoreCase));

                if (words.Length < 5 || (containsYes && words.Length >= 5) || urAns.Contains("yes", StringComparison.OrdinalIgnoreCase))
                {

                    Thread.Sleep(2550);
                    Console.CursorLeft = msgBox.Left + 2;
                    Console.CursorTop = 20;
                    DisplayMessage("Darlene", "Are you sure that you can??");

                    Console.Write(ANSIColors.ANSI_DarkGray);
                    bbbBox.Clear();
                    // Replace Console.ReadLine() with the following code
                    inputLeft = bbbBox.Left + 1; // Adjust the left position within the bbbBox
                    inputTop = bbbBox.Top + 1; // Adjust the top position within the bbbBox
                    Console.SetCursorPosition(inputLeft, inputTop);
                    var urAns1 = Console.ReadLine();
                    bbbBox.Clear();

                    Console.CursorLeft = msgBox.Left + 2;
                    Console.CursorTop = 21;
                    Console.Write($"[{username}] {urAns1}");

                    if (urAns1.Equals("yes", StringComparison.OrdinalIgnoreCase) || urAns1.Equals("Yes", StringComparison.OrdinalIgnoreCase))
                    {
                        Thread.Sleep(3050);
                        Console.CursorLeft = msgBox.Left + 2;
                        Console.CursorTop = 22;
                        DisplayMessage("Mr.Robot", "So I will send an information. Read it carefully.");

                        Thread.Sleep(200);
                        Console.CursorLeft = msgBox.Left + 2;
                        Console.CursorTop = 23;

                        ProgressBar(50, ' ');
                        Thread.Sleep(2000);
                        Console.Write(ANSIColors.ANSI_DarkGray);
                        Console.CursorLeft = msgBox.Left + 2;
                        Console.CursorTop = 24;

                        Console.WriteLine("File has been sent.");
                        Console.CursorLeft = msgBox.Left + 2;
                        Console.CursorTop = 24;

                        Console.Write("Press Enter to open it.");
                        msgBox.Clear();
                        break;
                    }
                    else
                    {
                        Thread.Sleep(4050);
                        Console.CursorLeft = msgBox.Left + 2;
                        Console.CursorTop = 22;

                        DisplayMessage("Mr.Robot", "Goodbye!!");
                        Thread.Sleep(2500);

                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();
                        Console.CursorLeft = 25;
                        var errorMessage = "     Your PC ran into a problem and needs to restart.";
                        Console.SetCursorPosition((Console.WindowWidth - errorMessage.Length) / 2, Console.WindowHeight / 2);
                        Console.WriteLine(errorMessage);

                        Thread.Sleep(3000);
                        Environment.Exit(0);
                    }
                }
                else
                {
                    Thread.Sleep(4050);
                    Console.CursorLeft = msgBox.Left + 2;

                    DisplayMessage("Mr.Robot", "I told you he would let us down!");
                    Thread.Sleep(5000);
                    Console.CursorLeft = msgBox.Left + 2;

                    DisplayMessage("Darlene", "I do not know what to say.");
                    Thread.Sleep(3000);
                    Console.CursorLeft = msgBox.Left + 2;

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
        static void DisplayMessage(string sender, string message)
        {
            string username = LoginManager.userName;
            string time = DateTime.Now.ToString("HH:mm:ss zz"); // تنسيق الوقت
            string timeColor = "\u001B[32m"; // لون الوقت (أخضر)
            string resetColor = "\u001B[0m"; // إعادة الألوان إلى الوضع الافتراضي

            string senderColor = sender == "Darlene" ? "\u001B[35m" : (sender == "Mr.Robot" ? "\u001B[34m" : "\u001B[1;30m"); // لون المرسل

            Console.Write(timeColor);
            Console.Write($"{time}");
            Console.Write(senderColor);
            Console.Write($" {sender}");
            Console.Write(resetColor);
            Console.WriteLine($" | {message}");
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
        private static void UpdateMsgBox(Box msgBox, string newMsgOneContent)
        {
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
        public static void DisplayContentAt(int left, int top, string content, ConsoleColor foregroundColor,
            ConsoleColor backgroundColor)
        {
            Console.SetCursorPosition(left, top);
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.WriteLine(content);
            Console.ResetColor();
        }
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


    }
}