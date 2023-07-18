using ParseJsonProductsToTextTable.Json;
using ParseJsonProductsToTextTable.Text;
using System.Diagnostics.Metrics;
using System.Text.Json;

public class Program
{
    public static void Main(string[] args)
    {
        /*
           =============================================================
           =============================================================


           =============================================================
           =============================================================
        */

        Console.WriteLine("------------------------ SCRIPT STARTED ------------------------");

        RequestManager requestManager = new RequestManager();
        GenerateTextTable generateTextTable = new GenerateTextTable();

        string response = requestManager.getProducts("https://dummyjson.com/products");

        Console.WriteLine("Deserializing data response ...");

        if (!String.IsNullOrEmpty(response))
        {
           Products products = JsonSerializer.Deserialize<Products>(response);
           Console.WriteLine(generateTextTable.generateTable(products));


        }
        else
        {
            Console.WriteLine("Response from request is null or empty");
        }

        Console.WriteLine("------------------------ SCRIPT FINISHED ------------------------");
    }
}