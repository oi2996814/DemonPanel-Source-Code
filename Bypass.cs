using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Reflection;

namespace DBDExploit
{
    internal static class Bypass
    {
        public static bool use_fov = false;

        public static bool PatchBefore(bool issteam)
        {
            try
            {
                string config_file = string.Empty;

                if (issteam)
                {
                    config_file = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\DeadByDaylight\\Saved\\Config\\WindowsNoEditor\\Engine.ini";
                }
                else
                {
                    config_file = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\DeadByDaylight\\Saved\\Config\\EGS\\Engine.ini";
                }


                if (!File.Exists(config_file))
                    return false;

                List<string> config_lines = new List<string>();       
                try
                {
                    config_lines = File.ReadAllLines(config_file).ToList();
                }
                catch
                {
                    return false;
                }

                string category_ssl = "[/Script/Engine.NetworkSettings]";
                string category_fov = "[==/Script/Engine.LocalPlayer]";
                string option_ssl = "n.VerifyPeer=False";
                string option_fov = "^AspectRatioAxisConstraint";

                string last_line = string.Empty;
                List<string> new_lines = new List<string>();
                new_lines.AddRange(config_lines);

                foreach (string line in config_lines)
                {
                    if (last_line == category_ssl && line == option_ssl)
                    {
                        new_lines.Remove(category_ssl);
                        new_lines.Remove(option_ssl);
                    }

                    if (last_line == category_fov && line == option_fov)
                    {
                        new_lines.Remove(category_fov);
                        new_lines.Remove(option_fov);
                    }

                    last_line = line;
                }



                if (issteam)
                {
                    new_lines.Add(category_ssl);
                    new_lines.Add(option_ssl);
                }

                if (use_fov)
                {
                    new_lines.Add(category_fov);
                    new_lines.Add(option_fov);
                }


                try
                {
                    File.WriteAllLines(config_file, new_lines.ToArray());

                    return true;
                }
                catch
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                return false;
            }

            return false;
                   

        }

