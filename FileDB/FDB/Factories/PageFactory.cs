using FDB.Attributes;
using FDB.FileOperations;
using FDB.Model;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace FDB.Factories
{
    public class PageFactory<T>
    {
        public PageFactory()
        {

        }
        
        public Page<T> Build()
        {
            ValidateOrThrow();

            string tableName = typeof(T).Name;
            string directoryPath = Configuration.Config.ConfigInstance.RootDirectory;
            string fullPath = directoryPath + "/" + tableName + ".fdb";

            int rowLength = RowLengthSum();

            Page<T> page = new Page<T>(FileOperationsImpl.NewInstance(fullPath, rowLength));

            return page;
        }

        private static int RowLengthSum()
        {
            int sum = 0;
            var props = typeof(T).GetRuntimeProperties();
            foreach (var prop in props)
            {
                sum += prop.GetCustomAttribute<ColumnAttribute>().LengthMax;
            }

            return sum;
        }

        private void ValidateOrThrow()
        {
            //string strMessage = "";
            //if (Page == null)
            //    strMessage = "Page not initialized";
            //else if(string.IsNullOrEmpty(Page.FullPath))
            //    strMessage = "Page path error";

            //if (!string.IsNullOrEmpty(strMessage))
            //{
            //    throw new Exception(strMessage);
            //}
        }
    }
}
