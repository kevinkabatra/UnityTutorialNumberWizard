// ReSharper disable UnusedMember.Global, Start and Update are called by the Unity Engine, attached to Scene.Main.
namespace Assets.Code
{
    using System;
    using System.Collections.Generic;
    using Handlers.Display;
    using Handlers.Input;
    using NumberWizardBusinessLogic.Handlers.Guessing;
    using NumberWizardBusinessLogic.Handlers.Scoring;
    using NumberWizardBusinessLogic.Handlers.SearchEngines;
    using States;
    using UnityEngine;

    /// <summary>
    ///     Entry point to the application.
    /// </summary>
    /// <remarks>
    ///     This class follows the Mediator design pattern. All
    /// communication between the various components originates
    /// within this class.
    /// </remarks>
    /// <seealso href="https://refactoring.guru/design-patterns/mediator"/>
    public class Main : MonoBehaviour
    {
        private const int MaximumRounds = 10;
        private int _maximumNumber = 1000;
        private int _minimumNumber;
        private int _guess;

        private BinarySearchEngine _searchEngine;

        private DisplayHandler _displayHandler;
        private GuessHandler _guessHandler;
        private InputHandler _inputHandler;

        private MatchFacade _match;

        private NumberPicker _computerChosenNumber;
        
        private GameState _gameState; // ToDo: possibly introduce a proper state machine to this project

        private const int _mockUserChosenNumber = 37; //ToDo: remove once user can enter input
        private List<int> _numbersThatHaveBeenGuessed = new List<int>(); //ToDo: remove this once user can actually guess

        private readonly System.Random randomGenerator = new System.Random();

        /// <summary>
        ///     Start is called before the first frame update.
        /// </summary>
        /// <remarks>
        ///     Unity Engine method.
        /// </remarks>
        public void Start()
        {
            Initialize();
            DisplayStartMessage();
            //SimulateGuessing();
        }

        /// <summary>
        ///     Update is called once per frame. 
        /// </summary>
        /// <remarks>
        ///     Unity Engine method.
        /// </remarks>
        public void Update()
        {
            //ToDo: Add UI text field: user input will need to come from a text field in the user interface
            //ToDo: MVP hard code user's guess: The user's guess can be hard coded to get the game logic working, then the UI can be layered on top of that.
            //ToDo: Add additional state: While we are waiting for the user's guess to come in the state should change to `WaitingForUserGuess`, this will disable the other inputs from being listened for
            //ToDo: Update State Machine: Once the user enters their guess the state will switch to the current GameState:Guess.
            //ToDo: Both guesses will be considered at the same time, so both the computer and the player could score on each turn.
            //ToDo: The computer and the player will tell one another if the guess was correct, too high, or too low.
            //ToDo: After the guesses are displayed the round should be updated
            //ToDo: Add conditional logic: if there are no more rounds then the "match" will have finished.
            //ToDo: Implement best out of three system. Could either use a state machine for this, or another class like RoundManager. Might make more sense given the design to have a MatchManager instead.

            HandleUserInput();
        }

        private void SimulateGuessing()
        {
            var shouldStop = false;
            var guessIteration = 1;
            while (!shouldStop)
            {
                _displayHandler.DisplayMessage($"Guess Iteration: {guessIteration}");
                guessIteration++;

                if (guessIteration == 11)
                {
                    shouldStop = true;
                }

                // Simulate user entering their guess
                var nextMockUserGuess = MockUserInput();
                _displayHandler.DisplayMessage("User guess is: " + nextMockUserGuess);

                var userGuessResult = _computerChosenNumber.GuessNumber(nextMockUserGuess);
                if (userGuessResult)
                {
                    _match.AddToPlayerScore();
                    shouldStop = true;
                }

                _numbersThatHaveBeenGuessed.Add(nextMockUserGuess);

                // Simulate computer guessing and the user replying
                _guess = _guessHandler.HandleGuess(_minimumNumber, _maximumNumber);
                _displayHandler.DisplayMessage("Computer guess is: " + _guess);
                if (_guess == _mockUserChosenNumber)
                {
                    _displayHandler.DisplayMessage("Computer guessed correctly.");
                    _match.AddToComputerScore();
                    shouldStop = true;
                }
                else
                {
                    if (_guess < _mockUserChosenNumber)
                    {
                        _displayHandler.DisplayMessage("Computer's guess was too low.");
                        _minimumNumber = _guess + 1; // Up arrow simulation

                    }
                    else
                    {
                        _displayHandler.DisplayMessage("Computer's guess was too high.");
                        _maximumNumber = _guess - 1; // Down arrow simulation
                    }
                }

                // Once all guessing is complete, move to the next round
                //var canMoveToNextRound = _match.NextRound();
                //_displayHandler.DisplayMessage(canMoveToNextRound.ToString());
                //if (!canMoveToNextRound)
                //{
                //    Application.Quit();
                //}
            }
        }

