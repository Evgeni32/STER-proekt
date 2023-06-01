using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store_system
{
    internal class Drink : Product
    {
        public Drink(string name, int quantity, double deliverPrice , double percentageMarkup) : base(name , deliverPrice, percentageMarkup)
        {
            if (percentageMarkup > 200)
            {
                throw new ArgumentException("Drink percentage cannot be more than 200%!");
            }
        }
    }
}
