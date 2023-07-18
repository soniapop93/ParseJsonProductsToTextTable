using ParseJsonProductsToTextTable.Json;

namespace ParseJsonProductsToTextTable.Text
{
    public class GenerateTextTable
    {
        string text { get; set; }

        public string generateTable(Products products)
        {
            text = "";
            List<int> itemsLength = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            List<string> columns = new List<string>() { "ID", "Title", "Description", "Price", "Discount Percentage", "Rating", "Stock", "Brand", "Category", "Thumbnail" };

            List<Product> productsList = products.products;

            for (int i = 0; i < productsList.Count; i++)
            {
                itemsLength[0] = productsList[i].id.ToString().Length > itemsLength[0] ? productsList[i].id.ToString().Length : itemsLength[0]; // id
                itemsLength[1] = productsList[i].title.Length > itemsLength[1] ? productsList[i].title.Length : itemsLength[1]; // title
                itemsLength[2] = productsList[i].description.Length > itemsLength[2] ? productsList[i].description.Length : itemsLength[2]; // description
                itemsLength[3] = productsList[i].price.ToString().Length > itemsLength[3] ? productsList[i].price.ToString().Length : itemsLength[3]; // price
                itemsLength[4] = productsList[i].discountPercentage.ToString().Length > itemsLength[4] ? productsList[i].discountPercentage.ToString().Length : itemsLength[4]; // discount Percentage
                itemsLength[5] = productsList[i].rating.ToString().Length > itemsLength[5] ? productsList[i].rating.ToString().Length : itemsLength[5]; // rating
                itemsLength[6] = productsList[i].stock.ToString().Length > itemsLength[6] ? productsList[i].stock.ToString().Length : itemsLength[6]; // stock
                itemsLength[7] = productsList[i].brand.Length > itemsLength[7] ? productsList[i].brand.Length : itemsLength[7]; // brand
                itemsLength[8] = productsList[i].category.Length > itemsLength[8] ? productsList[i].category.Length : itemsLength[8]; // category
                itemsLength[9] = productsList[i].thumbnail.Length > itemsLength[9] ? productsList[i].thumbnail.Length : itemsLength[9]; // thumbnail

                if (!text.Contains(columns[0].ToString()))
                {
                    text += columns[0] + addSpaces(itemsLength[0] - columns[0].Length) + " | \n";

                }
                else
                {
                    text += productsList[i].id.ToString() + addSpaces(itemsLength[0] - productsList[i].id.ToString().Length) + " | \n";
                }
            }

            return text;
        }

        public void generateColumn(string text, int len)
        {

        }

        private string addSpaces(int len)
        {
            string spacesStr = "";
            
            for (int i = 0; i < len; i++)
            {
                spacesStr = spacesStr + " ";
            }
            return spacesStr;
        }

    }
}
