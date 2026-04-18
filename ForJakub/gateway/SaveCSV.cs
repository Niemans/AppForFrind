using ForJakub.core;
using ForJakub.gateway.interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ForJakub.gateway
{
    internal class SaveCSV : ISave
    {
        public bool Save(Player person)
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

        public bool SaveFile(IEnumerable<Player> PersonEnumerable)
        {
            throw new NotImplementedException();
        }

        public bool SaveNewRow(Player person)
        {
            throw new NotImplementedException();
        }
    }
}
