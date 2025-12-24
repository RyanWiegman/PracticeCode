using DistributedComputing.Logging;
using DistributedComputing.Model;

namespace DistributedComputing.Statistics;

public class TotalSalesPerCategory
{
    private string FilePath { get; }
    private Dictionary<string, float> TotalSales = new();

    public TotalSalesPerCategory(string filepath)
    {
        FilePath = filepath;
    }

    public bool Calculate(IEnumerable<SalesData> data)
    {
        if (data is null || !data.Any())
            return false;

        foreach (SalesData item in data)
        {
            if (!TotalSales.ContainsKey(item.Category))
            {
                TotalSales.Add(item.Category, item.TotalSale);
                continue;
            }

            if (TotalSales.TryGetValue(item.Category, out float value))
            {
                TotalSales[item.Category] = value + item.TotalSale;
            }
        }

        OutputData();
        return true;
    }

    private void OutputData()
    {
        // Console.WriteLine($"TOTALSALESPERCATEGORY:: writing output for {Path.GetFileName(FilePath)}");

        System.Text.StringBuilder sb = new();
        sb.AppendLine($"File: {Path.GetFileName(FilePath)}");
        sb.AppendLine("Category:\tTotal Sales:");
        sb.AppendLine("".PadRight(24, '-'));
        foreach (var item in TotalSales)
        {
            sb.AppendLine($"{item.Key}\t{item.Value}");
        }
        sb.AppendLine("".PadRight(24, '-'));

        LoggingExtensions.WriteDebug(sb.ToString());
    }
}