/*******************
 * The original file was created on YouTube under the url: https://www.youtube.com/watch?v=egA_onU3eiA
 * YouTube channel name: "Packt Video"
 * IronPython code (lines 19 - 25) from: https://www.dotnetlovers.com/article/216/executing-python-script-from-c-sharp
 *******************/

using System;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using Renci.SshNet;
using IronPython.Hosting;

namespace SshConsoleApp
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            /*// Instance of python engine
            var engine = Python.CreateEngine();
            // Reading code from file
            var source = engine.CreateScriptSourceFromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PythonSampleIronPython.py"));
            var scope = engine.CreateScope();
            // Executing script in scope
            source.Execute(scope);*/

            // Gather info from user
            Console.WriteLine("Enter Hostname or IP address to connect to: ");
            string ipAddress = Console.ReadLine();

            Console.WriteLine("login as: ");
            string username = Console.ReadLine();

            Console.WriteLine("password: ");
            string password = Console.ReadLine();

            // PasswordAuthenticationMethod(string username, string password)
            // Nan's pi: user-pi / password-raspberry | Oscar's pi: user-pi / pass - HowdyAgs22
            AuthenticationMethod method = new PasswordAuthenticationMethod(username, password);

            // ConnectionInfo(string host, string username, params AuthenticationMethod[] authenticationMethod)
            // Nan's pi: 172.20.10.12 | Oscar's pi: 192.168.1.80
            ConnectionInfo connection = new ConnectionInfo(ipAddress, username, method);
            var client = new SshClient(connection);

            if(!client.IsConnected)
            {
                Console.WriteLine("Connecting...");
                // Attempt to connect to device
                client.Connect();

                if (client.IsConnected)
                {
                    Console.WriteLine("Successfully connected!");
                }
                else
                {
                    Console.WriteLine("Did not connect successfully...");
                }
            }
            else
            {
                Console.WriteLine("Already connected");
            }

            var readCommand = client.RunCommand("uname -mrs");
            Console.WriteLine(readCommand.Result);
            // var writeCommand = client.RunCommand("mkdir \"/home/")
        }
    }
}
