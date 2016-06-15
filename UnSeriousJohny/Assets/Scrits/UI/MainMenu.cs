using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Title;
    public GameObject SinglePlayerPanel;
    public GameObject NetworkPlayPanel;
    public GameObject SettingsPanel;

    void OnEnable()
    {
        Title.SetActive(true);
    }
    public void OnSinglePlayerClicked()
    {
        StartNewGame();
        //maybe add transitions
        //SinglePlayerPanel.SetActive(true);
        //Transition();
    }

    private void StartNewGame()
    {
        PlayerPrefs.SetInt("Health", 100);
        SceneManager.LoadScene("Level01");
    }

    public void OnNetworkPlayClicked()
    {
        //transitions here too
        NetworkPlayPanel.SetActive(true);
        Transition();
    }

    public void OnSettingsClicked()
    {
        //and here
        SettingsPanel.SetActive(true);
        Transition();
    }

    public void OnQuitClicked()
    {
        Application.Quit();
    }

    void Transition()
    {
       Title.SetActive(false);
        gameObject.SetActive(false);
    }
}
