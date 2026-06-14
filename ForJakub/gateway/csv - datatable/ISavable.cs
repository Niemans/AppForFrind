using ForJakub.core.interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ForJakub.gateway.interfaces
{
    internal interface ISavable<T> where T : IData
    {
        public T Get();
        public void Set(T data);
        public DataRow GetDataRow(int index = 0);
        public DataTable GetDataTable();

    }
}
