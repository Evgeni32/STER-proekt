using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace store_system
{
    public class StoreController
    {

        private readonly List<Store> stores = new List<Store>();
        public string CreateStore(List<string> args)
        {
            string name = args[0];
            string type = args[1];

            try
            {
                var store = new Store(name, type);
                stores.Add(store);
                return $"Store '{name}' was succesfully registered in the system" +
                    $"!";
            }
            catch (ArgumentException ex)
            {
                return ex.Message;
            }
        }
        public string ReceiveProduct(List<string> args)
        {
            string type = args[0];
            string name = args[1];
            int quantity = int.Parse(args[2]);
            double price = double.Parse(args[3]);
            double percentageMarkup = double.Parse(args[4]);
            string storeName = args[5];

            Store store = stores.FirstOrDefault(s => s.Name == storeName);
            if (store == null)
            {
                return $"Store {storeName} not found.";
            }
            return $"Product {name} was successfully delivered to {storeName}.";
        }

        public string SellProduct(List<string> args)
        {
            string name = args[0];
            int quantity = int.Parse(args[1]);
            string storeName = args[2];

            Store store = stores.FirstOrDefault(s => s.Name == storeName);
            if (store == null)
            {
                return $"Store {storeName} not found.";
            }

            try
            {
                store.SellProduct(name, quantity);
            }
            catch (ArgumentException ex)
            {
                return ex.Message;
            }

            return $"Product {name} was successfully bought from {storeName}.";
        }

        public string StoreInfo(List<string> args)
        {
            string storeName = args[0];

            Store store = stores.FirstOrDefault(s => s.Name == storeName);
            if (store == null)
            {
                return $"Store {storeName} not found.";
            }

            string info = store.ToString();
            return info;
            
            //string info = $"Store name: {store.Name}{Environment.NewLine}";
            //info += $"Store type: {store.Type}{Environment.NewLine}";
            //return info;
        }
          
        public string Shutdown()
        {
            Environment.Exit(0);
            var sortedStores = stores.OrderByDescending(s => s.Turnover).ThenBy(s => s.Name);
            var output = new StringBuilder();
            foreach (var store in sortedStores)
            {
                output.AppendLine($"{store.Name}: {store.Turnover}");
            }
            return output.ToString();
        }
    
    }

}
