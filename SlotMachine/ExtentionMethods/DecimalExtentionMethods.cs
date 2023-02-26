using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine.ExtentionMethods
{
    public static class DecimalExtentionMethods
    {
        public static decimal RoundByDefaultMethod(this decimal amount)
        {
            return Math.Round(amount, 2);
        }
    }
}
