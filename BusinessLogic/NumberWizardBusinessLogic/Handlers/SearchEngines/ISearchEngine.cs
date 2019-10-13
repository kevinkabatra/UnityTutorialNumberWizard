namespace NumberWizardBusinessLogic.Handlers.SearchEngines
{
    /// <summary>
    ///     Interface for the search engines.
    /// </summary>
    public interface ISearchEngine
    {
        int Guess { get; }
        int MaximumNumber { get; }
        int MinimumNumber { get; }

        void SetMaximumNumber(int number);

        void SetMinimumNumber(int number);
    }
}
