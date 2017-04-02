using System;
using System.Collections.Generic;
using System.Text;

namespace FDB.FileOperations.Util
{
    public class Util
    {
        static Encoding Enc = Encoding.UTF8;

        public static byte[] GetBytes(string str, bool addNewLine = false)
        {
            return Enc.GetBytes(str);
        }

        public static string GetString(byte[] bytes)
        {
            return Enc.GetString(bytes);
        }
    }
}
