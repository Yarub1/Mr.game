using System.Text;
namespace MrRoboT;

internal class Missions
{

    class WiFiNetwork
    {
        public string SSID { get; set; }
        public string BSSID { get; set; }
        public int SignalStrength { get; set; }
    }
    public static void MissionOne()
    {
        MetasploitGame game1 = new MetasploitGame();      //
        Console.OutputEncoding = Encoding.Unicode;
        var operationsObject = new Operations();
        //Console.Clear();
        ////
        //Thread.Sleep(10000);
        //Console.WriteLine("\n\n\n\n\n\n\n");
        //string[] notificationMessage =
        //{
        //    @"                                      ╭────────────────────────────────────────╮",
        //    @"                                      │   New Message Received                 │",
        //    @"                                      │   Hello,                               │",
        //    @"                                      │   You have a new message from Mr.Robt. │",
        //    @"                                      ╰────────────────────────────────────────╯"
        //};
        //operationsObject.FlashAndContinue(notificationMessage, 500);
        //Console.Clear();
        //Thread.Sleep(2500);
        //operationsObject.Chatting();
        //Thread.Sleep(2500);
        //Console.WriteLine();
        //Console.ForegroundColor = ConsoleColor.Green;
        ////
        //operationsObject.PrintChatStyle("We have found a suitable place to be the headquarters of our operations");
        //operationsObject.PrintChatStyle("which is an abandoned warehouse, but there is a problem that it is protected");
        //operationsObject.PrintChatStyle("by an electric gate. Your mission is to HACK this gate so that we can cross without problems.");
        //Console.Clear();

        //operationsObject.PrintChatStyle("Now You have to choose which tools you will help the scenario");
        //Thread.Sleep(1500);
        //operationsObject.PrintChatStyle(
        //    "Here are some tools that I was able to get them from a Dark Web. Try to find what suits you");
        //string[] menuOptions =
        //    { "Scan for Vulnerabilities ", "Social Engineering", "Brute Force Attack", "Sneak Inside" };
        //var selectedIndex = operationsObject.ShowHorizontalMenu(menuOptions, 2);
        //Console.WriteLine();
        //switch (selectedIndex)
        //{
        //    case 0:
        //    Label:
        //        //Console.Clear();
        //        operationsObject.PrintChatStyle("Ok, I'm interested");
        //        Console.ForegroundColor = ConsoleColor.Green;
        //        operationsObject.PrintChatStyle("Select your level");
        //        string[] menuOptionsOneStrings =
        //            { "No experience", "Beginner", "Skilled" };
        //        var selectedIndexOneMenu = operationsObject.ShowVMenu(menuOptionsOneStrings, 3);
        //        switch (selectedIndexOneMenu)
        //        {
        //            case 0:
        //                Console.ForegroundColor = ConsoleColor.DarkGreen;
        //                operationsObject.PrintCenteredText("OMG, I recommend that you search a little, use Google, and you will find something amazing");
        //                operationsObject.PrintCenteredText("But you can ask me and I will guide you!");
        //                while (true)
        //                {
        //                    Console.Write("what's your question: ");
        //                    string question = Console.ReadLine();
        //                    string answer;
        //                    if (question.Contains("hack") || question.Contains("hacker"))
        //                    {
        //                        answer = "Are you serious?.";
        //                    }
        //                    else
        //                    {
        //                        answer = "Sorry, I can't understand the question. Please ask another question.";
        //                    }
        //                    Console.WriteLine(answer);
        //                    continue;
        //                }
        //                break;

        //            case 1:

        //                Console.ForegroundColor = ConsoleColor.DarkGreen;
        //                operationsObject.PrintCenteredText("This means you know some of these things");
        //                //goto Label;
        //                operationsObject.PrintCenteredText("Log in to admin permissions");
        //                string sudo = Console.ReadLine();
        //                //operationsObject.PrintCenteredText("Log in to root p@ssword");
        //                if (sudo == "sudo")
        //                {
        //                    Console.Clear();
        //                    Console.ForegroundColor = ConsoleColor.Green;
        //                    Console.WriteLine("You are now in root mode.");
        //                    Console.ResetColor();
        //                    Thread.Sleep(1000);

        //                    //root pass
        //                    Console.WriteLine("password for kali:");
        //                    string passwordInput = Console.ReadLine();
        //                    if (passwordInput == "root")
        //                    {
        //                        Console.Clear();
        //                        Console.ForegroundColor = ConsoleColor.Green;
        //                        Console.WriteLine("Authentication successful.");
        //                        Console.ResetColor();
        //                        Thread.Sleep(1000);
        //                        Console.WriteLine("Root access granted.");
        //                        Thread.Sleep(1000);
        //                        Console.WriteLine("root@Mr.Robot:");
        //                        operationsObject.PrintChatStyle("root@Mr.Robot:I'm impressed with the level you've reached so I'll help you.");
        //                        operationsObject.PrintChatStyle("root@Mr.Robot:We will use Metasploit Vulnerability Scan");
        //                        operationsObject.PrintChatStyle("root@Mr.Robot:(H) for help Or you can start your attack ");
        //                        do
        //                        {
        //                            string help;
        //                            help = Console.ReadLine();
        //                            if (help == "H")
        //                            {
        //                                operationsObject.PrintChatStyle("We will install Metasploit Then we start");
        //                                Thread.Sleep(2000);
        //                                operationsObject.InstallMetasploit();
        //                            }
        //                            else if (help == "msfconsole")
        //                            {
        //                                Console.Clear();
        //                                game1.Metasploit();
        //                            }
        //                            else
        //                            {
        //                                operationsObject.PrintChatStyle("What are you trying to do?");

        //                            }
        //                        } while (passwordInput == "root"); break;

        //                    }
        //                    //break;

        //                    //root
        //                    else
        //                    {
        //                        Console.Clear();
        //                        Console.ForegroundColor = ConsoleColor.Red;
        //                        Console.WriteLine("Authentication failed. Access denied.");
        //                        Console.ResetColor();
        //                        Thread.Sleep(2000);
        //                        Console.WriteLine("Invalid command. Exiting terminal...");
        //                        Thread.Sleep(2000);
        //                        Console.Clear();
        //                        goto Label;
        //                    }//root

        //                }
        //                //sudo
        //                else
        //                {
        //                    Console.Clear();
        //                    Console.ForegroundColor = ConsoleColor.Red;
        //                    Console.WriteLine("Authentication failed. Access denied.");
        //                    Console.ResetColor();
        //                    Thread.Sleep(2000);
        //                    Console.WriteLine("Invalid command. Exiting terminal...");
        //                    Thread.Sleep(2000);
        //                    Console.Clear();
        //                    goto Label;

        //                }
        //                break;//sudo

        //            case 2:
        //                Console.ForegroundColor = ConsoleColor.DarkGreen;
        //                operationsObject.PrintCenteredText("Without any introduction, please get the job done");

        //                operationsObject.VASConsoleExpert();

        //                break;
        //        }

        //        break;

        //    case 1:

        //        Console.Clear();
        //    Label1:
        //        Console.ForegroundColor = ConsoleColor.Green;
        //        operationsObject.PrintCenteredText("Do you know what this choice means? Y/N");
        //        var playerSelection1 = "";
        //        var leftPadding6 = (Console.WindowWidth - playerSelection1.Length - 2) / 2;
        //        Console.SetCursorPosition(leftPadding6, Console.CursorTop);
        //        Console.ForegroundColor = ConsoleColor.DarkGray;
        //        playerSelection1 = Console.ReadLine();

        //        if (playerSelection1.Equals("Y", StringComparison.OrdinalIgnoreCase))
        //        {
        //            Console.ForegroundColor = ConsoleColor.DarkGreen;
        //            operationsObject.PrintCenteredText("So how did you choose this answer for whom will you hack through the wall?");
        //            operationsObject.PrintCenteredText("We will cancel the mission");
        //            Thread.Sleep(2000);
        //            Console.WriteLine("Booting up...");
        //            Thread.Sleep(1000); // 
        //            Console.Clear();
        //            Console.WriteLine("Initializing system...");
        //            Thread.Sleep(1000);
        //            Console.Clear();
        //            Console.WriteLine("Checking for errors...");
        //            Thread.Sleep(1000);
        //            Console.Clear();
        //            Console.WriteLine("Error: Unable to start Linux kernel.");
        //            Thread.Sleep(2000);
        //            // 
        //            Console.Clear();
        //            Console.Write("Loading ");
        //            Console.ForegroundColor = ConsoleColor.Green;
        //            Console.Write("▐▐");
        //            Console.ResetColor();
        //            Console.Write("                ");

        //            for (int i = 0; i < 20; i++)
        //            {
        //                Thread.Sleep(500);
        //                Console.SetCursorPosition(10 + i, Console.CursorTop);
        //                Console.Write("▐▐");
        //            }

        //            Console.Clear();
        //            Console.WriteLine("Error: Kernel panic - not syncing.");
        //            Thread.Sleep(2000);
        //            Console.Clear();
        //            Console.WriteLine("Rebooting in 3 seconds...");
        //            Thread.Sleep(3000);

        //            // 
        //            Console.BackgroundColor = ConsoleColor.Black;
        //            Console.ForegroundColor = ConsoleColor.White;

        //            // 
        //            // ...

        //            Console.ReadLine();
        //            //Environment.Exit(0);
        //            goto Label1;

        //        }

        //        else if ((playerSelection1.Equals("N", StringComparison.OrdinalIgnoreCase)))
        //        {
        //            Console.ForegroundColor = ConsoleColor.DarkGreen;
        //            operationsObject.PrintCenteredText("It may be a correct answer, but with conditions");
        //            operationsObject.PrintCenteredText("And I don't have time to teach you. Use Google and activate your curiosity, please");
        //            operationsObject.PrintCenteredText("We have to stop here, see you in hell");
        //            goto Label1;
        //        }
        //        break;

        //    case 2:
        //        Console.Clear();
        //        Console.ForegroundColor = ConsoleColor.DarkGreen;
        //        operationsObject.PrintCenteredText("I am very impressed with your level of security.");
        //        operationsObject.PrintCenteredText("I think your password is something from date of birth");
        //        operationsObject.PrintCenteredText("and an important name in your life with commas if not some duplicate numbers.");
        //        operationsObject.PrintCenteredText("I hope you can guess why I'm going to end the conversation with you.");
        //        goto Label;
        //        break;

        //    case 3:
        //        Console.Clear();
        //        Console.ForegroundColor = ConsoleColor.DarkGreen;
        //        operationsObject.PrintCenteredText("If it were that easy, life wouldn't be so harsh. Do you think that prisons are guarded by God's power?");
        //        operationsObject.AnimateText("                                           \\ / _\r\n                                      ___,,,\r\n                                      \\_[o o]\r\n                       !              C\\  _\\/\r\n             /                     _____),_/__\r\n        ________                  /     \\/   /\r\n      _|       .|                /      o   /\r\n     | |       .|               /          /\r\n      \\|       .|              /          /\r\n       |________|             /_        \\/\r\n       __|___|__             _//\\        \\\r\n _____|_________|____       \\  \\ \\        \\\r\n                    _|       ///  \\        \\\r\n                   |               \\       /\r\n                   |               /      /\r\n                   |              /      /\r\n ________________  |             /__    /_\r\n b'ger        ...|_|.............. /______\\.......\r\n");
        //        Environment.Exit(0);
        //        break;

        //    default:
        //        Console.ForegroundColor = ConsoleColor.Gray;
        //        operationsObject.PrintCenteredText("You did not select a valid option");
        //        Console.ForegroundColor = ConsoleColor.DarkGreen;
        //        break;
        //}
    }
}


