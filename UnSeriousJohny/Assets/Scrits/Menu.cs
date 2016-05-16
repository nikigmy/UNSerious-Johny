using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void OnPlayClicked()
    {
        PlayerPrefs.SetInt("Health",100);
        PlayerPrefs.SetInt("ZombiesLeft",0);   
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene("Level01");
    }

    public void OnExitClicked()
    {
        Application.Quit();
    }
}
