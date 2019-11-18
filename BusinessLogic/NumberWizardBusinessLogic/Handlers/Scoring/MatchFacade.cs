namespace NumberWizardBusinessLogic.Handlers.Scoring
{
    using ScoringSubSystems;

    /// <summary>
    ///     Class to control the match, which is the total number of rounds
    /// within the game and the scoring system.
    /// </summary>
    public class MatchFacade
    {
        public int ComputerScore => _scoreKeeper.ComputerScore;
        public int PlayerScore => _scoreKeeper.PlayerScore;
        
        public int Round => _roundKeeper.Round;
        public int MaximumRounds => _roundKeeper.MaximumRounds;

        private static IRoundKeeper _roundKeeper;
        private static IScoreKeeper _scoreKeeper;

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="maximumRounds">How many rounds the game will have.</param>
        public MatchFacade(int maximumRounds)
        {
            _roundKeeper = new RoundKeeper(maximumRounds);
            _scoreKeeper = new ScoreKeeper();
        }

        /// <summary>
        ///     Increases the Computer's score.
        /// </summary>
        public void AddToComputerScore()
        {
            _scoreKeeper.AddToComputerScore();
        }

        /// <summary>
        ///     Increases the Player's score.
        /// </summary>
        public void AddToPlayerScore()
        {
            _scoreKeeper.AddToPlayerScore();
        }

        /// <summary>
        ///     Increases the number of the round.
        /// </summary>
        /// <returns>True. If move to next round was successful, else false.</returns>
        public bool NextRound()
        {
            var result = _roundKeeper.NextRound();
            return result;
        }
    }
}
