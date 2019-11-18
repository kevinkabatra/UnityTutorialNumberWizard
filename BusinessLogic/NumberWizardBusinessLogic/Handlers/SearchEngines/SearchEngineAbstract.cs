namespace NumberWizardBusinessLogic.Handlers.SearchEngines
{
    /// <summary>
    ///     Abstract class that handles most of a SearchEngine's implementation.
    /// </summary>
    public abstract class SearchEngineAbstract : ISearchEngine
    {
        public int Guess => FindGuess();
        public int MaximumNumber { get; private set; }
        public int MinimumNumber { get; private set; }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="minimumNumber">The minimum number to search for.</param>
        /// <param name="maximumNumber">The maximum number to search for.</param>
        protected SearchEngineAbstract(int minimumNumber, int maximumNumber)
        {
            SetMaximumNumber(maximumNumber);
            SetMinimumNumber(minimumNumber);
        }

        /// <summary>
        ///     Sets maximum number to search for.
        /// </summary>
        /// <param name="number">The maximum number to search for.</param>
        public void SetMaximumNumber(int number)
        {
            MaximumNumber = number;
        }

        /// <summary>
        ///     Sets minimum number to search for.
        /// </summary>
        /// <param name="number">The minimum number to search for.</param>
        public void SetMinimumNumber(int number)
        {
            MinimumNumber = number;
        }

        /// <summary>
        ///     Find the guess using the implemented algorithm.
        /// </summary>
        /// <returns>Integer. Representing the result of the search.</returns>
        public abstract int FindGuess();
    }
}
