using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace store_system
{
    public class Food : Product
    {
        public virtual double percentageMarkup
        {
            get { return base.PercentageMarkup; }
            set
            {
                if (value > 100)
                {
                    throw new ArgumentException("Food percentage cannot be more than 100%!");
                }
                base.PercentageMarkup = value;
            }
        }
        public Food(string name, int quantity, double deliverPrice, double percentageMarkup) : base(name, quantity, deliverPrice, percentageMarkup)
        {

        }
        
    }
}
