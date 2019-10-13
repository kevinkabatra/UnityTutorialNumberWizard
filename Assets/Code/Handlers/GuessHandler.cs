namespace Assets.Code.Handlers
{
    using UnityEngine;

    public class GuessHandler
    {
        private int _guess;
        private INumberGuessingEngine _searchEngine;

        public GuessHandler(INumberGuessingEngine searchEngine)
        {
            _searchEngine = searchEngine;
        }

        public int HandleGuess(int minimumNumber, int maximumNumber)
        {
            _searchEngine = new BinarySearchEngine(minimumNumber, maximumNumber);
            _guess = _searchEngine.Guess;

            var guessMessage = $"Is your number {_guess}? Press [Y]es or [N]o.";
            Debug.Log(guessMessage);

            return _guess;
        }

        public void DisplayGuessIterationInstructions()
        {
            var guessInstructions = "If your number is: higher, press Up arrow key, or if it is lower, press Down arrow key.";
            Debug.Log(guessInstructions);
        }
    }
}
