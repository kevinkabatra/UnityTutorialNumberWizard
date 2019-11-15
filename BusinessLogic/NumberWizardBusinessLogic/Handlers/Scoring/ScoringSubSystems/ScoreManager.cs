namespace NumberWizardBusinessLogic.Handlers.Scoring.ScoringSubSystems
{
    /// <summary>
    ///     Class to control the score for the Player and the Computer.
    /// </summary>
    /// <remarks>Singleton class.</remarks>
    /// <seealso href="https://refactoring.guru/design-patterns/singleton"/>
    internal class ScoreManager
    {
        public int ComputerScore { get; private set; }
        public int PlayerScore { get; private set; }

        private static ScoreManager _manager;
        private static readonly object ThreadSafeLock = new object();

        /// <summary>
        ///     Increases the Computer's score.
        /// </summary>
        public void AddToComputerScore()
        {
            ComputerScore++;
        }

        /// <summary>
        ///     Increases the Player's score.
        /// </summary>
        public void AddToPlayerScore()
        {
            PlayerScore++;
        }

        /// <summary>
        ///     Returns a singleton instance of <c>ScoreManager</c>.
        /// </summary>
        /// <seealso href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/lock-statement"/>
        /// <returns>ScoreManager. Representing the manager of the score.</returns>
        public static ScoreManager GetScoreManager()
        {
            if (_manager == null)
            {
                // lock will prevent multiple threads from attempting to create the singleton.
                lock (ThreadSafeLock)
                {
                    // should check conditional again, after lock is released the singleton would have been creates=d during a previous thread.
                    if (_manager == null)
                    {
                        _manager = new ScoreManager();
                    }
                }
            }

            return _manager;
        }

        /// <summary>
        ///     Resets the singleton, this is required for unit testing
        /// and for starting a new game.
        /// </summary>
        public static void Reset()
        {
            lock (ThreadSafeLock)
            {
                _manager = null;
            }
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        private ScoreManager()
        {
            PlayerScore = 0;
            ComputerScore = 0;
        }
    }
}
