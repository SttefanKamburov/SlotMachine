using SlotMachine.Utils;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine.UnitTests
{
    public class CustomerUtilsUnitTests
    {
        [Test]
        public void GetBalanceFromConsole()
        {
            var result = CustomerUtils.GetBalanceFromConsole();
            result.ShouldBeGreaterThan(0);
        }
    }
}
