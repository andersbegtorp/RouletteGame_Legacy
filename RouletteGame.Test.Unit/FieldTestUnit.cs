using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RouletteGame.Legacy;

namespace RouletteGame.Test.Unit
{
    [TestFixture]
    public class FieldTestUnit
    {
        private Field _uut;

        [TestCase((uint)37, (uint)0)]
        [TestCase((uint)37, (uint)1)]
        [TestCase((uint)37, (uint)2)]
        [TestCase((uint)38, (uint)0)]
        [TestCase((uint)47, (uint)1)]
        [TestCase((uint)87, (uint)2)]

        public void FieldConstructor_NonExistentFieldNumber_ExceptionIsThrown(uint number, uint color)
        {
            Assert.Throws<FieldException>(() => _uut = new Field(number, color));
        }

        [TestCase((uint) 0, (uint) 3)]
        [TestCase((uint) 36, (uint) 4)]
        [TestCase((uint) 23, (uint) 99)]
        public void FieldConstructor_NonExistentFieldColor_ExceptionIsThrown(uint number, uint color)
        {
            Assert.Throws<FieldException>(() => _uut = new Field(number, color));
        }
    }
}
