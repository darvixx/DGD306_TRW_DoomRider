using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene"); 
    }

    public void OpenSettings()
    {
        
    }

    public void OpenCredits()
    {
        
    }

    public void QuitGame()
    {
        Debug.Log("Oyundan ��k�l�yor...");
        Application.Quit();

        

    }
}

