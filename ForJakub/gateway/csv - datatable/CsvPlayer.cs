using ForJakub.core;
using ForJakub.gateway.interfaces;
using System.Data;

using static ForJakub.gateway.CsvGameColumnNames;

namespace ForJakub.gateway.csv
{
    internal class CsvPlayer : ISavable<Player>
    {
        private DataRow playerData;


        public CsvPlayer() => playerData = new DataTable().NewRow();
        public CsvPlayer(DataRow playerData) => this.playerData = playerData;

        public Player Get()
        {
            return new()
            {
                PlayerID = (ulong)playerData[GetFriendlyName(Names.PlayerID)],
                PlayerName = (string)playerData[GetFriendlyName(Names.PlayerName)],
                PlayerCurrentPoints = (double)playerData[GetFriendlyName(Names.PlayerCurrentPoints)]
            };
        }

        public void Set(Player data)
        {
            DataTable table = new();
            foreach (var prop in data.GetType().GetProperties())
            {
                table.Columns.Add(GetFriendlyName(Enum.Parse<Names>(prop.Name)), prop.PropertyType);
            }

            DataRow row = table.NewRow();
            foreach (var prop in data.GetType().GetProperties())
            {
                row[prop.Name] = prop.GetValue(data);
            }

            playerData = row;
        }

        public DataRow GetDataRow(int index = 0) => playerData;

        public DataTable GetDataTable() => playerData.Table;
    }
}
