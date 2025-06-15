using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CharacterSelectInput : MonoBehaviour
{
    void Update()
    {
        var gamepad = Gamepad.current;
        if (gamepad == null) return;

        if (gamepad.buttonWest.wasPressedThisFrame) // X tuþu
        {
            SceneManager.LoadScene("SampleScene");
        }

        if (gamepad.buttonSouth.wasPressedThisFrame) // A tuþu
        {
            SceneManager.LoadScene("Player2");
        }
    }
}
