namespace NumberWizardBusinessLogic.Handlers.Guessing
{
    using System;

    /// <summary>
    ///     Class to control the rounds of the game.
    /// </summary>
    public class RoundManager
    {
        public int Round { get; private set; }
        public int MaxRounds { get; }

        private static RoundManager _manager;
        private static readonly object ThreadSafeLock = new object();

        /// <summary>
        ///     Increases the number of the round.
        /// </summary>
        /// <returns>True. If move to next round was successful, else false.</returns>
        public bool NextRound()
        {
            if (Round == MaxRounds)
            {
                return false;
            }

            Round++;
            return true;
        }

        /// <summary>
        ///     Returns a singleton instance of <c>RoundManager</c>.
        /// </summary>
        /// <param name="maxRounds">How many rounds the game will have.</param>
        /// <seealso href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/lock-statement"/>
        /// <returns>ScoreManager. Representing the manager of the round.</returns>
        public static RoundManager GetRoundManager(int maxRounds = 0)
        {
            if (_manager == null)
            {
                // lock will prevent multiple threads from attempting to create the singleton.
                lock (ThreadSafeLock)
                {
                    // should check conditional again, after lock is released the singleton would have been creates=d during a previous thread.
                    if (_manager == null)
                    {
                        if (maxRounds == 0)
                        {
                            //ToDo: remove hard coded label
                            throw new ArgumentException("MaxRounds must be supplied, and cannot be 0, when creating a RoundManager for the first time.");
                        }
                        
                        _manager = new RoundManager(maxRounds);
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
        /// <param name="maxRounds">How many rounds the game will have.</param>
        private RoundManager(int maxRounds)
        {
            Round = 0;
            MaxRounds = maxRounds;
        }
    }
}
