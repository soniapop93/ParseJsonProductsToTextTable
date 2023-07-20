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

            // identify how many spaces are needed
            for (int i = 0; i < productsList.Count; i++)
            {
                itemsLength[0] = productsList[i].id.ToString().Length > itemsLength[0] ? productsList[i].id.ToString().Length : itemsLength[0]; // id
                itemsLength[1] = productsList[i].title.Length > itemsLength[1] ? productsList[i].title.Length : itemsLength[1]; // title

                string description = checkLenDescription(productsList[i].description);

                itemsLength[2] = description.Length > itemsLength[2] ? description.Length : itemsLength[2]; // description
                itemsLength[3] = productsList[i].price.ToString().Length > itemsLength[3] ? productsList[i].price.ToString().Length : itemsLength[3]; // price
                itemsLength[4] = productsList[i].discountPercentage.ToString().Length > itemsLength[4] ? productsList[i].discountPercentage.ToString().Length : itemsLength[4]; // discount Percentage
                itemsLength[5] = productsList[i].rating.ToString().Length > itemsLength[5] ? productsList[i].rating.ToString().Length : itemsLength[5]; // rating
                itemsLength[6] = productsList[i].stock.ToString().Length > itemsLength[6] ? productsList[i].stock.ToString().Length : itemsLength[6]; // stock
                itemsLength[7] = productsList[i].brand.Length > itemsLength[7] ? productsList[i].brand.Length : itemsLength[7]; // brand
                itemsLength[8] = productsList[i].category.Length > itemsLength[8] ? productsList[i].category.Length : itemsLength[8]; // category
                itemsLength[9] = productsList[i].thumbnail.Length > itemsLength[9] ? productsList[i].thumbnail.Length : itemsLength[9]; // thumbnail
            }

            // add spaces
            for (int i = 0; i < itemsLength.Count; i++) 
            {
                if (columns[i].Length > itemsLength[i])
                {
                    itemsLength[i] = columns[i].Length;
                }

                if (!text.Contains(columns[i].ToString()))
                {
                    text += columns[i] + addSpaces(itemsLength[i] - columns[i].Length) + " | ";
                }
            }
            text += "\n";

            // generate table
            for (int i = 0; i < productsList.Count; i++)
            {
                text += productsList[i].id.ToString() + addSpaces(itemsLength[0] - productsList[i].id.ToString().Length) + " | ";
                text += productsList[i].title + addSpaces(itemsLength[1] - productsList[i].title.Length) + " | ";

                string description = checkLenDescription(productsList[i].description);

                text += description + addSpaces(itemsLength[2] - description.Length) + " | ";
                text += productsList[i].price.ToString() + addSpaces(itemsLength[3] - productsList[i].price.ToString().Length) + " | ";
                text += productsList[i].discountPercentage.ToString() + addSpaces(itemsLength[4] - productsList[i].discountPercentage.ToString().Length) + " | ";
                text += productsList[i].rating.ToString() + addSpaces(itemsLength[5] - productsList[i].rating.ToString().Length) + " | ";
                text += productsList[i].stock.ToString() + addSpaces(itemsLength[6] - productsList[i].stock.ToString().Length) + " | ";
                text += productsList[i].brand + addSpaces(itemsLength[7] - productsList[i].brand.Length) + " | ";
                text += productsList[i].category + addSpaces(itemsLength[8] - productsList[i].category.Length) + " | ";
                text += productsList[i].thumbnail + addSpaces(itemsLength[9] - productsList[i].thumbnail.Length) + " | ";
                text += " \n";
            }

            return text;
        }

        private string addSpaces(int len)
        {
            string spacesStr = "";
            
            for (int i = 0; i <= len; i++)
            {
                spacesStr = spacesStr + " ";
            }
            return spacesStr;
        }

        // check the length of the description
        private string checkLenDescription(string description)
        {
            if (description.Length > 30)
            {
                return description.Substring(0, 30) + "..."; 
            }
            return description;
        }
    }
}