using Assets;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public GameObject Health;
    private RectTransform healthTransform;
    private Text HealthText;
    public GameObject Settings;
	void Start ()
	{
	    healthTransform = Health.GetComponent<RectTransform>();
	    HealthText = Health.GetComponent<Text>();
	}
	
	void Update ()
	{
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!Soldier.Paused)
                Pause();
            else
                UnPause();
        }
        HealthText.text = "Health: " + Soldier.Character.Health;
        healthTransform.localPosition = new Vector3(-Screen.width / 2 + 160,-Screen.height / 2,0);
	}

    public void UnPause()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Soldier.Paused = false;
        Health.SetActive(true);
        Settings.SetActive(false);
    }

    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Soldier.Paused = true;
        Health.SetActive(false);
        Settings.SetActive(true);
    }
}
