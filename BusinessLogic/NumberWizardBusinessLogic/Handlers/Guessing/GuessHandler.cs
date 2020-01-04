namespace NumberWizardBusinessLogic.Handlers.Guessing
{
    using Display;
    using SearchEngines;

    /// <summary>
    ///     Handler for guessing the number.
    /// </summary>
    public class GuessHandler
    {
        private int _guess;
        private readonly IDisplayHandler _displayHandler;
        private ISearchEngine _searchEngine;

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="searchEngine">The search engine that will be used to determine the number.</param>
        /// <param name="displayHandler">The handler that will display messages to the user.</param>
        public GuessHandler(ISearchEngine searchEngine, IDisplayHandler displayHandler)
        {
            _searchEngine = searchEngine;
            _displayHandler = displayHandler;
        }

        /// <summary>
        ///     Generates the guess using the provided search engine.
        /// </summary>
        /// <param name="minimumNumber">The minimum number to search for.</param>
        /// <param name="maximumNumber">The maximum number to search for.</param>
        /// <returns>Integer. Representing the guess.</returns>
        public int HandleGuess(int minimumNumber, int maximumNumber)
        {
            ConstructSearchEngine(minimumNumber, maximumNumber);
            GetGuess();
            DisplayGuess();

            return _guess;
        }

        /// <summary>
        ///     Displays instructions to the user.
        /// </summary>
        public void DisplayGuessIterationInstructions()
        {
            var guessInstructions =
                "If your number is: higher, press Up arrow key, or if it is lower, press Down arrow key.";
            _displayHandler.AppendInstructions(guessInstructions);
            _displayHandler.DisplayInstructions();
        }

        /// <summary>
        ///     Constructs the search engine based on its type.
        /// </summary>
        /// <param name="minimumNumber">The minimum number to search for.</param>
        /// <param name="maximumNumber">The maximum number to search for.</param>
        private void ConstructSearchEngine(int minimumNumber, int maximumNumber)
        {
            if (_searchEngine.GetType() == typeof(BinarySearchEngine))
            {
                _searchEngine = new BinarySearchEngine(minimumNumber, maximumNumber);
            }
        }

        /// <summary>
        ///     Displays the guess to the user.
        /// </summary>
        private void DisplayGuess()
        {
            var guessMessage = $"Is your number {_guess}?";
            _displayHandler.DisplayComputerGuess(guessMessage);
        }

        /// <summary>
        ///     Handles getting the guess from the search engine.
        /// </summary>
        private void GetGuess()
        {
            _guess = _searchEngine.Guess;
        }
    }
}