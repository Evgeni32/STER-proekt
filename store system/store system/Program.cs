namespace store_system
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StoreController storeController = new StoreController();

            string input = Console.ReadLine();

            while (input != "Shutdown")
            {
                List<string> command = input.Split(':').ToList();

                string commandType = command[0];

                switch (commandType)
                {
                    case "CreateStore":
                        string name = command[1];
                        string type = command[2];
                        string result = storeController.CreateStore(new List<string> { name, type });
                        Console.WriteLine(result);
                        break;
                    case "ReceiveProduct":
                        string productType = command[1];
                        string productName = command[2];
                        int quantity = int.Parse(command[3]);
                        double price = double.Parse(command[4]);
                        double percentageMarkup = double.Parse(command[5]);
                        string storeName = command[6];
                        string receiveResult = storeController.ReceiveProduct(new List<string> { productType, productName, quantity.ToString(), price.ToString(), percentageMarkup.ToString(), storeName });
                        Console.WriteLine(receiveResult);
                        break;
                    case "SellProduct":
                        string sellProductName = command[1];
                        int sellQuantity = int.Parse(command[2]);
                        string sellStoreName = command[3];
                        string sellResult = storeController.SellProduct(new List<string> { sellProductName, sellQuantity.ToString(), sellStoreName });
                        Console.WriteLine(sellResult);
                        break;
                    case "StoreInfo":
                        string storeInfoName = command[1];
                        string storeInfoResult = storeController.StoreInfo(new List<string> { storeInfoName });
                        Console.WriteLine(storeInfoResult);
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }
}