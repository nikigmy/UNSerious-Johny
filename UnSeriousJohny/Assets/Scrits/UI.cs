using Assets;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private GameObject TextBar;
    private RectTransform healthTransform;
    private Text HealthText;
	void Start ()
	{
	    healthTransform = transform.GetChild(0).GetComponent<RectTransform>();
	    HealthText = transform.GetChild(0).GetComponent<Text>();
	}
	
	void Update ()
	{
	    HealthText.text = "Health: " + Soldier.Character.Health;
        healthTransform.localPosition = new Vector3(-Screen.width / 2 + 160,-Screen.height / 2,0);
	}
}
