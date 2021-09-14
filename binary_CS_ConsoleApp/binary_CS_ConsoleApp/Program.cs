/***************************
 * Original code made by YouTube channel: Tony & Chelsea Northrup
 * Video URL: https://www.youtube.com/watch?v=jPj1GlD6mDk 
 ***************************/

using System;
using System.IO;

namespace binary_CS_ConsoleApp
{
    /// <summary>
    /// This program creates and writes to a binary file.
    /// It can also read the file that was created, using System.IO.
    /// Specifically, creates a file then has the current time written into it.
    /// Then, reads and outputs the file to a console. 
    /// </summary>
    class Program
    {
        static void SaveCurrentTime()
        {
            FileStream fs = new FileStream("time.bin", FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);

            bw.Write(DateTime.Now.Hour);
            bw.Write(DateTime.Now.Minute);

            bw.Close();
            fs.Close();
        }

        static void ShowCurrentTime()
        {
            FileStream fs = new FileStream("time.bin", FileMode.Open);
            BinaryReader br = new BinaryReader(fs);

            string previousTime = br.ReadInt32() + ":" + br.ReadInt32();
            Console.WriteLine(previousTime);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello User!");
            Console.Write("Your current time is --> ");  // Does not \n 

            SaveCurrentTime();
            ShowCurrentTime();
            Console.ReadKey();
        }
    }
}