        /// <summary>
        ///     Displays the start message to the user.
        /// </summary>
        private void DisplayStartMessage()
        {
            _displayHandler.DisplayStartMessage(_minimumNumber, _maximumNumber, MaximumRounds);
        }

        /// <summary>
        ///     Uses the Guess Handler to attempt the next guess.
        /// </summary>
        private void AttemptGuess()
        {
            _gameState = GameState.Guess;
            _guess = _guessHandler.HandleGuess(_minimumNumber, _maximumNumber);
        }



        //ToDo: call this from the start method to get a guess for the user, then ask the computer if this is their number
        private int MockUserInput()
        {
            var maximumNumber = 1000;
            var minimumNumber = 0;

            var numberToGuess = GetRandomNumber(maximumNumber, minimumNumber);
            while (_numbersThatHaveBeenGuessed.Contains(numberToGuess))
            {
                numberToGuess = GetRandomNumber(minimumNumber, minimumNumber);
            }
            
            return numberToGuess;
        }

        //ToDo: remove this once the user can enter their own guess
        private int GetRandomNumber(int maximumNumber, int minimumNumber = 0)
        {
            var randomNumber = randomGenerator.Next(minimumNumber, maximumNumber);

            return randomNumber;
        }

        /// <summary>
        ///     Handler for all keyboard input, actions taken depend on the Game State.
        /// </summary>
        private void HandleUserInput()
        {
            var input = _inputHandler.Listen();

            // ReSharper disable once SwitchStatementMissingSomeCases, most inputs are not supported.
            switch (input)
            {
                case KeyCode.Space:
                    if (_gameState == GameState.Start)
                    {
                        _displayHandler.ShowUserInterface();
                        _gameState = GameState.Guess;
                        //AttemptGuess();
                    }
                    break;
                    
                case KeyCode.None:
                    break;

                case KeyCode.N:
                    if (_gameState == GameState.Guess)
                    {
                        _gameState = GameState.IterateGuess;
                        _guessHandler.DisplayGuessIterationInstructions();
                    }
                    break;

                case KeyCode.Y:
                    if (_gameState == GameState.Guess)
                    {
                        const string endGameMessage = "Thank you for playing! - Kevin Kabatra";
                        _displayHandler.DisplayMessage(endGameMessage);

                        _gameState = GameState.GameOver;
                    }
                    break;

                case KeyCode.DownArrow:
                    if (_gameState == GameState.IterateGuess)
                    {
                        _maximumNumber = _guess - 1;
                        AttemptGuess();
                    }
                    break;

                case KeyCode.UpArrow:
                    if (_gameState == GameState.IterateGuess)
                    {
                        _minimumNumber = _guess + 1;
                        AttemptGuess();
                    }
                    break;

                default:
                    var errorMessage = $"KeyCode: {input} is not supported.";
                    throw new NotSupportedException(errorMessage);
            }
        }

        /// <summary>
        ///     Initializes all of the components.
        /// </summary>
        private void Initialize()
        {
            _displayHandler = new DisplayHandler();
            _displayHandler.HideUserInterface();

            _searchEngine = new BinarySearchEngine(_minimumNumber, _maximumNumber);

            _guessHandler = new GuessHandler(_searchEngine, _displayHandler);
            _inputHandler = new InputHandler();

            _match = new MatchFacade(MaximumRounds);

            _gameState = GameState.Start;

            _computerChosenNumber = new NumberPicker(_displayHandler, _maximumNumber, _minimumNumber);

            //ToDo: possibly remove once the user can enter a guess
            //Skip the first number, the computer is using this for their guess.
            randomGenerator.Next(_minimumNumber, _maximumNumber);
        }
    }
}
