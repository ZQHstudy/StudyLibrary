using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    /// <summary>
    /// 日志
    /// </summary>
    public class OperationLog
    {
        private static OperationLog OperLog = null;
        StreamWriter Writer;
        private OperationLog()
        {
            string path = ConfigurationManager.AppSettings["LogPath"];
            if (string.IsNullOrWhiteSpace(path))
            {
                path = Directory.GetCurrentDirectory() + "Log.txt";
            }
            if (File.Exists(path))
            {
                Console.WriteLine("已存在");
            }
            //fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite,FileShare.ReadWrite);
            Writer = new StreamWriter(path, true);
        }

        public static OperationLog GetOperLog()
        {
            if (OperLog == null)
            {
                OperLog = new OperationLog();
            }
            return OperLog;
        }
        public void WriteLog(string str)
        {
            Writer.WriteLine(str);
            Writer.Flush();
        }
        public void Close()
        {
            Writer.Flush();
            Writer.Close();
        }
    }
    public static class Log
    {
        static StreamWriter Writer;
        static Log()
        {
            string path = ConfigurationManager.AppSettings["LogPath"];
            if (string.IsNullOrWhiteSpace(path))
            {
                path = Directory.GetCurrentDirectory() + "Log.txt";
            }
            if (File.Exists(path))
            {
                Console.WriteLine("已存在");
            }
            //fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite,FileShare.ReadWrite);
            Writer = new StreamWriter(path, true);
        }
        public static void Write(string str)
        {
            Writer.WriteLine(str);
        }
        public static void Close()
        {
            Writer.Flush();
            Writer.Close();
        }
    }
    public class GetNum
    {
        public void Write(string str)
        {
            Console.WriteLine(str);
        }
    }
}
