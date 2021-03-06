﻿using System;
using System.IO;
using System.Text;

namespace QLSoTietKiem.Helpers
{
    public class Logger
    {
        private static string strpath = AppDomain.CurrentDomain.BaseDirectory + "Logs\\";
        public static void WriteLogInfo(string subject, string content)
        {
            string filename = "QLSTK.info." + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            StreamWriter sw = new StreamWriter(strpath + filename, true, Encoding.Unicode);
            sw.WriteLine(DateTime.Now.ToString() + " INFO : " + subject + " : " + content);
            sw.WriteLine();
            sw.Flush();
            sw.Close();
        }

        public static void WriteLogError(string subject, string content)
        {
            string filename = "QLSTK.error." + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            StreamWriter sw = new StreamWriter(strpath + filename, true, Encoding.Unicode);
            sw.WriteLine(DateTime.Now.ToString() + " ERROR : " + subject + " : " + content);
            sw.WriteLine();
            sw.Flush();
            sw.Close();
        }

        private static void Remove(int n)
        {
            try
            {
                string[] filepaths = Directory.GetFiles(strpath);
                foreach (string file in filepaths)
                {
                    if (file.Contains("CallLog.log"))
                    {
                        FileInfo l_file = new FileInfo(file);
                        if (DateTime.Now.DayOfYear - l_file.LastWriteTime.DayOfYear > n)
                        {
                            File.Delete(file);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLogError("Logger :------RemoveFile :", ex.Message);
            }
        }
    }
}
