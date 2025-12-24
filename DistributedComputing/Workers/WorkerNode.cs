using DistributedComputing.FileHandler;
using DistributedComputing.FileHandler.Interfaces;
using DistributedComputing.Statistics;
using DistributedComputing.Model;

namespace DistributedComputing.Workers;


public class WorkerNode
{
    private string _filePath = string.Empty;

    private IEnumerable<SalesData> _data;

    public WorkerNode(string filePath)
    {
        Console.WriteLine($"WORKER NODE: reading {Path.GetFileName(filePath)}");

        _filePath = filePath;

        IFileReader fileReader = new FileReader();
        _data = fileReader.ReadData(filePath);
    }

    public async Task<string> RunAsync()
    {
        if (!_data.Any())
            return $"{_filePath}: FAILED";


        // var regionSales = Task.Run(() =>
        // {
        //     TotalSalesPerRegion totalSalesPerRegion = new(_filePath);
        //     return totalSalesPerRegion.Calculate(_data);
        // });

        // var productSales = Task.Run(() =>
        // {
        //     TotalSalesPerProduct totalSalesPerProduct = new(_filePath);
        //     return totalSalesPerProduct.Calculate(_data);
        // });

        // var categorySales = Task.Run(() =>
        // {
        //     TotalSalesPerCategory categorySale = new(_filePath);
        //     return categorySale.Calculate(_data);
        // }
        // );

        // var resultList = await Task.WhenAll(regionSales, productSales, categorySales);
        // return $"{_filePath} :: {resultList.All(x => x)}";

        Task.Run(() =>
        {
            TotalSalesPerRegion totalSalesPerRegion = new(_filePath);
            totalSalesPerRegion.Calculate(_data);
        });

        Task.Run(() =>
        {
            TotalSalesPerProduct totalSalesPerProduct = new(_filePath);
            totalSalesPerProduct.Calculate(_data);
        });

        Task.Run(() =>
        {
            TotalSalesPerCategory categorySale = new(_filePath);
            categorySale.Calculate(_data);
        }
        );

        return $"{_filePath} :: DONE";
    }


    #region non-async

    public string Run()
    {
        if (!_data.Any())
            return $"{_filePath} :: FAILED";

        TotalSalesPerRegion totalSalesPerRegion = new(_filePath);
        totalSalesPerRegion.Calculate(_data);

        TotalSalesPerProduct totalSalesPerProduct = new(_filePath);
        totalSalesPerProduct.Calculate(_data);

        TotalSalesPerCategory categorySale = new(_filePath);
        categorySale.Calculate(_data);

        return $"{_filePath} :: DONE";
    }

    #endregion
}