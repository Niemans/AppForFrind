using ForJakub.core;
using ForJakub.gateway.interfaces;
using System.Data;
using static ForJakub.gateway.CsvGameColumnNames;

namespace ForJakub.gateway.csv
{
    internal class CsvGame : ISavable<Game>
    {
        private DataTable gameData;

        public CsvGame() => gameData = new DataTable();
        public CsvGame(DataTable gd) => gameData = gd;

        public Game Get()
        {
            List<Entry> entries = new();

            foreach (DataRow entry in gameData.Rows)
            {
                entries.Add(new CsvEntry(entry).Get());
            }

            return new()
            {
                GameID = (ulong)gameData.Rows[0][GetFriendlyName(Names.GameID)],
                Comment = (string)gameData.Rows[0][GetFriendlyName(Names.Comment)],
                Time = (DateTime)gameData.Rows[0][GetFriendlyName(Names.Comment)],
                playerEntries = entries
            };
        }

        public void Set(Game data)
        {
            DataTable table = new();
            var ce = new CsvEntry();
            ce.Set(data.playerEntries[0]);
            foreach (var prop in data.GetType().GetProperties())
            {
                if (prop.PropertyType.IsAssignableTo(typeof(Player)))
                {
                    foreach (DataColumn col in ce.GetDataTable().Columns)
                    {
                        table.Columns.Add(GetFriendlyName(Enum.Parse<Names>(col.ColumnName)), col.DataType);
                    }
                }
                else
                {
                    table.Columns.Add(prop.Name, prop.PropertyType);
                }
            }

            foreach (var entry in data.playerEntries)
            {
                ce.Set(entry);
                DataRow row = table.NewRow();

                foreach (var prop in data.GetType().GetProperties())
                {
                    if (prop.PropertyType.IsAssignableTo(typeof(Entry)))
                    {
                        foreach (DataColumn col in ce.GetDataTable().Columns)
                        {
                            row[col] = prop.GetValue(data);
                        }
                    }
                    else
                    {
                        row[prop.Name] = prop.GetValue(data);
                    }
                }
            }
            gameData = table;

        }


        public DataTable GetDataTable() => gameData;

        public DataRow GetDataRow(int index = 0) => gameData.Rows[index];
    }
}
