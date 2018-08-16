using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDB.FileOperations
{
    public class FileOperationsImpl : IFileOps
    {
        public string Directory { get; private set; }
        public int SegmentLength { get; private set; }

        private FileOperationsImpl() { }

        public static IFileOps NewInstance(string directory, int lineLength)
        {
            return new FileOperationsImpl().Init(directory, lineLength);
        }

        public IFileOps Init(string directory, int lineLength)
        {
            this.Directory = directory;
            this.SegmentLength = lineLength;

            System.IO.Directory.CreateDirectory(directory);

            if (!System.IO.File.Exists(Directory))
                System.IO.File.Create(Directory);
            else
            {
                System.IO.File.Delete(Directory);
                var st = System.IO.File.Create(Directory);
                st.Flush(); st.Dispose();
            }


            return this;
        }

        public string ReadLine(int rowIndex)
        {
            using (var fs = System.IO.File.Open(Directory, System.IO.FileMode.OpenOrCreate))
            {
                fs.Position = rowIndex * SegmentLength;
                byte[] result = new byte[SegmentLength];

                fs.Read(result, 0, SegmentLength);

                return Util.Util.GetString(result);
            }
        }

        public void WriteLine(string line, int rowIndex)
        {
            using (var fs = System.IO.File.Open(Directory, System.IO.FileMode.OpenOrCreate))
            {
                var bytes = Util.Util.GetBytes(line);
                fs.Position = rowIndex * bytes.Length;
                fs.Write(bytes, 0, bytes.Length);
            }
        }
    }
}
