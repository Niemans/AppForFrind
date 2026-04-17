using System;
using System.Collections.Generic;
using System.Text;

namespace ForJakub.core.interfaces
{
    internal interface ISave
    {
        public bool SaveNewRow(Person person);
        
        public bool Save(Person person);
        
        public bool SaveFile(IEnumerable<Person> PersonEnumerable);


    }
}
