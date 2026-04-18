using ForJakub.core;
using ForJakub.core.interdaces;
using ForJakub.gateway.interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ForJakub.gateway.Data
{
    internal class CsvPlayer(DataRow dr) : ISavable<Player>
    {
        private DataRow playerData = dr;

        public void GetFrom(Player data)
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

        public Player? MapTo()
        {

            Player p = new()
            {
                ID = (int)playerData["ID"],
                Name = (string)playerData["Name"],
                CurentPoints = (double)playerData["CurentPoints"]
            };

            return p;
        }

        public DataRow GetDataRow(int index = 0) => playerData;

        public DataTable GetDataTable() => playerData.Table;

    }
}
