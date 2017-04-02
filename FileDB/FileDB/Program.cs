using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ff = System.IO.File;
namespace FileDB
{


    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello world");


            try
            {

                new Program().Test();
            }
            catch(Exception e)
            {
                string breaky = "";
            }
            Console.ReadLine();
        }

        public const int LineLength = 12;
        string[] testLines = new string[]
        {
            "Niklas a    ",
            "this is test"
        };

        public void Test()
        {
            var fops = new FileOperations().Init("./Testdbs/test1.txt", 12);
            
            for(int i = 0; i < testLines.Length; i++)
            {
                fops.WriteLine(testLines[i], i);
            }


        }
    }

    public interface FileOPS
    {
        FileOPS Init(string directory, int lineLength);
        void WriteLine(string line, int rowIndex);
        string ReadLine(int rowIndex);
    }

    public class FileOperations : FileOPS
    {
        public string Directory { get; set; }
        public int LineLength { get; set; }
        public FileOPS Init(string directory, int lineLength)
        {
            this.Directory = directory;
            this.LineLength = lineLength;

            if (!ff.Exists(Directory))
                ff.Create(Directory);
            else
            {
                ff.Delete(Directory);
                var st = ff.Create(Directory);
                st.Close();
            }


            return this;
        }

        public string ReadLine(int rowIndex)
        {
            throw new NotImplementedException();
        }

        public void WriteLine(string line, int rowIndex)
        {
            using (var fs = ff.Open(Directory, System.IO.FileMode.OpenOrCreate))
            {
                var bytes = FromString(line);
                fs.Position = rowIndex * bytes.Length;
                fs.Write(bytes, 0, bytes.Length);
            }
        }

        private byte[] FromString(string str, bool appendNL=true)
        {
            if (appendNL) str = str + "\n";
            return Encoding.UTF8.GetBytes(str);
        }
    }
}
