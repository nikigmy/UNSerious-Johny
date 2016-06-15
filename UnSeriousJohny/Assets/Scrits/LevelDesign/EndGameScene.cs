using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameScene : MonoBehaviour
{
    public Text text;
    public AudioClip WinClip;
    public AudioClip GameOverClip;
    private AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        string result = PlayerPrefs.GetString("Result");
        text.text = result;
        if (result == "Game Over")
            audio.clip = GameOverClip;
        else audio.clip = WinClip;
        audio.Play();


    }
    void Update () {
        if (Input.anyKey)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("Menu");
        }
    }
}
