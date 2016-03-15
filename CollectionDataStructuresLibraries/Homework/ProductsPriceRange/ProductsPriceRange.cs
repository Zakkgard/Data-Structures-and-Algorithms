namespace ProductsPriceRange
{
    using System;
    using System.Text;

    using Wintellect.PowerCollections;

    public class ProductsPriceRange
    {
        public static void Main()
        {
            var products = new OrderedBag<Product>();
            var builder = new StringBuilder();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var productPriceTokens = Console.ReadLine().Split();
                var name = productPriceTokens[0];
                var price = float.Parse(productPriceTokens[1]);

                products.Add(new Product(name, price));
            }

            var pricesTokens = Console.ReadLine().Split();
            var lower = float.Parse(pricesTokens[0]);
            var upper = float.Parse(pricesTokens[1]);

            var subrangeProducts = products.Range(new Product(string.Empty, lower), true, new Product(string.Empty, upper), true);

            foreach (var product in subrangeProducts)
            {
                Console.WriteLine(product.ToString());
            }
        }
    }
}
