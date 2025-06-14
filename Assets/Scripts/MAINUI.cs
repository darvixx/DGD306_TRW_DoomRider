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
        // Ayarlar menüsü açýlacaksa buraya ekle
    }

    public void OpenCredits()
    {
        // Credits sahnesi varsa buraya açabilirsin
    }

    public void QuitGame()
    {
        Debug.Log("Oyundan çýkýlýyor...");
        Application.Quit();
    }
}
