namespace NumberWizardBusinessLogic.Handlers.Scoring.ScoringSubSystems
{
    /// <summary>
    ///     Interface for the Score Keeper.
    /// </summary>
    internal interface IScoreKeeper
    {
        int ComputerScore { get; }
        int PlayerScore { get;  }

        void AddToComputerScore();
        void AddToPlayerScore();
    }
}
