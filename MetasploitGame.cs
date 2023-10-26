using System.Text;

namespace MrRoboT
{
    public class Exploit
    {
        public string Name { get; }
        public string SuccessMessage { get; }
        public string ExploitationResult { get; }
        public string ExploitCommand { get; }
        public int Port { get; }
        public string Service { get; }
        public string Vulnerability { get; }
        public string SmbPipe { get; }
        public string PipeNames { get; }

        public Exploit(string name, string successMessage, string exploitationResult, string exploitCommand, int port, string service, string vulnerability, string targetIP)
        {
            Name = name;
            SuccessMessage = successMessage;
            ExploitationResult = exploitationResult;
            ExploitCommand = exploitCommand + targetIP;
            Port = port;
            Service = service;
            Vulnerability = vulnerability;
        }

    }
    class PortResult
    {
        public int Port { get; }
        public string State { get; }
        public string Service { get; }

        public PortResult(int port, string state, string service)
        {
            Port = port;
            State = state;
            Service = service;
        }
    }
    public class MetasploitGame
    {
        private const string ANSI_RESET = "\u001b[0m";
        private const string ANSI_RED = "\u001b[31m";
        private const string ANSI_GREEN = "\u001b[32m";
        private const string ANSI_YELLOW = "\u001b[33m";
        private const string ANSI_CYAN = "\u001b[36m";
        private const string CorrectIP = "192.168.1.1";
        private const string CorrectExploits = "BlueBorne Exploit";

        private List<string> commandHistory = new List<string>();
        private bool isExploited = false;
        private bool hasNetworkScan = false;
        private bool hasExploitSelected = false;
        private int attemptsRemaining = 2; // Number of attempts
        private int timeToWin = 2 * 60 * 1000; // 2 minutes in milliseconds
        private int timeElapsed = 0;
        private int exploitTimeElapsed = 0;
        private static string targetIP = ""; // To be set by the player
        private List<string> availableIPs = new List<string>
        {
            "192.168.1.1",
            "192.168.1.2",
            "192.168.1.3",
            "192.168.1.4",
            "192.168.1.5",
            // Add more IP addresses as needed
        };


        private List<Exploit> exploits = new List<Exploit>
{
    // Realistic exploits with information
    new Exploit("SSH Service Exploit", "SSH service exploited successfully.", "Now you can access the SSH service with admin privileges.", "msf exploit(ssh_service_exploit) > set RHOST ", 22, "SSH", "sshd", targetIP),
    new Exploit("HTTP Service Exploit", "HTTP service exploited successfully.", "Now you can access the HTTP service with admin privileges.", "msf exploit(http_service_exploit) > set RHOST ", 80, "HTTP", "httpd", targetIP),
    new Exploit("VNC Service Exploit", "VNC service exploited successfully.", "Now you can access the VNC service with admin privileges.", "msf exploit(vnc_service_exploit) > set RHOST ", 5900, "VNC", "vncd", targetIP),
    new Exploit("SQL Injection", "SQL Injection successful.", "Now you have access to the database.", "msf exploit(sql_injection_exploit) > set TARGET ", 1433, "MSSQL", "sqlsrv", targetIP),
    new Exploit("Cross-Site Scripting (XSS)", "XSS attack executed.", "You can now execute scripts in the user's browser.", "msf exploit(xss_exploit) > set TARGET ", 80, "HTTP", "httpd", targetIP),
    new Exploit("Cross-Site Request Forgery (CSRF)", "CSRF attack successful.", "You've tricked the user into making unintended requests.", "msf exploit(csrf_exploit) > set TARGET ", 8080, "Web", "app", targetIP),
    new Exploit("Remote Code Execution", "Remote code executed successfully.", "You now have control over the target system.", "msf exploit(rce_exploit) > set TARGET ", 22, "SSH", "sshd", targetIP),
    new Exploit("Server-Side Request Forgery (SSRF)", "SSRF attack successful.", "You can make the server send requests to internal resources.", "msf exploit(ssrf_exploit) > set TARGET ", 8081, "Web", "app", targetIP),
    new Exploit("Path Traversal", "Path traversal attack executed.", "You've accessed files on the server.", "msf exploit(path_traversal_exploit) > set TARGET ", 80, "HTTP", "httpd", targetIP),
    new Exploit("XML External Entity (XXE)", "XXE attack successful.", "You can manipulate XML processing on the server.", "msf exploit(xxe_exploit) > set TARGET ", 8080, "Web", "app", targetIP),
    new Exploit("Insecure Deserialization", "Insecure deserialization attack executed.", "You can manipulate deserialized objects.", "msf exploit(deserialization_exploit) > set TARGET ", 8081, "Web", "app", targetIP),
    new Exploit("Command Injection", "Command injection attack successful.", "You can execute system commands on the target.", "msf exploit(command_injection_exploit) > set TARGET ", 22, "SSH", "sshd", targetIP),
    new Exploit("Broken Authentication", "Authentication bypassed.", "You've accessed an account without proper authentication.", "msf exploit(auth_bypass_exploit) > set TARGET ", 80, "HTTP", "httpd", targetIP),
    new Exploit("Server-Side Template Injection", "Template injection attack executed.", "You can manipulate server-side templates.", "msf exploit(template_injection_exploit) > set TARGET ", 8080, "Web", "app", targetIP),
    new Exploit("Buffer Overflow", "Buffer overflow attack successful.", "You've executed malicious code by overloading the buffer.", "msf exploit(buffer_overflow_exploit) > set TARGET ", 80, "HTTP", "httpd", targetIP),
    new Exploit("BlueBorne Exploit", "BlueBorne attack successful.", "You've executed malicious code via the BlueBorne exploit.", "msf exploit(blueborne_exploit) > set TARGET ", 80, "Bluetooth", "blueborne", targetIP),
};

