using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.UI;

public class FontEqalizer : MonoBehaviour
{
    public bool AutomaticSet;
    public Text[] Texts;

    private void Start()
    {
        ResizeText();
    }

    public void ResizeText()
    {
        if (AutomaticSet)
            Texts = GetComponentsInChildren<Text>();
        StartCoroutine(FixFont());
    }
    private IEnumerator FixFont()
    {
        foreach (var text in Texts)
        {
            text.resizeTextForBestFit = true;
        }
        while (true)
        {
            yield return new WaitUntil(() => Texts.All(text => text.cachedTextGenerator.fontSizeUsedForBestFit == 0));
            var lower = Texts.Select(text => text.cachedTextGenerator.fontSizeUsedForBestFit).Concat(new[] {int.MaxValue}).Min();
            foreach (var text in Texts)
            {
                text.resizeTextForBestFit = false;
                text.fontSize = lower;
            }
            break;
        }
    }
}
