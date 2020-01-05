namespace Assets.Code.Handlers.Display
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class UserInterfaceView : MonoBehaviour
    {
        [SerializeField] public Button AttemptGuess;
        [SerializeField] public Button ComputerGuessIsCorrect;
        [SerializeField] public Button ComputerGuessIsIncorrect;
        [SerializeField] public Button ComputerGuessShouldBeHigher;
        [SerializeField] public Button ComputerGuessShouldBeLower;

        [SerializeField] public InputField UserGuess;
        [SerializeField] public InputField ComputerGuess;

        [SerializeField] public Text Instructions;

        private List<GameObject> _computerGuessingUserInterfaceGameObjects;
        private List<GameObject> _computerGuessIsCorrectOrIncorrectGameObjects;
        private List<GameObject> _computerGuessShouldBeHigherOrLowerGameObjects;
        private List<GameObject> _userGuessingUserInterfaceGameObjects;

        public UserInterfaceView()
        {
            
        }

        public List<GameObject> GetComputerGuessingUserInterfaceGameObjects()
        {
            if (_computerGuessingUserInterfaceGameObjects == null)
            {
                _computerGuessingUserInterfaceGameObjects = new List<GameObject>()
                {
                    GameObject.Find("ComputerGuess"),
                    GameObject.Find("ComputerName"),
                };
            }

            return _computerGuessingUserInterfaceGameObjects;
        }

        public List<GameObject> GetUserGuessingUserInterfaceGameObjects()
        {
            if (_userGuessingUserInterfaceGameObjects == null)
            {
                _userGuessingUserInterfaceGameObjects = new List<GameObject>()
                {
                    GameObject.Find("AttemptGuess"),
                    GameObject.Find("UserGuess"),
                    GameObject.Find("UserName"),
                };
            }

            return _userGuessingUserInterfaceGameObjects;
        }

        public List<GameObject> GetComputerGuessIsCorrectOrIncorrectGameObjects()
        {
            if (_computerGuessIsCorrectOrIncorrectGameObjects == null)
            {
                _computerGuessIsCorrectOrIncorrectGameObjects = new List<GameObject>()
                {
                    GameObject.Find("ComputerGuessIsCorrect"),
                    GameObject.Find("ComputerGuessIsIncorrect")
                };
            }

            return _computerGuessIsCorrectOrIncorrectGameObjects;
        }

        public List<GameObject> GetComputerGuessShouldBeHigherOrLowerGameObjects()
        {
            if (_computerGuessShouldBeHigherOrLowerGameObjects == null)
            {
                _computerGuessShouldBeHigherOrLowerGameObjects = new List<GameObject>()
                {
                    GameObject.Find("ComputerGuessShouldBeHigher"),
                    GameObject.Find("ComputerGuessShouldBeLower")
                };
            }

            return _computerGuessShouldBeHigherOrLowerGameObjects;
        }
    }
}
