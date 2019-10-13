namespace NumberWizardBusinessLogicUnitTests.Handlers.SearchEngines
{
    using NumberWizardBusinessLogic.Handlers.SearchEngines;
    using Xunit;

    /// <summary>
    ///     Exercises the Binary Search Engine.
    /// </summary>
    public class BinarySearchEngineTests
    {
        [Fact]
        public void CanCreateBinarySearchEngine()
        {
            const int minimumNumber = 0;
            const int maximumNumber = 1;

            var engine = new BinarySearchEngine(minimumNumber, maximumNumber);

            Assert.NotNull(engine);
        }

        [Fact]
        public void CanFindExpectedGuess()
        {
            const int minimumNumber = 0;
            const int maximumNumber = 1000;
            const int expectedGuess = 500;

            var engine = new BinarySearchEngine(minimumNumber, maximumNumber);
            var actualGuess = engine.Guess;

            Assert.Equal(expectedGuess, actualGuess);
        }
    }
}
