namespace CollectionOfProducts
{
    using System.Collections.Generic;

    using Wintellect.PowerCollections;

    public class ProductCollection
    {
        private Dictionary<int, Product> byId;
        private Dictionary<string, SortedSet<Product>> byTitle;
        private Dictionary<string, SortedSet<Product>> byTitlePrice;
        private Dictionary<string, OrderedDictionary<decimal, SortedSet<Product>>> byTitlePriceRange;
        private Dictionary<string, SortedSet<Product>> bySupplierPrice;
        private Dictionary<string, OrderedDictionary<decimal, SortedSet<Product>>> bySupplierPriceRange;

        public ProductCollection()
        {
            this.byId = new Dictionary<int, Product>();
            this.bySupplierPrice = new Dictionary<string, SortedSet<Product>>();
            this.bySupplierPriceRange = new Dictionary<string, OrderedDictionary<decimal, SortedSet<Product>>>();
            this.byTitle = new Dictionary<string, SortedSet<Product>>();
            this.byTitlePrice = new Dictionary<string, SortedSet<Product>>();
            this.byTitlePriceRange = new Dictionary<string, OrderedDictionary<decimal, SortedSet<Product>>>();
        }
    }
}
