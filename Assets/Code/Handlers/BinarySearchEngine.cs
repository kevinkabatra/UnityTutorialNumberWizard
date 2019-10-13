namespace Assets.Code.Handlers
{
    using UnityEngine;

    public class BinarySearchEngine : INumberGuessingEngine
    {
        public int Guess => FindGuess();
        
        public int MaximumNumber { get; private set; }

        public int MinimumNumber { get; private set; }

        public BinarySearchEngine(int minimumNumber, int maximumNumber)
        {
            SetMaximumNumber(maximumNumber);
            SetMinimumNumber(minimumNumber);
        }
        
        public void SetMaximumNumber(int number)
        {
            MaximumNumber = number;
        }

        public void SetMinimumNumber(int number)
        {
            MinimumNumber = number;
        }

        /// <summary>
        ///     Finds the guess using Binary Search algorithm.
        /// </summary>
        /// <remarks>
        ///     Binary Search Algorithm : Given an array (A) of n elements and
        /// target value target (T). The position of the middle element (m) equals
        /// floor((minimumNumber + maximumNumber) / 2). 
        /// </remarks>
        /// <seealso href="https://en.wikipedia.org/wiki/Binary_search_algorithm#Procedure"/>
        /// <returns>Integer. Representing the result from a search using the Binary Search algorithm.</returns>
        private int FindGuess()
        {
            var result = (MinimumNumber + MaximumNumber) / 2;
            var guess = (int) Mathf.Floor(result);

            return guess;
        }
    }
}
