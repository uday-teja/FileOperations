using System;
using System.Web;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace FileOperations
{
    public class FileProgram
    {
        public static void Main(string[] args)
        {
            DirectoryInfo source = new DirectoryInfo(@"E:\Test\SourceFile");
            DirectoryInfo destination = new DirectoryInfo(@"E:\Test\DestinationFile");
            Operations operations = new Operations();
            Console.WriteLine("What u want to do.. ??");
            Console.WriteLine("1. Copy\n2. Move\n3. List");

            int selection = Convert.ToInt32(Console.ReadLine());
            switch (selection)
            {
                case 1:
                    operations.CopyDirectory(source, destination,"copy");
                    Console.WriteLine("Copied Successfuly...!!!!");
                    break;
                case 2:
                    operations.MoveDirectory(source, destination,"move");
                    Console.WriteLine("Moved Successfuly...!!!!");
                    break;
                case 3:
                    Console.WriteLine("\n-----File Directory-----\n");
                    operations.ListDirectory(source);
                    
                    break;
                default:
                    Console.WriteLine("Invalid Selection");
                    break;
            }
        }
    }
}