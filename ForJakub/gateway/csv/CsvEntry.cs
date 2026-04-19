using ForJakub.core;
using ForJakub.gateway.interfaces;
using System.Data;

using static ForJakub.gateway.CsvGameColumnNames;

namespace ForJakub.gateway.csv
{
    internal class CsvEntry : ISavable<Entry>
    {
        private DataRow entryData;

        public CsvEntry() => entryData = new DataTable().NewRow();
        public CsvEntry(DataRow ed) => entryData = ed;

        public Entry Get()
        {
            return new()
            {
                Player = new CsvPlayer(entryData).Get(),
                PlayerPlacement = (int)entryData[GetFriendlyName(Names.PlayerPlacement)],
                PointsGain = (double)entryData[GetFriendlyName(Names.PointsGain)]
            };
        }

        public void Set(Entry data)
        {
            DataTable table = new();
            var cp = new CsvPlayer();
            cp.Set(data.Player);
            foreach (var prop in data.GetType().GetProperties())
            {
                if (prop.PropertyType.IsAssignableTo(typeof(Player)))
                {
                    foreach (DataColumn col in cp.GetDataTable().Columns)
                    {
                        table.Columns.Add(GetFriendlyName(Enum.Parse<Names>(col.ColumnName)), col.DataType);
                    }
                }
                else
                {
                    table.Columns.Add(prop.Name, prop.PropertyType);
                }
            }
            DataRow row = table.NewRow();

            foreach (var prop in data.GetType().GetProperties())
            {
                if (prop.PropertyType.IsAssignableTo(typeof(Player)))
                {
                    foreach(DataColumn col in cp.GetDataTable().Columns)
                    {
                        row[col] = prop.GetValue(data);
                    }
                }
                else
                {
                    row[prop.Name] = prop.GetValue(data);
                }
            }

            entryData = table.NewRow();
        }


        public DataRow GetDataRow(int index = 0) => entryData;

        public DataTable GetDataTable() => entryData.Table;

    }
}
