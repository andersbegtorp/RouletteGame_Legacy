﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RouletteGame.Legacy;
using NSubstitute;

namespace RouletteGame.Test.Unit
{
    [TestFixture]

    public class ColorBetTestUnit
    {
        private ColorBet _uut;

        [SetUp]
        public void SetUp()
        {
        }

        [TestCase("Anders",(uint)500,(uint)1,(uint)1000)]
        [TestCase("Anders", (uint)5000, (uint)1, (uint)10000)]
        [TestCase("Anders", (uint)50000, (uint)1, (uint)100000)]

        public void WonAmount_ColorChosen_CorrectAmount(string name, uint amount, uint color, uint expectedReturn)
        {
            _uut = new ColorBet(name, amount,color);
            Assert.That(_uut.WonAmount(new Field(2,color)),Is.EqualTo(expectedReturn));
        }

        [TestCase("Anders", (uint)500, (uint)0, "red")]
        [TestCase("Anders", (uint)500, (uint)1, "black")]
        [TestCase("Anders", (uint)500, (uint)2, "green")]
        public void ToString_ReturnColor_ColorIsCorrect(string name, uint amount, uint color, string expectedReturn)
        {
            _uut = new ColorBet(name, amount, color);
            Assert.That(_uut.ToString(),Is.EqualTo(amount+ "$ color bet on " + expectedReturn));
        }
    }
}

