namespace NumberWizardBusinessLogic.Handlers.SearchEngines
{
    using System;

    /// <summary>
    ///     Determines which number to guess using the Binary Search algorithm.
    /// </summary>
    /// <remarks>
    ///     Binary Search Algorithm : Given an array (A) of n elements and
    /// target value target (T). The position of the middle element (m) equals
    /// floor((minimumNumber + maximumNumber) / 2). 
    /// </remarks>
    /// <seealso href="https://en.wikipedia.org/wiki/Binary_search_algorithm#Procedure"/>
    public class BinarySearchEngine : SearchEngine
    {
        /// <inheritdoc cref="SearchEngine"/>
        public BinarySearchEngine(int minimumNumber, int maximumNumber) : base(minimumNumber, maximumNumber)
        {
        }

        /// <summary>
        ///     Finds the guess using Binary Search algorithm.
        /// </summary>
        /// <returns>Integer. Representing the result from a search using the Binary Search algorithm.</returns>
        public override int FindGuess()
        {
            var result = (MinimumNumber + MaximumNumber) / 2;
            var guess = (int) Math.Floor((decimal) result);

            return guess;
        }
    }
}
