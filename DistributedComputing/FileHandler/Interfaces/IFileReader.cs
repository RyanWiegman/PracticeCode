using DistributedComputing.Model;

namespace DistributedComputing.FileHandler.Interfaces;

public interface IFileReader
{
    IEnumerable<SalesData> ReadData(string filePath);
}