using System.Collections.Generic;
using System.Text;

namespace ParseJsonProductsToTextTable.Json
{
    public class Products
    {
        public List<Product> products { get; set; }

        public Products(List<Product> products)
        {
            this.products = products;
        }

        private void getProducts()
        {

        }
    }

}
