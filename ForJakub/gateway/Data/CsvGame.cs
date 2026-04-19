using ForJakub.core;
using ForJakub.core.interdaces;
using ForJakub.gateway.interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ForJakub.gateway.Data
{
    internal class CsvGame(DataTable dt) : ISavable<Game>
    {
        private DataTable gameData = dt;

        public void Set(Game data)
        {
            DataTable table = new();
            foreach (var name in CsvGameColumnNames.GetFriendlyNames())
            {
                var type = data.GetType().getP

            }

            foreach (var entry in data.playerEntries)
            {
                DataRow row = table.NewRow();
                foreach (var prop in entry.GetType().GetProperties())
                {
                    row[prop.Name] = prop.GetValue(data);
                }
                table.Rows.Add(row);

            }
            gameData = table;
        }

        public Game Get()
        {
            return null;
        }


        public DataTable GetDataTable() => gameData;

        public DataRow GetDataRow(int index = 0) => gameData.Rows[index];
    }
}
