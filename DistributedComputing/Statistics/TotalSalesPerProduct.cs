using System.Text;
using DistributedComputing.Logging;
using DistributedComputing.Model;

namespace DistributedComputing.Statistics;

public class TotalSalesPerProduct
{
    private string FilePath { get; set; }
    private Dictionary<string, float> TotalSales = new();

    public TotalSalesPerProduct(string filePath)
    {
        // Console.WriteLine($"TOTALSALESPERPRODUCT: Calculating: {Path.GetFileName(filePath)}");
        FilePath = filePath;
    }

    public bool Calculate(IEnumerable<SalesData> data)
    {
        if (data is null || !data.Any())
            return false;

        foreach (SalesData item in data)
        {
            if (!TotalSales.ContainsKey(item.Product))
            {
                TotalSales.Add(item.Product, item.TotalSale);
                continue;
            }

            if (TotalSales.TryGetValue(item.Product, out float value))
            {
                TotalSales[item.Product] = value + item.TotalSale;
            }
        }

        OutputData();
        return true;
    }

    private void OutputData()
    {
        // Console.WriteLine($"TOTALSALESPERPRODUCT:: writing output for {Path.GetFileName(FilePath)}");

        StringBuilder sb = new();
        sb.AppendLine($"File: {Path.GetFileName(FilePath)}");
        sb.AppendLine("Product:\tTotal Sales:");
        sb.AppendLine("".PadRight(24, '-'));
        foreach (var item in TotalSales)
        {
            sb.AppendLine($"{item.Key}\t{item.Value}");
        }
        sb.AppendLine("".PadRight(24, '-'));

        LoggingExtensions.WriteDebug(sb.ToString());
    }

}