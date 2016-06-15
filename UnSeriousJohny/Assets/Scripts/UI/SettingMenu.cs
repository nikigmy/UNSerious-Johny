using UnityEngine;
using System.Collections;
using Assets;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    public InGameUI InGameUI;
    public bool isMainMenu;
    public Button[] Buttons;
    public GameObject[] Panels;
    private int currentPanelIndex;
    public void OnButtonClicked(int index)
    {
        if (index == Buttons.Length - 1)
        {
            if (isMainMenu)
            {
                SetActiveInactive(0, currentPanelIndex);
                Panels[index].SetActive(true);
                gameObject.SetActive(false);
            }
            else
            {
                InGameUI.UnPause();
            }
            return;
        }
        SetActiveInactive(index, currentPanelIndex);
    }

    void SetActiveInactive(int activeIndex, int inactiveIndex)
    {
        Buttons[inactiveIndex].interactable = true;
        Panels[inactiveIndex].SetActive(false);
        Buttons[activeIndex].interactable = false;
        Panels[activeIndex].SetActive(true);
        currentPanelIndex = activeIndex;
    }
}
