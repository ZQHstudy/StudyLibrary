using MyLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //OperationLog.WriteLog(DateTime.Now + "张庆豪");
                //operLog.WriteLog(DateTime.Now + "张庆豪");
                //operLog.WriteLog(DateTime.Now + "张庆豪");
                Log.Write(DateTime.Now + "张庆豪2");
                Log.Write(DateTime.Now + "张庆豪2");
                Log.Write(DateTime.Now + "张庆豪2");
                MD5 mD5  = MD5.Create();
                //string str=mD5.
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //operLog.Close();
                Log.Close();
            }
            PersonInfo per = new PersonInfo();
            per.GetVlaues();
            Console.Read();
        }

    }
}
