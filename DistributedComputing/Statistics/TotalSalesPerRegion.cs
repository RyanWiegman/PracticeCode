using System.Text;
using DistributedComputing.Logging;
using DistributedComputing.Model;

namespace DistributedComputing.Statistics;

public class TotalSalesPerRegion
{
    private string FilePath { get; set; }

    public Dictionary<string, float> TotalSales { get; } = new()
    {
        {"West", 0.0f},
        {"East", 0.0f},
        {"North", 0.0f},
        {"South", 0.0f}
    };

    public TotalSalesPerRegion(string filepath)
    {
        // Console.WriteLine($"TOTALSALESPERREGION: Calculating: {Path.GetFileName(filepath)}");
        FilePath = filepath;
    }

    public bool Calculate(IEnumerable<SalesData> data)
    {
        if (data is null || !data.Any())
            return false;

        foreach (var item in data)
        {
            if (TotalSales.TryGetValue(item.Region, out float value))
            {
                TotalSales[item.Region] = value + item.TotalSale;
            }
        }

        OutputData();
        return true;
    }

    private void OutputData()
    {
        // Console.WriteLine($"TOTALSALESPERREGION:: writing output for {Path.GetFileName(FilePath)}");

        StringBuilder sb = new();
        sb.AppendLine($"File: {Path.GetFileName(FilePath)}");
        sb.AppendLine("Region:\tTotal Sales:");
        sb.AppendLine("".PadRight(24, '-'));
        foreach (var item in TotalSales)
        {
            sb.AppendLine($"{item.Key}\t{item.Value}");
        }
        sb.AppendLine("".PadRight(24, '-'));

        LoggingExtensions.WriteDebug(sb.ToString());
    }
}