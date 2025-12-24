namespace DistributedComputing.Model;

public class SalesData
{
    public int TransactionID { get; set; }
    public DateTime Date { get; set; }
    public string Region { get; set; }
    public string Product { get; set; }
    public string Category { get; set; }
    public int Quantity { get; set; }
    public float UnitPrice { get; set; }
    public float TotalSale { get; set; } 
}