using ForJakub.core;
using ForJakub.core.interdaces;
using ForJakub.gateway.interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ForJakub.gateway.Data
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
                PlayerID = (ulong)playerData[CsvGameColumnNames.GetFriendlyName(CsvGameColumnNames.Names.PlayerID)],
                PlayerName = (string)playerData[CsvGameColumnNames.GetFriendlyName(CsvGameColumnNames.Names.PlayerName)],
                PlayerCurrentPoints = (double)playerData[CsvGameColumnNames.GetFriendlyName(CsvGameColumnNames.Names.PlayerCurrentPoints)]
            };
        }

        public void Set(Player data)
        {
            DataTable table = new();
            foreach (var prop in data.GetType().GetProperties())
            {
                table.Columns.Add(prop.Name, prop.PropertyType);
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
