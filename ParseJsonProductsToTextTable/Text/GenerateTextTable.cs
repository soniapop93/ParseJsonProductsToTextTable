using ParseJsonProductsToTextTable.Json;

namespace ParseJsonProductsToTextTable.Text
{
    public class GenerateTextTable
    {
        string text { get; set; }

        public void generateTable(Products products)
        {
            List<int> itemsLength = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            List<Product> productsList = products.products;

            for (int i = 0; i < productsList.Count; i++)
            {
                itemsLength[0] = productsList[i].id.ToString().Length > itemsLength[0] ? productsList[i].id.ToString().Length : itemsLength[0]; // id
                itemsLength[1] = productsList[i].title.Length; // title
                itemsLength[2] = productsList[i].description.Length; // description
                itemsLength[3] = productsList[i].price.ToString().Length; // price
                itemsLength[4] = productsList[i].discountPercentage.ToString().Length; // discount Percentage
                itemsLength[5] = productsList[i].rating.ToString().Length; // rating
                itemsLength[6] = productsList[i].stock.ToString().Length; // stock
                itemsLength[7] = productsList[i].brand.Length; // brand
                itemsLength[8] = productsList[i].category.Length; // category
                itemsLength[9] = productsList[i].thumbnail.Length; // thumbnail
            }
        }

    }
}
