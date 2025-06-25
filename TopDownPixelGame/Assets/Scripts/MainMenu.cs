using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private string SettingsName = "SettingsMenu";
    private PlayerController controller;

   public void PlayGame()
   {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        SceneManager.LoadScene("Difficulty");
        controller.isAlive = true;
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
