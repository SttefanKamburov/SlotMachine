using SlotMachine.Common.Enums;
using SlotMachine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine.Common.Interfaces
{
    public interface ISlotGameService
    {
        SlotGameConfiguration ConfigureSlotGame(short numberOfRows, short symbolsPerRow);

        SlotGameResultDto PlaySlotGame(SlotGameConfiguration configuration);

        void DisplaySlotGameTableResults(SlotGameResultDto slotGameResult, IInputService inputService);

        (bool, decimal) GetIsCustomerWinning(SlotGameResultDto slotGameResult);

        SlotGameSymbolsEnum GenerateRandomSymbol();

        decimal CalculateWinnings(decimal stake, decimal coefficient);
    }
}
