namespace Assets.Code.Handlers.Display
{
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
    }
}
