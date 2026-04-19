using ForJakub.core;
using ForJakub.core.interdaces;
using ForJakub.gateway.interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ForJakub.gateway.Data
{
    internal class CsvEntry : ISavable<Entry>
    {
        private DataRow entryData;

        public CsvEntry() => entryData = new DataTable().NewRow();
        public CsvEntry(DataRow entryData) => this.entryData = entryData;

        public Entry Get()
        {
            return new()
            {
                Player = new CsvPlayer(entryData).Get(),
                PlayerPlacement = (int)entryData[CsvGameColumnNames.GetFriendlyName(CsvGameColumnNames.Names.PlayerPlacement)],
                PointsGain = (double)entryData[CsvGameColumnNames.GetFriendlyName(CsvGameColumnNames.Names.PointsGain)]
            };
        }
        public void Set(Entry data)
        {
            DataTable table = new();
            foreach (var prop in data.GetType().GetProperties())
            {
                if (prop.PropertyType.IsAssignableTo(typeof(Player)))
                {
                    table.Columns.AddRange(new CsvPlayer(entryData).GetDataTable().Columns);
                }
                else
                {
                    table.Columns.Add(prop.Name, prop.PropertyType);
                }
            }
        }

        public DataRow GetDataRow(int index = 0) => entryData;

        public DataTable GetDataTable() => entryData.Table;

    }
}
