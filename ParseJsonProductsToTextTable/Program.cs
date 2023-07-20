using ParseJsonProductsToTextTable.Json;
using ParseJsonProductsToTextTable.Text;
using System.Diagnostics.Metrics;
using System.IO;
using System.Text.Json;

public class Program
{
    public static void Main(string[] args)
    {
        /*
           =============================================================
           =============================================================
           [X] Get products from free API: https://dummyjson.com/products
           [X] Deserialize data returned
           [X] Generate text table based on data returned from API request
           [X] Check the length of the description. If it's greater than 
               30 chars, don't display it all
           [X] Write text table in a txt file
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

            string textProductsTable = generateTextTable.generateTable(products);

            Console.WriteLine(textProductsTable);

            using (StreamWriter w = File.AppendText("Products_Table_Text.txt"))
            {
                w.Write(textProductsTable);
            }
        }
        else
        {
            Console.WriteLine("Response from request is null or empty");
        }

        Console.WriteLine("------------------------ SCRIPT FINISHED ------------------------");
    }
}