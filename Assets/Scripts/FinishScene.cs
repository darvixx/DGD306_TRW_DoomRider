using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class FinishSceneManager : MonoBehaviour
{
    private InputAction confirmAction;

    void OnEnable()
    {
        confirmAction = new InputAction(binding: "<Gamepad>/buttonSouth"); // A tuþu
        confirmAction.Enable();
        confirmAction.performed += ctx => LoadMainMenu();
    }

    void OnDisable()
    {
        confirmAction.Disable();
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
