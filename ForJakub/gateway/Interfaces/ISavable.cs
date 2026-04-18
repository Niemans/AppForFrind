using ForJakub.core.interdaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ForJakub.gateway.interfaces
{
    internal interface ISavable<T> where T : IData
    {
        public DataRow GetDataRow(int index = 0);
        public DataTable GetDataTable();
        public T? MapTo();
        public void GetFrom(T data);
    }
}
