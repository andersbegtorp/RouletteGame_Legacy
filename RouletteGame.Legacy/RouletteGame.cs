using System.Collections.Generic;

namespace RouletteGame.Legacy
{
    public class RouletteGame
    {
        private readonly List<IBet> _bets;
        private readonly IRoulette _roulette;
        private IConsoleWriter _consoleWriter;
        
        private bool _roundIsOpen;

        public RouletteGame(IRoulette roulette, IConsoleWriter consoleWriter)
        {
            _bets = new List<IBet>();
            _consoleWriter = consoleWriter;
            _roulette = roulette;
        }

        public void OpenBets()
        {
            _consoleWriter.WriteString("Round is open for bets");
            _roundIsOpen = true;
        }

        public void CloseBets()
        {
            _consoleWriter.WriteString("Round is closed for bets");
            _roundIsOpen = false;
        }

        public void PlaceBet(Bet bet)
        {
            if (_roundIsOpen) _bets.Add(bet);
            else throw new RouletteGameException("Bet placed while round closed");
        }

        public void SpinRoulette()
        {
            _consoleWriter.WriteString("Spinning...");
            _roulette.Spin();

            string s = "Result: " + _roulette.GetResult();
            _consoleWriter.WriteString(s);
        }

        public void PayUp()
        {
            var result = _roulette.GetResult();

            foreach (var bet in _bets)
            {
                var won = bet.WonAmount(result);
                if (won > 0)
                {
                    string s = bet.PlayerName + " just won " + won + "$ on a " + bet;
                    _consoleWriter.WriteString(s);
                }
                 
            }
        }
    }
}