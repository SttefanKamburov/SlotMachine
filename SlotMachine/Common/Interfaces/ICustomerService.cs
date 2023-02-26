using SlotMachine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine.Common.Interfaces
{
    public interface ICustomerService
    {
        decimal GetBalanceFromInput(IInputService inputService);

        decimal GetStakeFromInput(decimal currentBalance, IInputService inputService);

        Customer AddBalance(Customer customer, decimal amount);

        Customer SubtractBalance(Customer customer, decimal amount);

        ValidationResultDto ValidateStake(decimal currentBalance, decimal stake);

        ValidationResultDto ValidateBalance(decimal balance);
    }
}
