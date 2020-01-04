namespace NumberWizardBusinessLogic.Handlers.Scoring.ScoringSubSystems
{
    using System;

    /// <summary>
    ///     Class to control the rounds of the game.
    /// </summary>
    internal class RoundKeeper : IRoundKeeper
    {
        public int Round { get; private set; }
        public int MaximumRounds { get; }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="maximumRounds">How many rounds the game will have.</param>
        public RoundKeeper(int maximumRounds)
        {
            if (maximumRounds == 0)
            {
                //ToDo: remove hard coded label
                const string errorMessage = "MaximumRounds must be supplied, and cannot be 0, when creating a RoundManager for the first time.";
                throw new ArgumentException(errorMessage);
            }

            Round = 0;
            MaximumRounds = maximumRounds;
        }

        /// <summary>
        ///     Increases the number of the round.
        /// </summary>
        /// <returns>True. If move to next round was successful, else false.</returns>
        public bool NextRound()
        {
            if (Round == MaximumRounds)
            {
                return false;
            }

            Round++;
            return true;
        }
    }
}
