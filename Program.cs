/*******************
 * The original file was created on YouTube under the url: https://www.youtube.com/watch?v=egA_onU3eiA
 * YouTube channel name: "Packt Video"
 * IronPython code (lines 19 - 25) from: https://www.dotnetlovers.com/article/216/executing-python-script-from-c-sharp
 *******************/

using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using Renci.SshNet;
using IronPython.Hosting;

namespace SshConsoleApp
{
    class Program
    {

        #region Client Functions
        /// <summary>
        /// This function will take the SSH client and 
        /// attempt to connect to it. 
        /// </summary>
        /// <param name="client"></param>
        private static void ConnectToSSH(SshClient client)
        {
            // Check if client is not connected to anything
            if (!client.IsConnected)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Connecting via SSH... \n");

                try  // perform try-catch so that the application doesn't crash
                {
                    // Attempt to connect to device through SSH
                    client.Connect();
                }
                catch (Exception ex)  // Show any errors
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("SSH ERROR: ");

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(ex.Message + "\n");
                }

                if (client.IsConnected)  // Show user connection results
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Successfully connected via SSH!\n");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Did not connect successfully via SSH..." + "\n");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Already connected to a device via SSH.");
            }
        }

        /// <summary>
        /// This function will take the SFTP client and
        /// attempt to connect to it. 
        /// </summary>
        /// <param name="sftp"></param>
        private static void ConnectToSFTP(SftpClient sftp)
        {
            if (!sftp.IsConnected)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Connecting via SFTP... \n");

                try  // perform try-catch so that the application doesn't crash
                {
                    // Attempt to connect to device through SFTP
                    sftp.Connect();
                }
                catch (Exception ex)  // Show any errors
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("SFTP ERROR: ");

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(ex.Message + "\n");
                }

                if (sftp.IsConnected)  // Show user connection results
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Successfully connected via SFTP!\n");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Did not connect successfully via SFTP..." + "\n");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Already connected to a device via SSH.");
            }
        }

        /// <summary>
        /// Takes the SSH client and checks if it is connected to a server.
        /// Otherwise, it won't do anything to the client. 
        /// </summary>
        /// <param name="client"></param>
        private static void DisconnectFromSSH(SshClient client)
        {
            // Check if client is connected to anything
            if (client.IsConnected)
            {
                // Disconnect from server
                client.Disconnect();
            }
            else
            {
                // Prompt to user
                Console.WriteLine("\nNot connected to anything...");
            }
        }

        /// <summary>
        /// Takes SFTP client and checks if it is connected to a server.
        /// Otherwise, it won't do anything.
        /// </summary>
        /// <param name="sftp"></param>
        private static void DisconnectFromSFTP(SftpClient sftp)
        {
            // Check if client is connected to anything
            if (sftp.IsConnected)
            {
                // Disconnect from server
                sftp.Disconnect();
            }
            else
            {
                // Prompt to user
                Console.WriteLine("\nNot connected to anything...");
            }
        }
        #endregion

        #region I/O Functions
        /// <summary>
        /// Print available commands that can be entered.
        /// The commands will perform unique tasks for the rover. 
        /// </summary>
        private static void PrintCommands()
        {
            // ***More commands to come later
            Console.WriteLine("**Available Commands**");
            Console.WriteLine("\"accel\" - runs accelerometer.py  \n\"e\" - ends program " +
                "\n\"check\" - checks RasPi output" +
                "\n\"dt\" - downloads test file \n\"dm\" - downloads map data file \n\"u\" - uploads test file" +
                "\n\"map\" - generates map \n\"roam\" - rover roams around room");
            Console.WriteLine("**********************");
        }

        /// <summary>
        /// Checks which command was inputted by user.
        /// </summary>
        /// <param name="userInput"></param>
        /// <param name="sftp"></param>
        private static string CheckUserInput(string userInput, SftpClient sftp)
        {
            // return this so that each case has it's own linux command to send
            // if applicable
            // Server file is file to be downloaded
            // Local file is location of file on user's computer
            string linuxCommand, serverFile, localFile; ;
            linuxCommand = "No linux command was used.";

            switch (userInput.ToLower())
            {
                case "accel": // run accelerometer.py
                    Console.WriteLine("Executing \"accelerometer.py\"");
                    linuxCommand = "python3 accelerometer.py";
                    break;

                case "check": // displays output to terminal
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Displaying Raspberry Pi output: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

                case "e":  // Do nothing. Let while loop end, and program will finish. 
                    Console.WriteLine("Ending Program.");
                    break;

                case "dt":  // make specific download cases for specific files
                    Console.WriteLine("Downloading test file...");

                    serverFile = @"Test.txt";
                    // consider changing to Public instead of Oscar Rodriguez since every
                    // device should have C:\Users\Public
                    localFile = @"C:\Users\Oscar Rodriguez\testUIdownload.txt";

                    DownloadFile(sftp, serverFile, localFile);

                    // Assuming a windows device
                    Console.WriteLine("Downloaded Test.txt to location: " + "C:\\Users\\Oscar Rodriguez");
                    break;

                case "dm": // download the map image/data to display/plot
                    // Assuming data will be stored in a txt file, plot it here?
                    serverFile = @"map.txt"; // NOT actual file name
                    localFile = @"C:\Users\Oscar Rodriguez\map_data.txt";

                    DownloadFile(sftp, serverFile, localFile);

                    // Assuming a windows device
                    Console.WriteLine("Downloading map data to location: " + "C:\\Users\\Oscar Rodriguez");
                    break;


                case "u":  // make specific upload cases for specific files?
                    Console.WriteLine("Uploading test file... ");
                    string sourceFile; // file to be uploaded
                    sourceFile = @"C:\Users\Oscar Rodriguez\UIuploadTest.txt";

                    UploadFile(sftp, sourceFile);
                    break;

                case "map": // Command to start mapping
                    Console.WriteLine("Generating map...");
                    // CHANGE: example linux command
                    linuxCommand = "python3 ROS.py";
                    break;

                case "roam": // Command to make rover roam autonomously
                    Console.WriteLine("Rover is now autonomously roaming.");
                    // CHANGE: example linux command
                    linuxCommand = "python3 rover.py";
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Not a valid command. Please try again.");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }

            return linuxCommand;
        }
        #endregion

        #region Stream Functions
        /// <summary>
        /// This function writes the command to the ShellStream.
        /// Source of code: https://newbedev.com/how-to-run-commands-on-ssh-server-in-c
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="writer"></param>
        /// <param name="stream"></param>
        private static void WriteStream(string cmd, StreamWriter writer, ShellStream stream)
        {
            writer.WriteLine(cmd);
            while (stream.Length == 0)
            {
                Thread.Sleep(500);
            }
        }

        /// <summary>
        /// This function reads the ShellStream and stores it in a StringBuilder object.
        /// Source of code: https://newbedev.com/how-to-run-commands-on-ssh-server-in-c
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static StringBuilder ReadStream(StreamReader reader)
        {
            StringBuilder result = new StringBuilder();

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                result.AppendLine(line);
            }
            return result;
        }

        /// <summary>
        /// This function sends the command that needs to be executed
        /// to a shell stream. Create ShellStream beforehand.
        /// Source of code: https://newbedev.com/how-to-run-commands-on-ssh-server-in-c
        /// </summary>
        /// <param name="customCMD"></param>
        /// <returns></returns>
        public static StringBuilder SendCommand(string customCMD, ShellStream stream)
        {
            StringBuilder answer;

            var reader = new StreamReader(stream);
            var writer = new StreamWriter(stream);

            writer.AutoFlush = true;
            WriteStream(customCMD, writer, stream);
            answer = ReadStream(reader);

            return answer;
        }

        /// <summary>
        /// Uploads file to the SFTP server. 
        /// Defaulted to store file in server's home directory. 
        /// </summary>
        /// <param name="sftpClient"></param>
        /// <param name="fileName"></param>
        private static void UploadFile(SftpClient sftpClient, string fileName)
        {
            using (Stream stream = File.OpenRead(fileName))
            {
                sftpClient.UploadFile(stream, @"" + Path.GetFileName(fileName),
                    x => { Console.WriteLine("\nSuccessfully Uploaded!"); }); // x seems to be the address of file
            }
        }

        /// <summary>
        /// Downloads file from the SFTP server.
        /// Defaulted to downloads on user's computer. 
        /// </summary>
        /// <param name="sftpClient"></param>
        /// <param name="fileName"></param>
        private static void DownloadFile(SftpClient sftpClient, string serverFile, string fileToDownload)
        {
            using (Stream stream = File.OpenWrite(fileToDownload))
            {
                sftpClient.DownloadFile(serverFile, stream, x => { Console.WriteLine("\nSuccessfully Downloaded!"); });
            }
        }
        #endregion

        public static void Main(string[] args)
        {
            // FIX: make windows forms run so that it shows map images
            // CONSIDER: https://social.msdn.microsoft.com/Forums/en-US/126aab0c-9823-4b47-aa07-15594384855c/how-to-open-a-form-with-console-application?forum=winforms
            // using the above link
            // Application.Run(FormOutput());

            // Gather info from user
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter Hostname or IP address to connect to: ");
            string hostIP = Console.ReadLine();

            Console.Write("login as: ");
            string username = Console.ReadLine();

            Console.Write("password: ");
            string password = Console.ReadLine();

            Console.WriteLine();

            // Establish client information and define varibles needed
            // PasswordAuthenticationMethod(string username, string password)
            AuthenticationMethod method = new PasswordAuthenticationMethod(username, password);

            // ConnectionInfo(string host, string username, params AuthenticationMethod[] authenticationMethod)
            ConnectionInfo connection = new ConnectionInfo(hostIP, username, method);
            SshClient sshClient = new SshClient(connection);

            // Create SFTP client to use with RasPi
            // SFTP allows upload and download files
            SftpClient sftpClient = new SftpClient(connection);

            // Connect to SSH and SFTP server
            ConnectToSSH(sshClient);
            ConnectToSFTP(sftpClient);

            Console.ForegroundColor = ConsoleColor.White; // make text white again

            // Define shell stream variable. Define parameters
            ShellStream shellStream = sshClient.CreateShellStream("Custom Commands", 80, 24, 800, 600, 1024);

            // Prints the ssh stream output. Basically the text we see on MobaXterm
            // Store StringBuilder variable to convert into a string
            StringBuilder commandSB = SendCommand(" ", shellStream);
            string commandOutput = commandSB.ToString();

            PrintCommands();  // print available commands
            Console.Write("\nEnter a command from the list of available commands to " +
                "send to the Rover. Type \'e\' to end the application... ");

            string userInput, commandToSend;
            userInput = Console.ReadLine();

            // Run function to check user input
            commandToSend = CheckUserInput(userInput, sftpClient);

            // Take user input again until 'e' is pressed to end application
            while (userInput.ToLower() != "e")
            {
                // send command to stream and store result
                commandSB = SendCommand(commandToSend, shellStream);
                commandOutput = commandSB.ToString();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n" + commandOutput);
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("Enter another from the list of commands available: ");
                userInput = Console.ReadLine();

                // Checks input again; modify function to return a string that 
                // is in linux so that the user doesn't need to know linux
                commandToSend = CheckUserInput(userInput, sftpClient);
            }

            // CONSIDER: transfer image through SFTP to local
            // ALSO: make sure RasPi doesn't show map or other things that require a display

            // Disconnect from SSH after pressing the end command
            DisconnectFromSSH(sshClient);
            DisconnectFromSFTP(sftpClient);
        }
    }
}
