using ForJakub.gateway.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using static ForJakub.gateway.GameNames;

namespace ForJakub.gateway
{
    internal class GameNames : INames<Names>
    {
        public string GetFieldName(Names enumName)
        {
            throw new NotImplementedException();
        }

        public string GetFriendlyName(Names enumName)
        {
            throw new NotImplementedException();
        }

        public enum Names
        {

        }
    }
}
