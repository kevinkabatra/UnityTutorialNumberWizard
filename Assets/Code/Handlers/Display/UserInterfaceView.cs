namespace Assets.Code.Handlers.Display
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class UserInterfaceView : MonoBehaviour
    {
        [SerializeField] public Button AttemptGuess;
        [SerializeField] public Button ComputerGuessShouldBeHigher;
        [SerializeField] public Button ComputerGuessShouldBeLower;

        [SerializeField] public InputField UserGuess;
        [SerializeField] public InputField ComputerGuess;

        [SerializeField] public Text Instructions;

        private List<GameObject> _gameObjects;

        public List<GameObject> GetGameObjects()
        {
            if (_gameObjects == null)
            {
                _gameObjects = new List<GameObject>()
                {
                    GameObject.Find("AttemptGuess"),
                    GameObject.Find("ComputerGuess"),
                    GameObject.Find("UserGuess")
                };
            }

            return _gameObjects;
        }
    }
}
