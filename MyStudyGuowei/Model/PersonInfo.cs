using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    /// <summary>
    /// 反射调用日志类和方法，记录日志
    /// </summary>
    public class PersonInfo
    {
        public void GetVlaues()
        {
            Assembly asm = Assembly.Load("Model");
            Type t = asm.GetType("Model.OperationLog");
            object OperLog = Activator.CreateInstance(t, true);
            MethodInfo mf = t.GetMethod("WriteLog");
            mf.Invoke(OperLog, new object[] { "1231231" });
            MethodInfo mf2 = t.GetMethod("Close");
            mf2.Invoke(OperLog, null);
            //OperLog
        }
    }
    public class ReturnValue<T>
    {
        public bool IsSuccess { get; set; }
        public T Member { get; set; }
        public string ErrMessage { get; set; }
        public ReturnValue(bool issuccess, string errmessage)
        {
            IsSuccess = issuccess;
            ErrMessage = errmessage;
        }
    }
}
