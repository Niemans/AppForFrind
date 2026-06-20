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
        private static string FilePath
        {
            get
            {
                if(field != null) return field;
                field = InitializePath();
                return field;
            }
        }

        
        public bool Save(T data)
        {
            using var csv = PrepareWriter();
            
            csv.WriteHeader<U>();

            try
            {
                var csvData = MapperRegistry.Map<T, U>(data);
                csv.NextRecord();
                csv.WriteRecord(csvData);
            }
            catch (InvalidOperationException)
            {
                var csvList = MapperRegistry.MapToList<T, U>(data);
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
            using var csv = PrepareWriter();

            csv.WriteHeader<T>();

            var list = data.ToList();
            try
            {
                foreach (var csvData in list.Select(MapperRegistry.Map<T, U>))
                {
                    csv.NextRecord();
                    csv.WriteRecord(csvData);
                }
            }
            catch (InvalidOperationException)
            {
                foreach (var csvData in list.Select(MapperRegistry.MapToList<T, U>).SelectMany(csvList => csvList))
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

        private static string InitializePath()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();
            var a = configuration.Get<AppSettings>() ?? new AppSettings([]);
            var file = a.CsvFiles.FirstOrDefault(f => f.FileName.Contains(typeof(T).Name)) ?? new CsvFile("");
            return Path.Combine("../../../data", file.FileName);
        }
        
        private static CsvWriter PrepareWriter()
        {
            var writer = new StreamWriter(FilePath);
            return new CsvWriter(writer, CultureInfo.InvariantCulture);
        }
        
        private record CsvFile(string FileName);
        private record AppSettings(List<CsvFile> CsvFiles);
    }
}