using System;
using System.Collections.Generic;
using System.Text;

namespace ForJakub.core.interfaces
{
    internal interface ISave
    {
        public bool SaveNewRow(IPerson person);
        
        public bool Save(IPerson person);
        
        public bool SaveFile(IEnumerable<IPerson> PersonEnumerable);


    }
}
