﻿using FDB.FileOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FDB.Model
{
    public interface IPageOperations<T>
    {
        void Save(T entity);
        void Get(object key);
    }


    public class Page<T> : IPageOperations<T>
    {
        IFileOps FileOperations { get; set; }

        public Page(IFileOps fileOps)
        {
            this.FileOperations = fileOps;
        }

        public void Save(T entity)
        {
            var row = Parser.Parser.ToRow(entity);
            string line = Parser.Parser.ToStringLine(row);
            FileOperations.WriteLine(line, 0);
        }

        public void Get(object key)
        {
            throw new NotImplementedException();
        }
    }
}
