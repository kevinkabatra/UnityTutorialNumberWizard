// ReSharper disable UnusedMember.Global, Start and Update are called by the Unity Engine, attached to Scene.Main.
namespace Assets.Code
{
    using Handlers.Display;
    using Handlers.Input;
    using NumberWizardBusinessLogic.Handlers.Guessing;
    using NumberWizardBusinessLogic.Handlers.Scoring;
    using NumberWizardBusinessLogic.Handlers.SearchEngines;
    using States;
    using UnityEngine;
    using Buttons;

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
        private int _minimumNumber = 0;
        private int _guess;

        private BinarySearchEngine _searchEngine;

        private DisplayHandler _displayHandler;
        private GuessHandler _guessHandler;
        private InputHandler _inputHandler;
        private InputListener _inputListener;

        private MatchFacade _match;

        private NumberPicker _computerChosenNumber;
        
        private GameState _gameState; // ToDo: possibly introduce a proper state machine to this project

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
        }

        /// <summary>
        ///     Update is called once per frame. 
        /// </summary>
        /// <remarks>
        ///     Unity Engine method.
        /// </remarks>
        public void Update()
        {
            //ToDo: Both guesses will be considered at the same time, so both the computer and the player could score on each turn.
            //ToDo: The computer and the player will tell one another if the guess was correct, too high, or too low.
            //ToDo: After the guesses are displayed the round should be updated
            //ToDo: Add conditional logic: if there are no more rounds then the "match" will have finished.
            //ToDo: Implement best out of three system. Could either use a state machine for this, or another class like RoundManager. Might make more sense given the design to have a MatchManager instead.

            _gameState = _inputHandler.HandleKeyboardInput(_gameState);
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

        /// <summary>
        ///     Initializes all of the components.
        /// </summary>
        private void Initialize()
        {
            _searchEngine = new BinarySearchEngine(_minimumNumber, _maximumNumber);
            _match = new MatchFacade(MaximumRounds);
            _gameState = GameState.Start;

            _displayHandler = new DisplayHandler();
            _computerChosenNumber = new NumberPicker(_displayHandler, _maximumNumber, _minimumNumber);

            // Need to set on click events prior to hiding the user interface
            var attemptGuess = new AttemptGuess(_displayHandler, _computerChosenNumber);
            attemptGuess.SetOnClickForAttemptGuess();

            _displayHandler.HideUserInterface();

            _guessHandler = new GuessHandler(_searchEngine, _displayHandler);
            _inputListener = new InputListener();
            _inputHandler = new InputHandler(_displayHandler, _inputListener);
        }
    }
}