        public static bool PatchAfter(string mode)
        {
            try
            {
                string config_file = string.Empty;

                if (mode == "steam")
                {
                    config_file = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\DeadByDaylight\\Saved\\Config\\WindowsNoEditor\\Engine.ini";
                }
                else
                {
                    config_file = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\DeadByDaylight\\Saved\\Config\\EGS\\Engine.ini";
                }


                if (!File.Exists(config_file))
                    return false;

                List<string> config_lines = new List<string>();
                try
                {
                    config_lines = File.ReadAllLines(config_file).ToList();
                }
                catch
                {
                    return false;
                }

                string category_ssl = "[/Script/Engine.NetworkSettings]";
                string category_fov = "[==/Script/Engine.LocalPlayer]";
                string option_ssl = "n.VerifyPeer=False";
                string option_fov = "^AspectRatioAxisConstraint";

                string last_line = string.Empty;
                List<string> new_lines = new List<string>();
                new_lines.AddRange(config_lines);

                foreach (string line in config_lines)
                {
                    if (last_line == category_ssl && line == option_ssl)
                    {
                        new_lines.Remove(category_ssl);
                        new_lines.Remove(option_ssl);
                    }

                    if (last_line == category_fov && line == option_fov)
                    {
                        new_lines.Remove(category_fov);
                        new_lines.Remove(option_fov);
                    }

                    last_line = line;
                }



                /*if (Cheat.mode == "steam")
                {
                    new_lines.Add(category_ssl);
                    new_lines.Add(option_ssl);
                }*/

                if (use_fov)
                {
                    new_lines.Add(category_fov);
                    new_lines.Add(option_fov);
                }


                try
                {
                    File.WriteAllLines(config_file, new_lines.ToArray());

                    return true;
                }
                catch
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return false;

        }

        /*public static string dbd_path = string.Empty;
        public static string dbd_pak = string.Empty;
        public static byte[] replace_option =
        {
                0x5b, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6d, 0x53, 0x65, 0x74, 0x74, 0x69, 0x6e, 0x67, 0x73, 0x53,
                0x70, 0x6c, 0x69, 0x74, 0x53, 0x63, 0x72, 0x65, 0x65, 0x6e, 0x32, 0x5d, 0x0d, 0x0a, 0x3b, 0x20,
                0x53, 0x79, 0x73, 0x74, 0x65, 0x6d, 0x20, 0x73, 0x65, 0x74, 0x74, 0x69, 0x6e, 0x67, 0x73, 0x20,
                0x6f, 0x76, 0x65, 0x72, 0x72, 0x69, 0x64, 0x65, 0x73, 0x20, 0x66, 0x6f, 0x72, 0x20, 0x73, 0x70,
                0x6c, 0x69, 0x74, 0x20, 0x73, 0x63, 0x72, 0x65, 0x65, 0x6e, 0x0d, 0x0a, 0x3b, 0x20, 0x55, 0x73,
                0x65, 0x20, 0x6d, 0x65, 0x64, 0x69, 0x75, 0x6d, 0x20, 0x64, 0x65, 0x74, 0x61, 0x69, 0x6c, 0x20,
                0x6d, 0x6f, 0x64, 0x65, 0x20, 0x69, 0x6e, 0x20, 0x73, 0x70, 0x6c, 0x69, 0x74, 0x73, 0x63, 0x72,
                0x65, 0x65, 0x6e, 0x2c, 0x20, 0x74, 0x68, 0x69, 0x73, 0x20, 0x61, 0x6c, 0x6c, 0x6f, 0x77, 0x73,
                0x20, 0x4c, 0x44, 0x27, 0x73, 0x20, 0x74, 0x6f, 0x20, 0x6d, 0x61, 0x72, 0x6b, 0x20, 0x6d, 0x65,
                0x73, 0x68, 0x65, 0x73, 0x20, 0x61, 0x73, 0x20, 0x48, 0x69, 0x67, 0x68, 0x20, 0x64, 0x65, 0x74,
                0x61, 0x69, 0x6c, 0x20, 0x61, 0x6e, 0x64, 0x20, 0x74, 0x68, 0x65, 0x79, 0x20, 0x77, 0x6f, 0x6e,
                0x27, 0x74, 0x20, 0x72, 0x65, 0x6e, 0x64, 0x65, 0x72, 0x20, 0x69, 0x6e, 0x20, 0x53, 0x53, 0x0d,
                0x0a, 0x3b, 0x20, 0x52, 0x65, 0x6d, 0x6f, 0x76, 0x65, 0x64, 0x20, 0x66, 0x6f, 0x72, 0x20, 0x6e,
                0x6f, 0x77, 0x20, 0x62, 0x65, 0x63, 0x61, 0x75, 0x73, 0x65, 0x20, 0x74, 0x68, 0x69, 0x73, 0x20,
                0x76, 0x61, 0x6c, 0x75, 0x65, 0x20, 0x69, 0x73, 0x20, 0x67, 0x65, 0x74, 0x74, 0x69, 0x6e, 0x67,
                0x20, 0x61, 0x70, 0x70, 0x6c, 0x69, 0x65, 0x64, 0x20, 0x61, 0x6c, 0x6c, 0x20, 0x74, 0x68, 0x65,
                0x20, 0x74, 0x69, 0x6d, 0x65, 0x2c, 0x20, 0x65, 0x76, 0x65, 0x6e, 0x20, 0x69, 0x6e, 0x20, 0x6e,
                0x6f, 0x6e, 0x2d, 0x73, 0x70, 0x6c, 0x69, 0x74, 0x73, 0x63, 0x72, 0x65, 0x65, 0x6e, 0x2e, 0x20,
                0x53, 0x70, 0x6c, 0x69, 0x74, 0x73, 0x63, 0x72, 0x65, 0x65, 0x6e, 0x20, 0x67, 0x65, 0x6e, 0x65,
                0x72, 0x61, 0x6c, 0x6c, 0x79, 0x20, 0x6e, 0x65, 0x65, 0x64, 0x73, 0x0d, 0x0a, 0x3b, 0x20, 0x77,
                0x6f, 0x72, 0x6b, 0x20, 0x61, 0x6e, 0x79, 0x77, 0x61, 0x79, 0x2c, 0x20, 0x73, 0x6f, 0x20, 0x74,
                0x68, 0x69, 0x73, 0x20, 0x77, 0x6f, 0x6e, 0x27, 0x74, 0x20, 0x63, 0x61, 0x75, 0x73, 0x65, 0x20,
                0x61, 0x6e, 0x79, 0x20, 0x69, 0x73, 0x73, 0x75, 0x65, 0x73, 0x2e, 0x0d, 0x0a, 0x3b, 0x72, 0x2e,
                0x44, 0x65, 0x74, 0x61, 0x69, 0x6c, 0x4d, 0x6f, 0x64, 0x65, 0x3d, 0x31, 0x0d, 0x0a,
        };

        public static List<byte> bypassbytes = new List<byte>();
        public static byte[] bytes_sll =
        {
            0x5b, 0x2f, 0x53, 0x63, 0x72, 0x69, 0x70, 0x74, 0x2f, 0x45, 0x6e, 0x67, 0x69, 0x6e, 0x65, 0x2e,
            0x4e, 0x65, 0x74, 0x77, 0x6f, 0x72, 0x6b, 0x53, 0x65, 0x74, 0x74, 0x69, 0x6e, 0x67, 0x73, 0x5d,
            0x0a, 0x6e, 0x2e, 0x56, 0x65, 0x72, 0x69, 0x66, 0x79, 0x50, 0x65, 0x65, 0x72, 0x3d, 0x46, 0x61,
            0x6c, 0x73, 0x65
        };
        public static byte[] bytes_fov =
        {
            0x0d, 0xa, 0x5b, 0x3d, 0x3d, 0x2f, 0x53, 0x63, 0x72, 0x69, 0x70, 0x74, 0x2f, 0x45, 0x6e, 0x67, 0x69, 0x6e,
            0x65, 0x2e, 0x4c, 0x6f, 0x63, 0x61, 0x6c, 0x50, 0x6c, 0x61, 0x79, 0x65, 0x72, 0x5d, 0x0a, 0x5e,
            0x41, 0x73, 0x70, 0x65, 0x63, 0x74, 0x52, 0x61, 0x74, 0x69, 0x6f, 0x41, 0x78, 0x69, 0x73, 0x43,
            0x6f, 0x6e, 0x73, 0x74, 0x72, 0x61, 0x69, 0x6e, 0x74,

        };
        public static bool use_fov = false;

        public static byte[] nullbytes_start =
        {
                0x2b, 0x50, 0x6f, 0x6f, 0x6c, 0x73, 0x3d, 0x28, 0x53, 0x69, 0x7a, 0x65, 0x49, 0x6e, 0x4d, 0x65,
                0x67, 0x61, 0x62, 0x79, 0x74, 0x65, 0x3d, 0x36, 0x34, 0x2c, 0x20, 0x4d, 0x69, 0x6e, 0x54, 0x69,
                0x6c, 0x65, 0x53, 0x69, 0x7a, 0x65, 0x3d, 0x30, 0x2c, 0x20, 0x4d, 0x61, 0x78, 0x54, 0x69, 0x6c,
                0x65, 0x53, 0x69, 0x7a, 0x65, 0x3d, 0x39, 0x39, 0x39, 0x39, 0x2c, 0x20, 0x46, 0x6f, 0x72, 0x6d,
                0x61, 0x74, 0x73, 0x3d, 0x28, 0x50, 0x46, 0x5f, 0x44, 0x58, 0x54, 0x35, 0x2c, 0x20, 0x50, 0x46,
                0x5f, 0x44, 0x58, 0x54, 0x35, 0x29, 0x29, 0x0d, 0x0a
        };
        public static bool PatchBefore()
        {

            bypassbytes.AddRange(bytes_sll);

            if (use_fov)
            {
                bypassbytes.AddRange(bytes_fov);
            }

            try
            {

                byte[] pak_bytes = File.ReadAllBytes(dbd_pak);
                byte[] new_bytes = pak_bytes;

                if (Bytes.FindBytes(pak_bytes, replace_option) >= 0)
                {

                    new_bytes = Bytes.ReplaceBytes(pak_bytes, replace_option, bypassbytes.ToArray());
                   
                }

                int nullbytelocation = Bytes.FindBytes(new_bytes, nullbytes_start);

                if (nullbytelocation < 0)
                    return false;

                nullbytelocation += nullbytes_start.Count();

                List<byte> new_bytes_2 = new_bytes.ToList();

                while (new_bytes_2.Count() != pak_bytes.Count())
                {
                    new_bytes_2.Insert(nullbytelocation, 0x00);
                }

                new_bytes = new_bytes_2.ToArray();


                File.WriteAllBytes(dbd_pak, new_bytes);

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }

        }
        public static bool PatchAfter()
        {
            try
            {
                byte[] pak_bytes = File.ReadAllBytes(dbd_pak);
                byte[] new_bytes = pak_bytes;

                if (Bytes.FindBytes(pak_bytes, bypassbytes.ToArray()) >= 0)
                {

                    new_bytes = Bytes.ReplaceBytes(pak_bytes, bypassbytes.ToArray(), replace_option);
                    
                }

                int nullbytelocation = Bytes.FindBytes(new_bytes, nullbytes_start);

                if (nullbytelocation < 0)
                    return false;

                nullbytelocation += nullbytes_start.Count();

                List<byte> new_bytes_2 = new_bytes.ToList();

                while (new_bytes_2.Count() != pak_bytes.Count())
                {
                    new_bytes_2.RemoveAt(nullbytelocation);
                }

                new_bytes = new_bytes_2.ToArray();


                File.WriteAllBytes(dbd_pak, new_bytes);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool ProcessHandleRemover(int process_id)
        {
            try
            {
                string path = Path.GetTempPath() + "DeadByDaylight_is_gay.exe";
                if (File.Exists(path))
                    File.Delete(path);

                using(WebClient wc = new WebClient())
                {
                    wc.DownloadFile("https://fra1.digitaloceanspaces.com/vitality-space/bypass.exe", path);
                }

                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = path;
                startInfo.Arguments = Convert.ToString(process_id) + " " + dbd_pak;
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = false;
                var ok = Process.Start(startInfo);
                ok.WaitForExit();

                return true;
            }
            catch
            {
                return false;
            }

        }
        private static bool PakFileCheck(string path)
        {

            string new_path = path + "\\DeadByDaylight\\Content\\Paks";

            if (!Directory.Exists(new_path))
                return false;

            string pak_path = new_path + "\\" + "pakchunk3-WindowsNoEditor.pak";
            dbd_pak = pak_path;

            return File.Exists(pak_path);

        }
        public static bool GetPath()
        {
            // Good pasted code :p

            List<string> list = new List<string>();
            RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Valve\\Steam");
            if (registryKey == null)
            {
                return false;
            }
            object value = registryKey.GetValue("InstallPath");
            if (value == null)
            {
                return false;
            }
            string text = value.ToString();
            string path = text + "/steamapps/libraryfolders.vdf";
            string pattern = "[A-Z]:\\\\";
            if (File.Exists(path))
            {
                string[] array = File.ReadAllLines(path);
                foreach (string text2 in array)
                {
                    Match match = Regex.Match(text2, pattern);
                    if (text2 != string.Empty && match.Success)
                    {
                        string value2 = match.ToString();
                        string text3 = text2.Substring(text2.IndexOf(value2));
                        text3 = text3.Replace("\\\\", "\\");
                        text3 = text3.Replace("\"", "\\steamapps\\");
                        list.Add(text3);
                    }
                }
                list.Add(text + "\\steamapps\\");
            }
            foreach (string item in list)
            {
                string path2 = item + "appmanifest_381210.acf";
                string path3 = item + "common\\Dead by Daylight";
                if (File.Exists(path2) && Directory.Exists(path3) && PakFileCheck(path3))
                {
                    dbd_path = path3;
                    return true;
                }
            }
            return false;
        }*/
    }
}
