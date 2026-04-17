using CsvHelper;
using ForJakub.core.interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ForJakub.core
{
    internal class SaveCSV : ISave
    {
        public bool Save(IPerson person)
        {
            using var writer = new StreamWriter("C:\\Users\\Lukasz\\source\\repos\\ForJakub\\ForJakub\\Files\\current_score.csv");
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

            try
            {
                csv.WriteRecord(person);
            }
            catch (Exception) 
            {
                return false; 
            }
            return true;
        }

        public bool SaveFile(IEnumerable<IPerson> PersonEnumerable)
        {
            throw new NotImplementedException();
        }

        public bool SaveNewRow(IPerson person)
        {
            throw new NotImplementedException();
        }
    }
}
