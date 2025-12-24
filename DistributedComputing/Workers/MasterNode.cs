using System.Collections.Concurrent;

namespace DistributedComputing.Workers;

public class MasterNode
{
    private List<string> Files = new();
    private ConcurrentBag<string> resultsAsync = new();

    public MasterNode(bool isAsync)
    {
        Console.WriteLine("Lets get those files");
        if (isAsync)
        {
            GetFilesAsync();
            RunAsync();
            PrintResultsAsync();
        }
        else
        {
            GetFiles();
            Run();
            PrintResults();
        }
    }

    private void GetFilesAsync()
    {
        // DirectoryInfo d = new("/home/ryan/workspace/docs/dummyData/easyData");
        DirectoryInfo d = new("/home/ryan/workspace/docs/dummyData");


        foreach (var item in d.GetFiles())
        {
            Console.WriteLine($"file name: {item.FullName}");
            Files.Add(item.FullName);
        }
    }

    private void RunAsync()
    {
        Parallel.ForEach(Files, async file =>
        {
            try
            {
                WorkerNode worker = new(file);
                var result = await worker.RunAsync();
                resultsAsync.Add(result);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"Error processing {file}: {ex.Message}");
            }
        });
    }

    private void PrintResultsAsync()
    {
        Console.WriteLine("\n\n### Results ###");

        foreach (var item in resultsAsync)
        {
            Console.WriteLine($"{item}");
        }
    }

    #region non-async

    private List<string> results = new();

    private void GetFiles()
    {
        DirectoryInfo d = new("/home/ryan/workspace/docs/dummyData");

        foreach (var item in d.GetFiles())
        {
            Console.WriteLine($"file name: {item.FullName}");
            Files.Add(item.FullName);
        }
    }

    private void Run()
    {
        foreach (var file in Files)
        {
            WorkerNode worker = new(file);
            var result = worker.Run();
            results.Add(result);
        }
    }

    private void PrintResults()
    {
        Console.WriteLine("### Results ###");

        foreach (var item in results)
        {
            Console.WriteLine($"{item}");
        }
    }

    #endregion
}