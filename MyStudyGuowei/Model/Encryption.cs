using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Encryption
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="Flag">默认为True表示获取文件的MD5摘要，为False则表示获取字符串的MD5加密</param>
        /// <param name="Length">可以为16和32，表示获取的MD5数据的长度</param>
        /// <returns></returns>
        public string MD5Encry(string Source, bool Flag = true, Length length = Length.Long)
        {
            EncryptionMD5 mD5 = new EncryptionMD5();
            string strValue = null;
            if (Flag)
            {
                if (Directory.Exists(Source))
                {
                    strValue = mD5.EncryptinFile(Source);
                }
            }
            else
            {
                strValue = mD5.Encryption(Source);
            }
            switch ((int)length)
            {
                case 16:
                    strValue = strValue.Substring(9, 24);
                    break;
                case 32:
                    strValue = strValue.Substring(0, 32);
                    break;
                default:
                    break;
            }
            return strValue;
        }
    }
    public enum Length
    {
        /// <summary>
        /// 获取16位的MD5加密结果
        /// </summary>
        Short = 16,
        /// <summary>
        /// 获取32位的MD5加密结果
        /// </summary>
        Long = 32
    }
    public class EncryptionMD5
    {
        public string EncryptinFile(string FileName)
        {
            using (FileStream fs = new FileStream(FileName, FileMode.Open))
            {
                return MD5EncryByStream(fs);
            }
        }
        public string Encryption(string Source)
        {
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(Source));
            return MD5EncryByStream(stream);
        }
        private string MD5EncryByStream(Stream stream)
        {
            MD5 mD5 = new MD5CryptoServiceProvider();
            Byte[] buffer = mD5.ComputeHash(stream);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < buffer.Length; i++)
            {
                sb.Append(buffer[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
    public class EncrytionAes
    {
        //秘钥
        private string Key = "zhangqinghao";
        public EncrytionAes(string key)
        {
            this.Key = key;
        }
        public string Encrytion(string str)
        {
            byte[] Bt = Encoding.UTF8.GetBytes(str);
            RijndaelManaged rijndael = new RijndaelManaged()
            {
                Key =Encoding.UTF8.GetBytes(Key),
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            ICryptoTransform crypto = rijndael.CreateEncryptor();
            byte[] vs = crypto.TransformFinalBlock(Bt, 0, Bt.Length);
            return Convert.ToBase64String(vs);
        }
        public string Decrytion(string str)
        {
            byte[] Bt = Encoding.UTF8.GetBytes(str);
            RijndaelManaged rijndael = new RijndaelManaged()
            {
                Key=Encoding.UTF8.GetBytes(Key),
                Mode=CipherMode.ECB,
                Padding=PaddingMode.PKCS7
            };
            ICryptoTransform crypto = rijndael.CreateDecryptor();
            byte[] vs = crypto.TransformFinalBlock(Bt,0,Bt.Length);
            return Encoding.UTF8.GetString(vs);
        }
    }

}
