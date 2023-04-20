using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store_system
{
    public class Store
    {
        private string name;
        private string type;
        private double revenue;
        private List<Product> availableProducts;

        public Store(string name, string type)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Store name cannot be null or empty!");
            }

            if (string.IsNullOrEmpty(type))
            {
                throw new ArgumentException("Store type cannot be null or empty!");
            }

            this.name = name;
            this.type = type;
            this.revenue = 0;
            this.availableProducts = new List<Product>();
        }

        public bool ReceiveProduct(Product product)
        {
            if (availableProducts.Any(p => p.Name == product.Name))
            {
                return false;
            }

            availableProducts.Add(product);
            return true;
        }

        public bool SellProduct(string name, int quantity)
        {
            var product = availableProducts.FirstOrDefault(p => p.Name == name);

            if (product == null || product.Quantity < quantity)
            {
                return false;
            }

            product.Quantity -= quantity;

            if (product.Quantity == 0)
            {
                availableProducts.Remove(product);
            }

            revenue += quantity * product.FinalPrice;

            return true;
        }

        public Product GetProduct(string name)
        {
            return availableProducts.FirstOrDefault(p => p.Name == name);
        }

        public override string ToString()
        {
            var availableProductsString = string.Join("\n", availableProducts.Select(p => $"****** {p.Name} ({p.Quantity})"));

            return $"Store: {name} <{type}>\n" +
                $"Available products: <{availableProducts.Count}>\n" +
                $"{availableProductsString}\n" +
                $"Revenue: <{revenue:F2}BGN>";
        }
    }
}
