using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store_system
{
    public abstract class Product
    {
        private string name;
        private int quantity;
        private double deliverPrice;
        private double percentageMarkup;
        private double finalPrice;

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Product name must not be null or empty!");
                name = value;
            }
        }
        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Quantity cannot be less or equal to 0!");
                quantity = value;
            }
        }
        public double DeliverPrice
        {
            get { return deliverPrice; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Deliver price cannot be less or equal to 0!");
                deliverPrice = value;

            }
        }
        public double PercentageMarkup
        {
            get { return percentageMarkup; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Percentage markup cannot be less or equal to 0!");
                percentageMarkup = value;

            }
        }
        public double FinalPrice
        {
            get { return deliverPrice + (deliverPrice * percentageMarkup / 100); }
        }

        public Product(string name, int quantity, double deliverPirce, double percentageMarkup)
        {
            this.name = name;
            this.quantity = quantity;
            this.DeliverPrice = deliverPrice;
            this.percentageMarkup = percentageMarkup;

        }
        public override string ToString()
        {
            return $"Product: {name} <{quantity}>\nDeliver Price: {deliverPrice}\nPercentage Markup: {percentageMarkup}\nFinal Price: {FinalPrice}";
        }
    }
}
