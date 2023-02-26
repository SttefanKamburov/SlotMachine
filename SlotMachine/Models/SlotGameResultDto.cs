using SlotMachine.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine.Models
{
    public class SlotGameResultDto
    {
        public bool IsCustomerWinning { get; set; }
        public decimal WinningCoefficient { get; set; }
        public Dictionary<short, List<SlotGameSymbolsEnum>> Results { get; set; } = new Dictionary<short, List<SlotGameSymbolsEnum>>();
    }
}
