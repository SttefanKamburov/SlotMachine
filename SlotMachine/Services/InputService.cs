using SlotMachine.Common.Interfaces;

namespace SlotMachine.Services
{
    public class InputService : IInputService
    {
        /// <summary>
        /// Get decimal from console and if it fails show error message
        /// </summary>
        /// <param name="errorMessage">Error message to be shown in case of failure</param>
        /// <returns>decimal.</returns>
        public decimal GetDecimal(string errorMessage)
        {
            bool isValidDecimal = false;
            decimal result = 0.00m;

            while (!isValidDecimal)
            {
                isValidDecimal = decimal.TryParse(Console.ReadLine(), out result);

                if (!isValidDecimal)
                    Console.WriteLine(errorMessage);
            }

            return result;
        }
        public void WriteLine(string? line)
        {
            Console.WriteLine(line);
        }
        public string ReadLine()
        {
            string? result = Console.ReadLine();

            while (result == null)
            {
                result = Console.ReadLine();
            }

            return result;
        }
    }
}
