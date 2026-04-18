using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ForJakub.gateway.Interfaces
{
    internal interface INames<T> where T : Enum
    {
        public string GetFriendlyName(T enumName);

        public string GetFieldName(T enumName);
    }
}
