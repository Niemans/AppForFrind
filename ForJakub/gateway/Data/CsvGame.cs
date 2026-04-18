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

        public void GetFrom(Game data)
        {
            DataTable table = new();

            table.Columns.AddRange([
                new("a"),
                new("b")
                ]);


            foreach (var entry in data.playerEntry)
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

        public Game? MapTo()
        {
            return null;
        }


        public DataTable GetDataTable() => gameData;

        public DataRow GetDataRow(int index = 0) => gameData.Rows[index];
    }
}
