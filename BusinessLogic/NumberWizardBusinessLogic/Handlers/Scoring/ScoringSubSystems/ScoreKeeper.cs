namespace NumberWizardBusinessLogic.Handlers.Scoring.ScoringSubSystems
{
    /// <summary>
    ///     Class to control the score for the Player and the Computer.
    /// </summary>
    internal class ScoreKeeper : IScoreKeeper
    {
        public int ComputerScore { get; private set; }
        public int PlayerScore { get; private set; }

        /// <summary>
        ///     Constructor.
        /// </summary>
        public ScoreKeeper()
        {
            PlayerScore = 0;
            ComputerScore = 0;
        }

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
    }
}