        private int currentExploitIndex = -1;
        private bool isSSHAccessed = false;
        private bool isFileDeleted = false;

        // Additional variables for SSH interaction
        private bool isSSHConnected = false;
        private List<string> sshOutput = new List<string>();
        private int score = 0; // Initialize the player's score
        private int totalScore = 0; // Initialize the total score

        public void Metasploit()
        {
            PrintBanner();
            SelectTargetIP();

            Console.WriteLine($"{ANSI_YELLOW}You have {attemptsRemaining} attempts remaining.{ANSI_RESET}");
            Console.WriteLine($"nmap -sV -O -T4 {targetIP}");
            NmapScanSimulator();
            string command;
            DateTime startTime = DateTime.Now;

            do
            {
                Console.Write("msf6 > ");
                command = Console.ReadLine();
                commandHistory.Add(command);

                if (!hasExploitSelected)
                {
                    ProcessExploitSelection(command);
                }
                else
                {
                    if (currentExploitIndex == GetBlueBorneExploitIndex())
                    {
                        if (IsBlueBorneExploited())
                        {
                            Console.WriteLine($"{ANSI_GREEN}[+] BlueBorne exploit successful! You've won the game.{ANSI_RESET}");
                            EndGame();
                            return;
                        }

                        if (ProcessBlueBorneCommands(command))
                        {
                            score += 10; // Award points for executing a BlueBorne command
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{ANSI_RED}[!] Invalid exploit selected. Choose the correct exploit (BlueBorne).{ANSI_RESET}");
                        hasExploitSelected = false;
                    }
                }

                CheckTimeElapsed(startTime);

            } while (!isExploited && timeElapsed < timeToWin);

            EndGame();
        }

        private void PrintBanner()
        {
            Console.WriteLine(" _                                                    _\r\n/     /         __                         _   __  /_/ __\r\n| |  / | _____               ___   _____ | | /   _\r\n| | /| | | ___ |- -|   /    / __ | -__/ | || | || | |- -|\r\n|_|   | | | _|__  | |_  / - __    | |    | | __/| |  | |_\r\n      |/  |____/  ___/ / \\___/   /     __|    |_  ___\r\n");
            Console.WriteLine($"Frustrated with proxy pivoting? Upgrade to layer-2 VPN pivoting with\r\nMetasploit Pro -- type 'go_pro' to launch it now.");
            Console.WriteLine($"{ANSI_CYAN}Metasploit Framework - Version 6.0.0{ANSI_RESET}");
            Console.WriteLine("====================================");
            Console.WriteLine();
            Console.WriteLine("       =[ metasploit v6.0.0-dev ]");
            Console.WriteLine("+ -- --=[ 2165 exploits - 1109 auxiliary - 371 post       ]");
            Console.WriteLine("+ -- --=[ 555 payloads - 45 encoders - 10 nops            ]");
            Console.WriteLine("+ -- --=[ 7 evasion                                       ]");
            Console.WriteLine();
        }

        private void SelectTargetIP()
        {
            Console.WriteLine($"{ANSI_YELLOW}[+] Choose a target IP from the list:");

            for (int i = 0; i < availableIPs.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {availableIPs[i]}");
            }

            int selectedIPIndex;
            do
            {
                Console.Write($"{ANSI_YELLOW}Enter the number of the target IP: {ANSI_RESET}");
                while (!int.TryParse(Console.ReadLine(), out selectedIPIndex) || selectedIPIndex < 1 || selectedIPIndex > availableIPs.Count)
                {
                    Console.WriteLine($"{ANSI_RED}[!] Invalid input. Please enter a valid number.{ANSI_RESET}");
                    Console.Write($"{ANSI_YELLOW}Enter the number of the target IP: {ANSI_RESET}");
                }

                targetIP = availableIPs[selectedIPIndex - 1];

                if (targetIP != CorrectIP)
                {
                    Console.WriteLine($"{ANSI_RED}[!] Incorrect target IP. You must choose the correct IP.{ANSI_RESET}");

                }
            } while (targetIP != CorrectIP);

            return;

        }

        private void ExploitInfoSimulator()
        {
            Console.WriteLine("Name     Current Setting  Required  Description");
            Console.WriteLine("----     ---------------  --------  -----------");
            Console.WriteLine("RHOST    172.16.194.134   yes       The target address");
            Console.WriteLine("RPORT    445              yes       Set the SMB service port");
            Console.WriteLine("SMBPIPE  BROWSER          yes       The pipe name to use (BROWSER, SRVSVC)\n");

            Console.WriteLine("Exploit target:\n");
            Console.WriteLine("Id  Name");
            Console.WriteLine("--  ----");
            Console.WriteLine("0   Automatic Targeting\n");

            Console.WriteLine("msf exploit(ms08_067_netapi) > check\n");
            Console.WriteLine("[*] Verifying vulnerable status... (path: 0x0000005a)");
            Console.WriteLine("[*] System is not vulnerable (status: 0x00000000)");
            Console.WriteLine("[*] The target is not exploitable.");
            Console.WriteLine("msf  exploit(ms08_067_netapi) >");
        }

        private void ProcessExploitSelection(string command)
        {
            if (command == "show exploits")
            {
                Console.WriteLine($"{ANSI_YELLOW}Available Exploits:{ANSI_RESET}");
                for (int i = 0; i < exploits.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {exploits[i].Name}");
                }
            }
            else if (command == "show options")
            {
                ExploitInfoSimulator();
            }

            else if (command.StartsWith("use exploit"))
            {
                string[] parts = command.Split(' ');
                if (parts.Length == 3)
                {
                    int exploitNumber;
                    if (int.TryParse(parts[2], out exploitNumber) && exploitNumber >= 1 && exploitNumber <= exploits.Count)
                    {
                        currentExploitIndex = exploitNumber - 1;
                        hasExploitSelected = true;
                        Console.WriteLine($"{ANSI_YELLOW}[-] Exploit selected: {exploits[currentExploitIndex].Name}{ANSI_RESET}");
                    }
                    else
                    {
                        Console.WriteLine($"{ANSI_RED}[!] Invalid exploit number.{ANSI_RESET}");
                    }
                }
                else
                {
                    Console.WriteLine($"{ANSI_RED}[!] Invalid command format.{ANSI_RESET}");
                }
            }
        }
        private void ProcessExploitationCommands(string command)
        {
            if (command == "exploit")
            {
                ExploitCurrent();
            }
            else if (command == "access ssh")
            {
                AccessSSH();
            }
            else if (isSSHConnected)
            {
                ExecuteSSHCommand(command);
            }
        }

        private void ShowExploitOptions()
        {
            if (hasExploitSelected)
            {
                Console.WriteLine($"Module options {ANSI_YELLOW}{exploits[currentExploitIndex].Name}{ANSI_RESET}:");
                Console.WriteLine("Name     Current Setting  Required  Description");
                Console.WriteLine("----     ---------------  --------  -----------");
                Console.WriteLine($"RHOST    {CorrectIP}   yes       The target address");
                Console.WriteLine("RPORT    445              yes       Set the SMB service port");
                Console.WriteLine("SMBPIPE  BROWSER          yes       The pipe name to use (BROWSER, SRVSVC)\n");

                Console.WriteLine("Exploit target:\n");
                Console.WriteLine("Id  Name");
                Console.WriteLine("--  ----");
                Console.WriteLine("0   Automatic Targeting\n");

                Console.WriteLine("msf exploit(ms08_067_netapi) > check\n");
                Console.WriteLine("[*] Verifying vulnerable status... (path: 0x0000005a)");
                Console.WriteLine("[*] System is not vulnerable (status: 0x00000000)");
                Console.WriteLine("[*] The target is not exploitable.");
                Console.WriteLine("msf  exploit(ms08_067_netapi) >");
            }
            else
            {
                Console.WriteLine($"{ANSI_RED}[!] No exploit selected. Use 'use exploit' to select an exploit.{ANSI_RESET}");
            }
        }

        private void ExploitCurrent()
        {
            if (currentExploitIndex >= 0 && currentExploitIndex < exploits.Count)
            {
                Exploit currentExploit = exploits[currentExploitIndex];
                Console.WriteLine($"{ANSI_YELLOW}Exploiting...{ANSI_RESET}");
                Thread.Sleep(2000);
                exploitTimeElapsed += 2000;

                if (exploitTimeElapsed > 10000)
                {
                    isExploited = true;
                    score += 50; // Award points for successful exploit
                    totalScore += score; // Add to total score
                    return;
                }

                DisplayExploitInfo(currentExploit);
                Console.WriteLine($"{ANSI_GREEN}[+] {currentExploit.SuccessMessage}{ANSI_RESET}");
                Console.WriteLine("Exploitation result:");
                Console.WriteLine(currentExploit.ExploitationResult);
                score += 20; // Award points for attempting an exploit
            }
        }

        private void AccessSSH()
        {
            if (isSSHAccessed)
            {
                Console.WriteLine($"{ANSI_RED}[!] SSH access already established.{ANSI_RESET}");
            }
            else
            {
                Console.WriteLine($"{ANSI_YELLOW}[+] SSH service exploited successfully.{ANSI_RESET}");
                Console.Write("user@192.168.43.120's password: ");
                string password = Console.ReadLine();
                Console.WriteLine($"Last login: {DateTime.Now} from 192.168.43.120");
                Console.WriteLine($"[user@remote_machine ~]$ ");
                isSSHAccessed = true;
            }

            if (isSSHConnected)
            {
                Console.WriteLine($"{ANSI_CYAN}Connected to SSH on {targetIP}.{ANSI_RESET}");
                Console.WriteLine($"{ANSI_CYAN}Type 'help' to see available SSH commands.{ANSI_RESET}");
                Console.WriteLine();

                while (isSSHConnected)
                {
                    Console.Write($"{targetIP}$ ");
                    string sshCommand = Console.ReadLine();

                    if (sshCommand == "rm open_time")
                    {
                        Console.Write($"Are you sure you want to delete 'open_time'? (yes/no): ");
                        string confirmation = Console.ReadLine();

                        if (confirmation == "yes")
                        {
                            Console.WriteLine($"rm: remove regular file 'open_time'");
                            Console.WriteLine("Congratulations! You have deleted 'open_time' and won the game.");
                            isSSHConnected = false;
                            isExploited = true;
                            score += 100; // Increase the score for completing an objective
                            Console.WriteLine($"[+] Score: {score}");
                        }
                        else
                        {
                            Console.WriteLine("File 'open_time' was not deleted.");
                        }
                    }
                    else
                    {
                        string sshOutputResult = ExecuteSSHCommand(sshCommand);
                        Console.WriteLine($"{ANSI_GREEN}{sshOutputResult}{ANSI_RESET}");

                        if (sshCommand == "ls")
                        {
                            Console.WriteLine("file1.txt");
                            Console.WriteLine("file2.txt");
                            Console.WriteLine("file3.txt");
                        }
                        else if (sshCommand == "cd www")
                        {
                            Console.WriteLine("index.html");
                            Console.WriteLine("images/");
                            Console.WriteLine("css/");
                        }
                        else if (sshCommand == "cd system")
                        {
                            Console.WriteLine("config.ini");
                            Console.WriteLine("logs/");
                        }
                        else if (sshCommand == "cd home")
                        {
                            Console.WriteLine("user1/");
                            Console.WriteLine("user2/");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine($"{ANSI_YELLOW}[+] SSH service exploited successfully.{ANSI_RESET}");
                Console.WriteLine($"{ANSI_YELLOW}You now have SSH access with admin privileges.{ANSI_RESET}");
                isSSHAccessed = true;
                isSSHConnected = true;
            }
        }

        private string ExecuteSSHCommand(string command)
        {
            // Implement actual SSH command execution here
            // Example (simulated output):
            if (command == "ls")
            {
                return isFileDeleted ? "open_time.txt (Deleted)" : "open_time.txt";
            }

            return "Command not recognized";
        }

        private void DisplayExploitInfo(Exploit exploit)
        {
            Console.WriteLine($"{ANSI_YELLOW}[+] Exploit Information:{ANSI_RESET}");
            Console.WriteLine($"Name: {exploit.Name}");
            Console.WriteLine($"Service: {exploit.Service}");
            Console.WriteLine($"Port: {exploit.Port}");
            Console.WriteLine($"Vulnerability: {exploit.Vulnerability}");

            Console.WriteLine($"msf exploit({exploit.Name.Replace(" ", "_").ToLower()}) > show options");
            Console.WriteLine("\nModule options (exploit/windows/smb/ms08_067_netapi):\n");
            Console.WriteLine("   Name     Current Setting  Required  Description");
            Console.WriteLine("   ----     ---------------  --------  -----------");

            // You can add more options as needed
            Console.WriteLine($"   RHOST    {targetIP}         yes       The target address");
            Console.WriteLine($"   RPORT    {exploit.Port}         yes       Set the {exploit.Service} service port");
            Console.WriteLine($"   SMBPIPE  {exploit.SmbPipe}          yes       The pipe name to use ({exploit.PipeNames})");

            Console.WriteLine("\nExploit target:\n");
            Console.WriteLine("   Id  Name");
            Console.WriteLine("   --  ----");
            Console.WriteLine("   0   Automatic Targeting\n");

            Console.WriteLine($"msf exploit({exploit.Name.Replace(" ", "_").ToLower()}) > check\n");
            Console.WriteLine("[*] Verifying vulnerable status... (path: 0x0000005a)");

            string isVulnerable = CorrectExploits; // Replace with your actual vulnerability check logic

            if (isVulnerable == CorrectExploits)
            {
                Console.WriteLine("[*] System is vulnerable (status: 0x00000001)");
            }
            else
            {
                Console.WriteLine("[*] System is not vulnerable (status: 0x00000000)");
                Console.WriteLine("[*] The target is not exploitable.");
            }

            Console.WriteLine($"msf exploit({exploit.Name.Replace(" ", "_").ToLower()}) >");
        }

        private void CheckTimeElapsed(DateTime startTime)
        {
            DateTime currentTime = DateTime.Now;
            TimeSpan elapsedTime = currentTime - startTime;
            if (elapsedTime.TotalMilliseconds >= 120000) // 2 minutes
            {
                Console.WriteLine($"{ANSI_RED}[!] Game over! Time limit exceeded.{ANSI_RESET}");
                Console.Beep(1000, 500); // Screen shake on failure
                for (int i = 0; i < 3; i++)
                {
                    Console.WindowLeft = 2;
                    Console.WindowTop = 2;
                    Console.WindowLeft = 4;
                    Console.WindowTop = 4;
                }
                Environment.Exit(0); // Exit the program on loss
            }
        }

        private void EndGame()
        {
            if (isExploited)
            {
                Console.WriteLine($"{ANSI_GREEN}[+] Congratulations! You have successfully exploited the target system!{ANSI_RESET}");
                Console.WriteLine($"{ANSI_GREEN}Gateway successfully exploited!{ANSI_RESET}");
                Console.WriteLine($"{ANSI_GREEN}Welcome to the Matrix.{ANSI_RESET}");
                Console.WriteLine("Mission Accomplished: You've infiltrated the gateway.");
                Console.WriteLine("██╗   ██╗ ██████╗ ██╗   ██╗███████╗███████╗");
                Console.WriteLine("██╗   ██║██╔═══██╗██║   ██║██╔════╝██╔════╝");
                Console.WriteLine("██╗   ██║██║   ██║██║   ██║███████╗█████╗");
                Console.WriteLine("██╗   ██║██║   ██║╚██╗ ██╔╝╚════██║██╔══╝");
                Console.WriteLine("╚██████╔╝╚██████╔╝ ╚████╔╝ ███████║███████╗");
                Console.WriteLine(" ╚═════╝  ╚═════╝   ╚═══╝  ╚══════╝╚══════╝");
                Console.WriteLine($"[+] Score for this round: {score}");
                Console.WriteLine($"[+] Total Score: {totalScore}");
            }
            else
            {
                Console.WriteLine($"{ANSI_RED}[!] Game over! Time limit exceeded or out of exploit attempts.{ANSI_RESET}");
                DateTime endTime = DateTime.Now;
                TimeSpan duration = endTime - DateTime.Now;
                if (duration.TotalMilliseconds >= timeToWin)
                {
                    Console.WriteLine($"{ANSI_RED}[!] Game over! Time limit exceeded.{ANSI_RESET}");
                    Console.Beep(1000, 500); // Screen shake on failure
                    for (int i = 0; i < 3; i++)
                    {
                        Console.WindowLeft = 2;
                        Console.WindowTop = 2;
                        Console.WindowLeft = 4;
                        Console.WindowTop = 4;
                    }
                }
                else
                {
                    Console.WriteLine($"{ANSI_RED}[!] Game over! Out of exploit attempts.{ANSI_RESET}");
                }
            }
        }

        private void NmapScanSimulator()
        {

            Thread.Sleep(1200);
            Console.WriteLine("Starting Nmap 7.80 ( https://nmap.org ) at 2023-01-20 15:30 UTC");
            Console.WriteLine("Nmap scan report for scanme.nmap.org (45.33.32.156)");
            Console.WriteLine("Host is up (0.080s latency).");
            Console.WriteLine("Other addresses for scanme.nmap.org (not scanned): 2600:3c01::f03c:91ff:fe18:bb2f");
            Console.WriteLine("Not shown: 996 filtered ports");

            var portResults = new List<PortResult>
            {
                new PortResult(22, "open", "ssh"),
                new PortResult(80, "open", "http"),
                new PortResult(9929, "closed", "nping-echo"),
                new PortResult(31337, "open", "Elite")
            };

            Console.WriteLine("PORT    STATE  SERVICE");

            foreach (var portResult in portResults)
            {
                Console.WriteLine($"{portResult.Port,-7}/{portResult.State,-6} {portResult.Service}");
            }

            //DateTime startTime = DateTime.Now;
            Console.WriteLine("Nmap done: 1 IP address (1 host up) scanned in " + DateTime.Now);
        }

        private int GetBlueBorneExploitIndex()
        {
            for (int i = 0; i < exploits.Count; i++)
            {
                if (exploits[i].Name == "BlueBorne Exploit")
                {
                    return i;
                }
            }
            return -1;
        }

        private bool IsBlueBorneExploited()
        {
            return isExploited;
        }

        private bool ProcessBlueBorneCommands(string command)
        {
            if (command == "hciconfig" || command == "hcitool scan" || command == "hcitool name mac name" || command == "sdptool" || command == "sdptool browse")
            {
                SimulateBlueBorneCommandOutput(command);
                return true;
            }
            else if (command == "exploit")
            {
                if (IsBlueBorneExploited())
                {
                    Console.WriteLine($"{ANSI_GREEN}[+] BlueBorne exploit already successful! You've gained full control over the target's Bluetooth connection and can execute commands.{ANSI_RESET}");
                    EndGame();
                    return true;
                }

                // Simulate the success of the BlueBorne exploit
                Console.WriteLine($"{ANSI_GREEN}[+] Exploiting...{ANSI_RESET}");
                Thread.Sleep(2000);
                exploitTimeElapsed += 2000;

                if (exploitTimeElapsed > 10000)
                {
                    isExploited = true;
                    score += 50; // Award points for successful exploit
                    totalScore += score; // Add to the total score
                    Console.WriteLine($"{ANSI_GREEN}[+] BlueBorne exploit successful! You've gained full control over the target's Bluetooth connection and can execute commands.{ANSI_RESET}");
                    EndGame();
                    return true;
                }

                DisplayExploitInfo(new Exploit("BlueBorne Exploit", "BlueBorne attack successful.", "You've executed malicious code via the BlueBorne exploit.", "msf exploit(blueborne_exploit) > set TARGET ", 80, "Bluetooth", "blueborne", targetIP)); // Replace with the actual class or logic
                Console.WriteLine($"{ANSI_GREEN}[+] Success: You've gained control over the Bluetooth connection.{ANSI_RESET}");
                Console.WriteLine("Exploitation result:");
                Console.WriteLine("Exploitation output goes here"); // Replace with actual output
                score += 20; // Award points for attempting an exploit
            }
            else
            {
                Console.WriteLine($"{ANSI_RED}[!] Command not recognized for BlueBorne exploit. Try again.{ANSI_RESET}");
                return false;
            }

            return false;
        }
        private void SimulateBlueBorneCommandOutput(string command)
        {
            // Simulate command output for the BlueBorne exploit
            switch (command)
            {
                case "hciconfig":
                    Console.WriteLine("hci0:   Type: Primary  Bus: USB");
                    Console.WriteLine("        BD Address: 00:11:22:33:44:55  ACL MTU: 1021:4  SCO MTU: 180.0");
                    break;

                case "hcitool scan":
                    Console.WriteLine("Scanning ...");
                    Console.WriteLine("        Device 1: DeviceName1");
                    Console.WriteLine("            Address: 00:11:22:33:44:55");
                    Console.WriteLine("        Device 2: DeviceName2");
                    Console.WriteLine("            Address: 00:AA:BB:CC:DD:EE");
                    break;

                case "hcitool name mac name":
                    Console.WriteLine("00:11:22:33:44:55   DeviceName1");
                    break;

                case "sdptool":
                    Console.WriteLine("Inquiring ...");
                    Console.WriteLine("Searching for Services on 00:11:22:33:44:55...");
                    Console.WriteLine("Service Name: Headset Gateway");
                    Console.WriteLine("Service RecHandle: 0x10001");
                    break;

                case "sdptool browse":
                    Console.WriteLine("Browsing 00:11:22:33:44:55 ...");
                    Console.WriteLine("Service Name: Headset Gateway");
                    Console.WriteLine("Service RecHandle: 0x10001");
                    break;

                default:
                    break;
            }
        }
    }


}
