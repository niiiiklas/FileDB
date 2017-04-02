using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDB.FileOperations
{
    public interface IFileOps
    {
        IFileOps Init(string directory, int lineLength);
        void WriteLine(string line, int rowIndex);
        string ReadLine(int rowIndex);
    }
}
