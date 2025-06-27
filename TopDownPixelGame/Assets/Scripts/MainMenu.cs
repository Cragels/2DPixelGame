using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private string SettingsName = "SettingsMenu";
    private PlayerController controller;
    public GameObject mainMenuUi;
    public GameObject SettingBackButton;
    public GameObject QuitConfirmUi;
    public GameObject CreditUiMenu;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        //SceneManager.LoadScene("Difficulty");
        //controller.isAlive = true;

    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void SettingsLoadMainMenu()
    {

        StartCoroutine(SettingsLoad());
    }

    IEnumerator SettingsLoad()
    {
        yield return new WaitForSeconds(0.65f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Additive);
    }

    public void MainMenuLoad()
    {
        StartCoroutine(MenuLoad());
    }

    public void Close()
    {
        SceneManager.UnloadSceneAsync(SettingsName);
    }

    IEnumerator MenuLoad()
    {
        yield return new WaitForSeconds(0.65f);
        mainMenuUi.SetActive(true);
    }

    public void SettingBackUi()
    {
        StartCoroutine(SetBack());
    }

    IEnumerator SetBack()
    {
        yield return new WaitForSeconds(0.65f);
        SettingBackButton.SetActive(true);
    }

    public void QuitConfirm()
    {
        StartCoroutine(QuitUi());
    }

    IEnumerator QuitUi()
    {
        yield return new WaitForSeconds(0.65f);
        QuitConfirmUi.SetActive(true);
    }

    public void CreditsUi()
    {
        StartCoroutine(CreditUiTime());
    }

    IEnumerator CreditUiTime()
    {
        yield return new WaitForSeconds(0.65f);
        CreditUiMenu.SetActive(true);
    }

}
