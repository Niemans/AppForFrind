using ForJakub.core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForJakub.gateway.interfaces
{
    internal interface ISave
    {
        public bool Save(Player person);
        
        public bool SaveFile(IEnumerable<Player> PersonEnumerable);


    }
}
