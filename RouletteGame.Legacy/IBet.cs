namespace RouletteGame.Legacy
{
    public interface IBet
    {
        string PlayerName { get; }

        uint Amount { get; }

        uint WonAmount(Field field);
    }
}