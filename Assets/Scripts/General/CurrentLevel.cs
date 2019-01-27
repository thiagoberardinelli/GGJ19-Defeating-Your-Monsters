using TMPro;
using UnityEngine;

public class CurrentLevel : MonoBehaviour
{
    public TextMeshProUGUI tmPro;

    [HideInInspector] public static int indexLevel = 1;

    private void OnEnable()
    {
        if (indexLevel == 1)
            tmPro.text = "Week 1";
        else if (indexLevel == 2)
            tmPro.text = "Week 2";
        else if (indexLevel == 3)
            tmPro.text = "Week 3";
    }
}
