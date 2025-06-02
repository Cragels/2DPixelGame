using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private string SettingsName = "SettingsMenu";
   public void PlayGame()
   {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
   }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void SettingsLoad()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Additive);
    }

    public void Close()
    {
        SceneManager.UnloadSceneAsync(SettingsName);
    }

}
