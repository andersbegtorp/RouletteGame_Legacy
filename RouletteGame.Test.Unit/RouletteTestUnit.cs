using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NSubstitute.Core.Arguments;
using NSubstitute.Extensions;
using NUnit.Framework;
using RouletteGame.Legacy;

namespace RouletteGame.Test.Unit
{
    [TestFixture]
    public class RouletteTestUnit
    {
        private Roulette _uut;
        private IRouletteNumberGenerator _fakeNumberGen;
        private IFieldFactory _fakeFieldFactory;

        [SetUp]
        public void SetUp()
        {
            _fakeFieldFactory = Substitute.For<IFieldFactory>();
            _fakeNumberGen = Substitute.For<IRouletteNumberGenerator>();
        }

        [TestCase(1)]
        [TestCase(4)]
        [TestCase(6)]
        [TestCase(8)]
        [TestCase(12)]
        [TestCase(24)]
        [TestCase(30)]
        [TestCase(35)]
        [TestCase(36)]

        public void Spin_ReturnResult_ResultIsCorrect(int number)
        {
            Field fieldToBeReturned = new Field(1, 2);
            List<Field> fields = new List<Field>
            {
                new Field(0, Field.Green),
                new Field(1, Field.Red),
                new Field(2, Field.Black),
                new Field(3, Field.Red),
                new Field(4, Field.Black),
                new Field(5, Field.Red),
                new Field(6, Field.Black),
                new Field(7, Field.Red),
                new Field(8, Field.Black),
                new Field(9, Field.Red),
                new Field(10, Field.Black),
                new Field(11, Field.Black),
                new Field(12, Field.Red),
                new Field(13, Field.Black),
                new Field(14, Field.Red),
                new Field(15, Field.Black),
                new Field(16, Field.Red),
                new Field(17, Field.Black),
                new Field(18, Field.Red),
                new Field(19, Field.Red),
                new Field(20, Field.Black),
                new Field(21, Field.Red),
                new Field(22, Field.Black),
                new Field(23, Field.Red),
                new Field(24, Field.Black),
                new Field(25, Field.Red),
                new Field(26, Field.Black),
                new Field(27, Field.Red),
                new Field(28, Field.Black),
                new Field(29, Field.Black),
                new Field(30, Field.Red),
                new Field(31, Field.Black),
                new Field(32, Field.Red),
                new Field(33, Field.Black),
                new Field(34, Field.Red),
                new Field(35, Field.Black),
                new Field(36, Field.Red)
            };


            _fakeFieldFactory.CreateFields(Arg.Any<string>()).Returns(fields);
             _uut = new Roulette(_fakeNumberGen, _fakeFieldFactory);
            _fakeNumberGen.GetNumber().Returns((uint)number);
            _uut.Spin();

            Assert.That(_uut.GetResult(), Is.EqualTo(fields[number]));

        }




    }
}
