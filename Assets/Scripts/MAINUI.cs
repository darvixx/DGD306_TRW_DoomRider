using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenuManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainmenuPanel;
    public GameObject settingsPanel;
    public GameObject creditsPanel;

    [Header("First Selected Buttons")]
    public GameObject mainmenuFirstSelected;
    public GameObject settingsFirstSelected;
    public GameObject creditsFirstSelected;

    void Start()
    {
        // Oyun baþladýðýnda ana menüde ilk butonu seç
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(mainmenuFirstSelected);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("CharacterSelect");
    }

    public void OpenSettings()
    {
        mainmenuPanel.SetActive(false);
        settingsPanel.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(settingsFirstSelected);
    }

    public void OpenCredits()
    {
        mainmenuPanel.SetActive(false);
        creditsPanel.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(creditsFirstSelected);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        mainmenuPanel.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(mainmenuFirstSelected);
    }

    public void CloseCredits()
    {
        creditsPanel.SetActive(false);
        mainmenuPanel.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(mainmenuFirstSelected);
    }

    public void QuitGame()
    {
        Debug.Log("Oyundan çýkýlýyor...");
        Application.Quit();
    }
}
