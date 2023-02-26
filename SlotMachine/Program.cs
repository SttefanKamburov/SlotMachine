using SlotMachine.Models;
using SlotMachine.Services;

// Initialization of app services
var inputService = new InputService();
var customerService = new CustomerService();
var slotGameService = new SlotGameService();
//

//Game configuration
short numberOfSlotGameRows = 4, slotGameSymbolsPerRow = 3;
var slotGameConfiguration = slotGameService.ConfigureSlotGame(numberOfSlotGameRows, slotGameSymbolsPerRow);
//

var customer = new Customer();
customer.Balance = customerService.GetBalanceFromInput(inputService);
var isCustomerPlaying = true;
while (isCustomerPlaying)
{
    customer.Stake = customerService.GetStakeFromInput(customer.Balance, inputService);
    var slotGameResult = slotGameService.PlaySlotGame(slotGameConfiguration);
    slotGameService.DisplaySlotGameTableResults(slotGameResult, inputService);

    if (slotGameResult.IsCustomerWinning)
    {
        var winnings = slotGameService.CalculateWinnings(customer.Stake, slotGameResult.WinningCoefficient);
        customer = customerService.AddBalance(customer, winnings);

        inputService.WriteLine($"You have won: {winnings}");
        inputService.WriteLine($"Current balance is: {customer.Balance}");
    }
    else
    {
        customer = customerService.SubtractBalance(customer, customer.Stake);
        inputService.WriteLine($"You have lost: {customer.Stake}");
        inputService.WriteLine($"Current balance is: {customer.Balance}");

        if (customer.Balance == 0)
        {
            inputService.WriteLine("Your balance is empty");
            break;
        }
    }

    inputService.WriteLine("");
    inputService.WriteLine("Would you like to continue playing ?");
    inputService.WriteLine("Type No to stop");
    if(inputService.ReadLine().ToLower() == "no")
        isCustomerPlaying = false;
}

