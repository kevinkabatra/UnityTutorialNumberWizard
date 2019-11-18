namespace NumberWizardBusinessLogic.Handlers.Scoring
{
    using ScoringSubSystems;

    /// <summary>
    ///     Class to control the match, which is the total number of rounds
    /// within the game and the scoring system.
    /// </summary>
    /// <seealso href="https://refactoring.guru/design-patterns/facade"/>
    public class MatchFacade
    {
        public int ComputerScore => _scoreManager.ComputerScore;
        public int PlayerScore => _scoreManager.PlayerScore;
        
        public int Round => _roundManager.Round;
        public int MaximumRounds => _roundManager.MaximumRounds;

        private static RoundManager _roundManager;
        private static ScoreManager _scoreManager;

        private static MatchFacade _facade;
        private static readonly object ThreadSafeLock = new object();

        /// <summary>
        ///     Increases the Computer's score.
        /// </summary>
        public void AddToComputerScore()
        {
            _scoreManager.AddToComputerScore();
        }

        /// <summary>
        ///     Increases the Player's score.
        /// </summary>
        public void AddToPlayerScore()
        {
            _scoreManager.AddToPlayerScore();
        }

        /// <summary>
        ///     Returns a singleton instance of <c>MatchFacade</c>.
        /// </summary>
        /// <param name="maximumRounds">How many rounds the game will have.</param>
        /// <seealso href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/lock-statement"/>
        /// <returns>MatchFacade. Representing the facade of the match.</returns>
        public static MatchFacade GetMatchFacade(int maximumRounds)
        {
            if (_facade == null)
            {
                // lock will prevent multiple threads from attempting to create the singleton.
                lock (ThreadSafeLock)
                {
                    // should check conditional again, after lock is released the singleton would have been creates=d during a previous thread.
                    if (_facade == null)
                    {
                        _facade = new MatchFacade(maximumRounds);
                    }
                }
            }

            return _facade;
        }

        /// <summary>
        ///     Increases the number of the round.
        /// </summary>
        /// <returns>True. If move to next round was successful, else false.</returns>
        public bool NextRound()
        {
            var result = _roundManager.NextRound();
            return result;
        }

        /// <summary>
        ///     Resets the singleton, this is required for unit testing
        /// and for starting a new game.
        /// </summary>
        public static void Reset()
        {
            RoundManager.Reset();
            ScoreManager.Reset();
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="maximumRounds">How many rounds the game will have.</param>
        private MatchFacade(int maximumRounds)
        {
            _roundManager = RoundManager.GetRoundManager(maximumRounds);
            _scoreManager = ScoreManager.GetScoreManager();
        }
    }
}
