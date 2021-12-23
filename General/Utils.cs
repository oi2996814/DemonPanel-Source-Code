using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace Demon_Panel
{
    internal class Utils
    {
        static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static int FindBytes(byte[] src, byte[] find)
        {
            int index = -1;
            int matchIndex = 0;
            for (int i = 0; i < src.Length; i++)
            {
                if (src[i] == find[matchIndex])
                {
                    if (matchIndex == (find.Length - 1))
                    {
                        index = i - matchIndex;
                        break;
                    }
                    matchIndex++;
                }
                else if (src[i] == find[0])
                {
                    matchIndex = 1;
                }
                else
                {
                    matchIndex = 0;
                }

            }
            return index;
        }
        public static string GetModulePath()
        {
            string returnval = "CouldNotFindPath";
            string text = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] array = new char[8];
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = text[random.Next(text.Length)];
            }
            new string(array);
            List<string> list = new List<string>();
            string str = Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Valve\\Steam").GetValue("InstallPath").ToString();
            string path = str + "/steamapps/libraryfolders.vdf";
            string pattern = "[A-Z]:\\\\";
            if (File.Exists(path))
            {
                foreach (string text2 in File.ReadAllLines(path))
                {
                    Match match = Regex.Match(text2, pattern);
                    if (text2 != string.Empty && match.Success)
                    {
                        string value = match.ToString();
                        string item = text2.Substring(text2.IndexOf(value)).Replace("\\\\", "\\").Replace("\"", "\\steamapps\\");
                        list.Add(item);
                    }
                }
                list.Add(str + "\\steamapps\\");
            }
            foreach (string str2 in list)
            {
                string path2 = str2 + "appmanifest_381210.acf";
                string path3 = str2 + "common\\Dead by Daylight";
                if (File.Exists(path2) && Directory.Exists(path3))
                {
                    returnval = str2 + "common\\Dead by Daylight\\DeadByDaylight\\Content\\Paks\\pakchunk3-WindowsNoEditor.pak";
                }
            }
            return returnval;
        }
        public static void Patch(string path)
        {
            using (Stream stream = File.Open(path, FileMode.Open))
            {
              //  stream.Position = Convert.ToInt32(Login.auth.var("SSLOffset"));
             //   stream.Write(Volume, 0, Volume.Length);
             //   stream.Close();
            }
        }
        public static bool Resurrect(string path)
        {
           // File.WriteAllBytes(path, Login..download("095873"));
            return true;

        }
        public static byte[] cock = new byte[1]
        {
            0
        };
       
        public static byte[] Volume = new byte[76]
        {
            91, 47, 83, 99, 114, 105, 112, 116, 47, 69,
            110, 103, 105, 110, 101, 46, 78, 101, 116, 119,
            111, 114, 107, 83, 101, 116, 116, 105, 110, 103,
            115, 93, 13, 10, 110, 46, 86, 101, 114, 105,
            102, 121, 80, 101, 101, 114, 61, 102, 97, 108,
            115, 101, 13, 10, 13, 10, 13, 10, 13, 10,
            13, 10, 13, 10, 13, 10, 13, 10, 13, 10,
            13, 10, 13, 10, 13, 10
        };
    }
}
