using System;
using UnityEngine;
using System.Collections;

public class ControlSettings : MonoBehaviour {

    public void OnMouseSensitivityChanged(float value)
    {
        ControlsManager.MouseSensitivity = value;
    }

    public void OnKeybindClicked()
    {
        //StartCoroutine(GetInput());
    }

    private IEnumerator GetInput()
    {
        yield return new WaitForSeconds(0.1f);
        while (true)
        {
            foreach (KeyCode code in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(code))
                {
                    Debug.Log(code);
                }
            }
        }
    }
}
