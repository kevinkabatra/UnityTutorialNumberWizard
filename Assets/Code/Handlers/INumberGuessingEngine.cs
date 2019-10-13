namespace Assets.Code.Handlers
{

    public interface INumberGuessingEngine
    {
        int Guess { get; }
        int MaximumNumber { get; }
        int MinimumNumber { get; }

        void SetMaximumNumber(int number);

        void SetMinimumNumber(int number);
    }
}
