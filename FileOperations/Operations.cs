using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FileOperations
{
    public class Operations
    {
        // public List<FileInfo> fileList = new List<FileInfo>();
        //enum FileOperations
        //{
        //    Copy,
        //    Move,
        //};

        public void CheckDestination(DirectoryInfo destination)
        {
            if (!destination.Exists)
            {
                destination.Create();
            }
        }

        public void CopyDirectory(DirectoryInfo source, DirectoryInfo destination, string task)
        {
            CheckDestination(destination);
            FileInfo[] files = source.GetFiles();
            foreach (FileInfo file in files)
            {
                if (task == "copy")
                {
                    file.CopyTo(Path.Combine(destination.FullName, file.Name));
                }
                else if(task == "move")
                {
                    file.MoveTo(Path.Combine(destination.FullName, file.Name));
                }
             }
            DirectoryInfo[] dirs = source.GetDirectories();
            foreach (DirectoryInfo dir in dirs)
            {
                string destinationDir = Path.Combine(destination.FullName, dir.Name);
                if(task == "move")
                {
                    dir.MoveTo(destinationDir);
                }
                CopyDirectory(dir, new DirectoryInfo(destinationDir),task);
            }
        }

        public void MoveDirectory(DirectoryInfo source, DirectoryInfo destination, string task)
        {
            CheckDestination(destination);
            CopyDirectory(source,destination,task);
        }

        public void ListDirectory(DirectoryInfo source)
        {
            FileInfo[] files = source.GetFiles();
            foreach (FileInfo file in files)
            {
                Console.WriteLine(" " + file.Name);
            }
            DirectoryInfo[] dirs = source.GetDirectories();
            foreach (DirectoryInfo dir in dirs)
            {
                Console.WriteLine(dir.Name);

                string sourceDir = Path.Combine(source.FullName, dir.Name);
                ListDirectory(new DirectoryInfo(sourceDir));
            }
        }
    }
}