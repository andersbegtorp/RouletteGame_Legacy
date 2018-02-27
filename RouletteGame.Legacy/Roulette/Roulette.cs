using System.Collections.Generic;

namespace RouletteGame.Legacy
{
    public class Roulette : IRoulette
    {
        private readonly List<Field> _fields;
        private Field _result;
        private IRouletteNumberGenerator _rouletteNumberGenerator;
        private IFieldFactory _fieldFactory;

        public Roulette(IRouletteNumberGenerator rouletteNumberGenerator, IFieldFactory fieldFactory)
        {
            _rouletteNumberGenerator = rouletteNumberGenerator;
            _fieldFactory = fieldFactory;
            _fields = _fieldFactory.CreateFields("USA");
            _result = _fields[0];
        }

        public void Spin()
        {
            _result = _fields[(int) _rouletteNumberGenerator.GetNumber()];
        }

        public Field GetResult()
        {
            return _result;
        }
    }
}