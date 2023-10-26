using System.Globalization;
using bakaChiefApplication.API.DatabaseModels;
using CsvHelper;
using CsvHelper.Configuration;

namespace bakaChiefApplication.API.Services;

public static class CsvDataReader
{
    public static List<ProductInfo> ReadCsvFile(string filePath)
    {
        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.CurrentCulture)))
        {
            var records = csv.GetRecords<ProductInfo>();
            return records.ToList();
        }
    }
}
