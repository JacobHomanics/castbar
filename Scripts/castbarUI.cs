using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class castbarUI : MonoBehaviour
{
    public Transform timerUI;
    public void OnCast(Sprite sprite, string name)
    {
        FindDeepChild(timerUI.transform, "Image").GetComponent<Image>().sprite = sprite;
        FindDeepChild(timerUI.transform, "Spell Indicator Text").GetComponent<TMP_Text>().text = name;
    }

    private Transform FindDeepChild(Transform parent, string name)
    {
        foreach (Transform child in parent)
        {
            if (child.name == name)
                return child;

            var result = FindDeepChild(child, name);
            if (result != null)
                return result;
        }
        return null;
    }
}
