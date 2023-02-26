using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine.Common.Interfaces
{
    public interface IInputService
    {
        decimal GetDecimal(string errorMessage);
        void WriteLine(string? line);
        string ReadLine();
    }
}
