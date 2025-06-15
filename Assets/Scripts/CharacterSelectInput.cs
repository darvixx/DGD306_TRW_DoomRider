using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CharacterSelectInput : MonoBehaviour
{
    void Update()
    {
        var gamepad = Gamepad.current;
        if (gamepad == null) return;

        if (gamepad.buttonWest.wasPressedThisFrame) // X tu�u
        {
            SceneManager.LoadScene("SampleScene");
        }

        if (gamepad.buttonSouth.wasPressedThisFrame) // A tu�u
        {
            SceneManager.LoadScene("Player2");
        }
    }
}
