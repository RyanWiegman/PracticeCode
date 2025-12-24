using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using DistributedComputing.FileHandler.Interfaces;
using DistributedComputing.Model;

namespace DistributedComputing.FileHandler;

public class FileReader : IFileReader
{
    public IEnumerable<SalesData>? ReadData(string filePath)
    {
        if (filePath is null)
            return null;

        using var reader = new StreamReader(filePath);
        // var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
        // {
        //     HasHeaderRecord = false
        // };
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        IEnumerable<SalesData> data = csv.GetRecords<SalesData>().ToList();

        return data;
    }
    
}