using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using NUnit.Framework.Internal;
using RouletteGame.Legacy;

namespace RouletteGame.Test.Unit
{
    [TestFixture()]
    public class EvenOddBetTestUnit
    {
        private EvenOddBet _uut;

        [TestCase("Anders", (uint)500,(bool)true,(uint)1000)]
        [TestCase("Anders", (uint)5000, (bool)true, (uint)10000)]
        [TestCase("Anders", (uint)1, (bool)true, (uint)2)]
        public void WonAmount_EvenChosen_CorrectAmount(string name, uint amount, bool even, uint expectedReturn)
        {
            _uut = new EvenOddBet(name, amount, even);
            Assert.That(_uut.WonAmount(new Field(2,1)),Is.EqualTo(expectedReturn));
        }

        [TestCase("Anders", (uint)500, (bool)true, (uint)0)]
        [TestCase("Anders", (uint)5000, (bool)true, (uint)0)]
        [TestCase("Anders", (uint)1, (bool)true, (uint)0)]
        public void WonAmount_EvenChosenAndLost_CorrectAmount(string name, uint amount, bool even, uint expectedReturn)
        {
            _uut = new EvenOddBet(name, amount, even);
            Assert.That(_uut.WonAmount(new Field(1, 1)), Is.EqualTo(expectedReturn));
        }

        [TestCase("Anders", (uint)500, (bool)false, (uint)1000)]
        [TestCase("Anders", (uint)5000, (bool)false, (uint)10000)]
        [TestCase("Anders", (uint)1, (bool)false, (uint)2)]
        public void WonAmount_OddChosen_CorrectAmount(string name, uint amount, bool even, uint expectedReturn)
        {
            _uut = new EvenOddBet(name, amount, even);
            Assert.That(_uut.WonAmount(new Field(1, 1)), Is.EqualTo(expectedReturn));
        }

        [TestCase("Anders", (uint)500, (bool)false, (uint)0)]
        [TestCase("Anders", (uint)5000, (bool)false, (uint)0)]
        [TestCase("Anders", (uint)1, (bool)false, (uint)0)]
        public void WonAmount_OddChosenAndLost_CorrectAmount(string name, uint amount, bool even, uint expectedReturn)
        {
            _uut = new EvenOddBet(name, amount, even);
            Assert.That(_uut.WonAmount(new Field(2, 1)), Is.EqualTo(expectedReturn));
        }
        [TestCase("Anders", (uint)500, (bool)true, "even")]
        [TestCase("Anders", (uint)500, (bool)false, "odd")]

        public void ToString_ReturnEvenOrOdd_ReturnIsCorrect(string name, uint amount, bool even, string expectedReturn)
        {
            _uut = new EvenOddBet(name, amount, even);
            Assert.That(_uut.ToString(), Is.EqualTo(amount + "$ even/odd bet on " + expectedReturn));
        }
    }
}
