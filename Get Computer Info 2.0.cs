using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Threading;

namespace Get_Computer_Info_2._0
{
    class Program
    {
        private static string FILE_PATH = "info.txt";

        static void Main(string[] args)
        {
            string[] TotalInfoArray = new string[4];
            TotalInfoArray[0] = GetIPAddress();
            TotalInfoArray[1] = GetMacAddress();
            TotalInfoArray[2] = GetSystemInfo();
            TotalInfoArray[3] = GetAllApplications();

            DirectoryInfo dirInf = CreateFolder(TotalInfoArray[0]);

            CreateFile(dirInf.Name + "\\IP Address.txt", TotalInfoArray[0]);

            CreateFile(dirInf.Name + "\\Mac Address.txt", TotalInfoArray[1]);

            CreateFile(dirInf.Name + "\\System Info.txt", TotalInfoArray[2]);

            TotalInfoArray[3] = AlphebatiseLines(TotalInfoArray[3]);

            CreateFile(dirInf.Name + "\\All Applications.txt", TotalInfoArray[3]);
        }

        static string AlphebatiseLines(string words)
        {
            string output = "";

            string[] TotalWordsArray = words.Split('\r');
            List<string> list = new List<string>();

            foreach(string i in TotalWordsArray)
            {
                list.Add(i);
            }

            list.Sort();

            foreach(string i in list)
            {
                output += i + "\n";
            }

            output = output.Trim();

            return output;
        }

        static void CreateFile(string path, string contents)
        {
            try
            {
                File.WriteAllText(path, contents);
            }
            catch (IOException)
            {
                Console.WriteLine(Process.GetCurrentProcess());
                Thread.Sleep(5000);
            }
        }

        static DirectoryInfo CreateFolder(string ipstring)
        {
            string[] IPAddressString = ipstring.Split(' ');
            string NewFoldername = "";
            NewFoldername += FindString(IPAddressString, "Host", 15);
            NewFoldername += FindString(IPAddressString, "Physical", 11);
            string loss = FindString(new string[] { }, "Lost", 4);
            NewFoldername = NewFoldername.Replace("\r\n", " ");

            DirectoryInfo dirInf = Directory.CreateDirectory(NewFoldername);

            return dirInf;
        }

        static string FindString(string[] words, string stringToFind, int indexer)
        {
            string output = "";
            int j = 0;

            foreach(string i in words)
            {
                if (i == stringToFind)
                {
                    output += words[j + indexer] + " ";
                }
                j++;
            }

            return output;
        }

        static string GetIPAddress()
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardInput = true;
            startInfo.FileName = "cmd.exe";
            process.StartInfo = startInfo;
            process.Start();

            process.StandardInput.WriteLine("ipconfig /all");

            process.StandardInput.Flush();
            process.StandardInput.Close();

            string output = process.StandardOutput.ReadToEnd();
            process.Close();

            return output;
        }

        
        static string GetMacAddress()
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardInput = true;
            startInfo.FileName = "cmd.exe";
            process.StartInfo = startInfo;
            process.Start();

            process.StandardInput.WriteLine("getmac");

            process.StandardInput.Flush();
            process.StandardInput.Close();

            string output = process.StandardOutput.ReadToEnd();
            process.Close();

            return output;
        }

        static string GetSystemInfo()
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardInput = true;
            startInfo.FileName = "cmd.exe";
            process.StartInfo = startInfo;
            process.Start();

            process.StandardInput.WriteLine("systeminfo");

            process.StandardInput.Flush();
            process.StandardInput.Close();

            string output = process.StandardOutput.ReadToEnd();
            process.Close();

            return output;
        }

        static string GetAllApplications()
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardInput = true;
            startInfo.FileName = "cmd.exe";
            process.StartInfo = startInfo;
            process.Start();

            process.StandardInput.WriteLine("wmic");
            process.StandardInput.WriteLine("product get name");

            process.StandardInput.Flush();
            process.StandardInput.Close();

            string output = process.StandardOutput.ReadToEnd();
            process.Close();

            return output;
        }
        
    }
}
