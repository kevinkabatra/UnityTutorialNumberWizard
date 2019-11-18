namespace NumberWizardBusinessLogicUnitTests.Handlers.Scoring.ScoringSubSystems
{
    using NumberWizardBusinessLogic.Handlers.Scoring.ScoringSubSystems;
    using Xunit;

    /// <summary>
    ///     Exercises Score Manager.
    /// </summary>
    public class ScoreKeeperUnitTests
    {
        [Fact]
        public void CanMakeScoreManager()
        {
            var score = new ScoreKeeper();

            Assert.NotNull(score);
        }

        [Fact]
        public void CanMakeScoreManagerWithExpectedValues()
        {
            const int expectedScore = 0;

            var score = new ScoreKeeper();

            Assert.Equal(expectedScore, score.ComputerScore);
            Assert.Equal(expectedScore, score.PlayerScore);
        }

        [Fact]
        public void CanIncreaseComputerScore()
        {
            const int expectedScore = 1;

            var score = new ScoreKeeper();
            score.AddToComputerScore();
            
            Assert.Equal(expectedScore, score.ComputerScore);
        }

        [Fact]
        public void CanIncreasePlayerScore()
        {
            const int expectedScore = 1;

            var score = new ScoreKeeper();
            score.AddToPlayerScore();

            Assert.Equal(expectedScore, score.PlayerScore);
        }
    }
}
