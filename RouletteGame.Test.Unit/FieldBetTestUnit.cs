using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using RouletteGame.Legacy;

namespace RouletteGame.Test.Unit
{
    [TestFixture]
    public class FieldBetTestUnit
    {
        private FieldBet _uut;

        [TestCase("Anders", (uint)500, (uint)1, (uint)18000)]
        [TestCase("Anders", (uint)500, (uint)2, (uint)0)]
        public void WonAmount_FieldChosen_CorrectAmount(string name, uint amount, uint fieldNumber, uint expectedReturn)
        {
            _uut = new FieldBet(name, amount, fieldNumber);
            Assert.That(_uut.WonAmount(new Field(1, 2)), Is.EqualTo(expectedReturn));
        }

        [TestCase("Anders", (uint)500, (uint)3, (uint)3)]
        public void ToString_ReturnFieldNumber_ReturnIsCorrect(string name, uint amount, uint fieldNumber,
            uint expectedReturn)
        {
            _uut = new FieldBet(name, amount, fieldNumber);
            Assert.That(_uut.ToString(),Is.EqualTo(amount + "$ field bet on " + expectedReturn));
        }
    }
}
