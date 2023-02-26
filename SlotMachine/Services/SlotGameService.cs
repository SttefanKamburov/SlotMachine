using SlotMachine.Common.Enums;
using SlotMachine.Common.Interfaces;
using SlotMachine.ExtentionMethods;
using SlotMachine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine.Services
{
    public class SlotGameService : ISlotGameService
    {
        public SlotGameConfiguration ConfigureSlotGame(short numberOfRows, short symbolsPerRow)
        {
            return new SlotGameConfiguration
            {
                NumberOfRows = numberOfRows,
                SymbolsPerRow = symbolsPerRow,
            };
        }

        public SlotGameResultDto PlaySlotGame(SlotGameConfiguration configuration)
        {
            SlotGameResultDto result = new SlotGameResultDto();

            for (short i = 0; i < configuration.NumberOfRows; i++)
            {
                result.Results.Add(i, new List<SlotGameSymbolsEnum>());

                for (short j = 0; j < configuration.SymbolsPerRow; j++)
                {
                    result.Results[i].Add(GenerateRandomSymbol());
                }
            }

            (bool, decimal) isCustomerWinning = GetIsCustomerWinning(result);

            result.IsCustomerWinning = isCustomerWinning.Item1;
            result.WinningCoefficient = isCustomerWinning.Item2;

            return result;
        }

        public void DisplaySlotGameTableResults(SlotGameResultDto slotGameResult, IInputService inputService)
        {
            inputService.WriteLine(null);

            foreach (var row in slotGameResult.Results)
            {
                string rowResult = "";

                row.Value.ForEach(x =>
                {
                    rowResult = string.IsNullOrWhiteSpace(rowResult) ? x.GetSymbolAsString() : $"{rowResult} {x.GetSymbolAsString()}";
                });

                inputService.WriteLine(rowResult);
            }

            inputService.WriteLine(null);
        }

        public (bool, decimal) GetIsCustomerWinning(SlotGameResultDto slotGameResult)
        {
            bool isCustomerWinning = false;
            decimal winningCoefficient = 0.00m;
            foreach (var row in slotGameResult.Results)
            {
                var distinctValues = row.Value.Distinct();

                if (distinctValues.Count() == 1 || distinctValues.Count() == 2 && distinctValues.Any(x => x == SlotGameSymbolsEnum.Wild))
                {
                    isCustomerWinning = true;
                    row.Value.ForEach(x =>
                    {
                        winningCoefficient += x.GetMatchingCoefficient();
                    });
                }
            }

            return (isCustomerWinning, winningCoefficient);
        }

        public SlotGameSymbolsEnum GenerateRandomSymbol()
        {
            Random rand = new Random();
            int number = rand.Next(1, 101);

            if (number > 0 && number <= 45)
                return SlotGameSymbolsEnum.A;
            else if (number > 45 && number <= 80)
                return SlotGameSymbolsEnum.B;
            else if (number > 80 && number <= 95)
                return SlotGameSymbolsEnum.P;
            else if (number > 95 && number <= 100)
                return SlotGameSymbolsEnum.Wild;
            else
                throw new ArgumentException("Invalid number");
        }

        public decimal CalculateWinnings(decimal stake, decimal coefficient)
        {
            return (stake * coefficient).RoundByDefaultMethod();
        }
    }
}
