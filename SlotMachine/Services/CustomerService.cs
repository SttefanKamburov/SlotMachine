using SlotMachine.Common.Interfaces;
using SlotMachine.ExtentionMethods;
using SlotMachine.Models;

namespace SlotMachine.Services
{
    public class CustomerService : ICustomerService
    {
        public decimal GetBalanceFromInput(IInputService inputService)
        {
            bool isBalanceValid = false;
            decimal balance = 0.00m;

            inputService.WriteLine("Please deposit money you would like to play with: ");

            while (!isBalanceValid)
            {
                balance = inputService.GetDecimal("Please enter valid amount .");

                ValidationResultDto validationResult = ValidateBalance(balance);

                if (!validationResult.IsValid)
                {
                    inputService.WriteLine(validationResult.ErrorMessage);
                    inputService.WriteLine("Please enter valid amount");
                }
                else
                    isBalanceValid = validationResult.IsValid;
            }

            return balance.RoundByDefaultMethod();
        }

        public decimal GetStakeFromInput(decimal currentBalance, IInputService inputService)
        {
            bool isStakeValid = false;
            decimal stake = 0.00m;

            inputService.WriteLine("Enter stake amount .");

            while (!isStakeValid)
            {
                stake = inputService.GetDecimal("Please enter valid amount .");

                ValidationResultDto validationResult = ValidateStake(currentBalance, stake);

                if (!validationResult.IsValid)
                {
                    inputService.WriteLine(validationResult.ErrorMessage);
                    inputService.WriteLine("Please enter valid amount");
                }
                else
                    isStakeValid = validationResult.IsValid;
            }

            return stake.RoundByDefaultMethod();
        }

        public Customer AddBalance(Customer customer, decimal amount)
        {
            if (amount < 0)
                throw new ArgumentException("amount to be added can't be less than 0 .");

            customer.Balance = (customer.Balance + amount).RoundByDefaultMethod();
            return customer;
        }

        public Customer SubtractBalance(Customer customer, decimal amount)
        {
            decimal newBalance = customer.Balance - amount;

            if (newBalance < 0)
                throw new ArgumentException("amount to be subtracted is greater than current balance .");

            customer.Balance = newBalance.RoundByDefaultMethod();

            return customer;
        }

        public ValidationResultDto ValidateStake(decimal currentBalance, decimal stake)
        {
            ValidationResultDto result = new ValidationResultDto { IsValid = true };

            if (stake <= 0)
            {
                result.IsValid = false;
                result.ErrorMessage = "Stake must be greater than 0 .";
            }

            if (stake > currentBalance)
            {
                result.IsValid = false;
                result.ErrorMessage = "Stake must be less than current balance .";
            }

            return result;
        }

        public ValidationResultDto ValidateBalance(decimal balance)
        {
            if (balance <= 0)
                return new ValidationResultDto
                {
                    IsValid = false,
                    ErrorMessage = "Balance must be greater than 0 ."
                };

            return new ValidationResultDto { IsValid = true };
        }
    }
}
