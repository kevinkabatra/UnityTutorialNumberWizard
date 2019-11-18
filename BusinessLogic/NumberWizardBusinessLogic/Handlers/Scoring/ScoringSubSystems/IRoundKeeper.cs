namespace NumberWizardBusinessLogic.Handlers.Scoring.ScoringSubSystems
{
    /// <summary>
    ///     Interface for the Round Keeper.
    /// </summary>
    internal interface IRoundKeeper
    {
        int Round { get; }
        int MaximumRounds { get; }

        bool NextRound();
    }
}
