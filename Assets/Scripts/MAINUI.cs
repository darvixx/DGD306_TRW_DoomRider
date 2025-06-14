using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainmenuPanel;

    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OpenSettings()
    {
        // Ayarlar men�s� a��lacaksa buraya ekle
    }

    public void OpenCredits()
    {
        // Credits sahnesi varsa buraya a�abilirsin
    }

    public void QuitGame()
    {
        Debug.Log("Oyundan ��k�l�yor...");
        Application.Quit();
    }
}
