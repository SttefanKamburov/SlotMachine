using SlotMachine.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine.ExtentionMethods
{
    public static class SlotGameSymbolsExtentionMethods
    {
        private static Dictionary<SlotGameSymbolsEnum, decimal> Coeficients = new Dictionary<SlotGameSymbolsEnum, decimal>
        {
            { SlotGameSymbolsEnum.A, 0.4m },
            { SlotGameSymbolsEnum.B, 0.6m },
            { SlotGameSymbolsEnum.P, 0.8m },
            { SlotGameSymbolsEnum.Wild, 0.0m }
        };

        public static string GetSymbolAsString(this SlotGameSymbolsEnum symbol)
        {
            switch (symbol)
            {
                case SlotGameSymbolsEnum.A: return "A";
                case SlotGameSymbolsEnum.P: return "P";
                case SlotGameSymbolsEnum.B: return "B";
                case SlotGameSymbolsEnum.Wild: return "*";
                default: throw new ArgumentException("Invalid symbol .");
            }
        }

        public static decimal GetMatchingCoefficient(this SlotGameSymbolsEnum symbol)
        {
            decimal? coefficient = Coeficients[symbol];

            if (coefficient == null)
                throw new ArgumentException("Invalid symbol .");

            return coefficient.Value;
        }
    }
}
