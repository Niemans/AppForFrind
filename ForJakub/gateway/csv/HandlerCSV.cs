using CsvHelper;
using ForJakub.gateway.interfaces;
using Microsoft.Extensions.Configuration;
using System.Globalization;
using ForJakub.core.interfaces;
using ForJakub.gateway.csv.mappers;
using ForJakub.gateway.csv.objectsCSV;

namespace ForJakub.gateway.csv
{
    internal sealed class HandlerCSV<T, U> : IHandler<T>
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
            using var writer = new StreamWriter(FilePath);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            
            csv.WriteHeader<U>();
            csv.NextRecord();
            
            try
            {
                csv.WriteRecord(MapperRegistry.Map<T, U>(data));
            }
            catch (InvalidOperationException)
            {
                csv.WriteRecords(MapperRegistry.MapToList<T, U>(data));
            }
            catch
            {
                csv.Flush();
                return false;
            }

            csv.Flush();
            return true;
        }

        public bool SaveAll(IEnumerable<T> data)
        {
            using var writer = new StreamWriter(FilePath);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

            csv.WriteHeader<U>();
            csv.NextRecord();

            var list = data.ToList();
            try
            {
                csv.WriteRecords(list.Select(MapperRegistry.Map<T, U>));
            }
            catch (InvalidOperationException)
            {
                csv.WriteRecords(list.Select(MapperRegistry.MapToList<T, U>).SelectMany(csvList => csvList));
            }
            catch
            {
                csv.Flush();
                return false;
            }

            csv.Flush();
            return true;
        }

        public IEnumerable<T> Read()
        {
            using var reader = new StreamReader(FilePath);
            using var csv =  new CsvReader(reader, CultureInfo.InvariantCulture);
            
            var records = csv.GetRecords<U>().ToList();
            return records.Select(MapperRegistry.Map<T,U>);
        }
        
        private static string InitializePath()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();
            var appSettings = configuration.Get<AppSettings>() ?? new AppSettings([]);
            var file = appSettings.CsvFiles.FirstOrDefault(f => f.FileName.Contains(typeof(T).Name)) ?? new CsvFile("");
            return Path.Combine("../../../data", file.FileName);
        }
        
        private record CsvFile(string FileName);
        private record AppSettings(List<CsvFile> CsvFiles);
    }
}