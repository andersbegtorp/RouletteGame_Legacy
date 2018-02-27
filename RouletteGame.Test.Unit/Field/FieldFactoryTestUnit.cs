using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RouletteGame.Legacy;
using NSubstitute;
using NUnit.Framework;

namespace RouletteGame.Test.Unit
{
    [TestFixture]
    public class FieldFactoryTestUnit
    {

        private FieldFactory _uut;
        [SetUp]
        public void Setup()
        {
            _uut = new FieldFactory();
            
        }

        [TestCase("Canadian")]
        [TestCase("European")]
        public void CreateFields_NonExistentType_ExceptionsIsThrown(string type)
        {
            Assert.Throws<Exception>(() => _uut.CreateFields(type));
        }
        

    }
}
