using CsvHelper;
using ForJakub.gateway.interfaces;
using Microsoft.Extensions.Configuration;
using System.Globalization;
using ForJakub.core.interfaces;
using ForJakub.gateway.csv.mappers;

namespace ForJakub.gateway.csv
{
    internal sealed class SaveCSV<T, U> : ISave<T>
        where T : IData
        where U : IDataCSV<T>
    {
        private static AppSettings Settings
        {
            get
            {
                if (field != null) return field;
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: false)
                    .Build();
                field = configuration.Get<AppSettings>() ?? new([]);

                return field;
            }
        }

        public bool Save(T data)
        {
            var file = Settings.CsvFiles
                           .FirstOrDefault(f => f.FileName.Contains(typeof(T).Name))
                       ?? new CsvFile("");
            var path = Path.Combine("../../../data", file.FileName);

            using var writer = new StreamWriter(path);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

            csv.WriteHeader<U>();

            try
            {
                var csvData = MapperRegistry.GetMapper<U, T>()
                    .Map(data);
                csv.NextRecord();
                csv.WriteRecord(csvData);
            }
            catch (InvalidOperationException)
            {
                var csvList = MapperRegistry.GetMapper<U, T>()
                    .MapToList(data).ToList();
                foreach (var csvData in csvList)
                {
                    csv.NextRecord();
                    csv.WriteRecord(csvData);
                }
            }
            catch
            {
                return false;
            }

            csv.Flush();
            return true;
        }

        public bool SaveFile(IEnumerable<T> data)
        {
            var file = Settings.CsvFiles
                           .FirstOrDefault(f => f.FileName.Contains(typeof(T).Name))
                       ?? new CsvFile("");
            var path = Path.Combine("../../../data", file.FileName);

            using var writer = new StreamWriter(path);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

            csv.WriteHeader<T>();

            var list = data.ToList();
            var mapper = MapperRegistry.GetMapper<U, T>();
            try
            {
                foreach (var entry in list)
                {
                    var csvData = mapper.Map(entry);
                    csv.NextRecord();
                    csv.WriteRecord(csvData);
                }
            }
            catch (InvalidOperationException)
            {
                foreach (var entry in list)
                {
                    var csvList = mapper.MapToList(entry);
                    foreach (var csvData in csvList)
                    {
                        csv.NextRecord();
                        csv.WriteRecord(csvData);
                    }
                }
            }
            catch
            {
                return false;
            }

            csv.Flush();
            return true;
        }


        private record CsvFile(string FileName);

        private record AppSettings(List<CsvFile> CsvFiles);
    }
}