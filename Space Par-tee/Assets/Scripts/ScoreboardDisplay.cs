using TMPro;
using UnityEngine;

public class ScoreboardDisplay : MonoBehaviour
{
    TextMeshProUGUI textMeshPro;

    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        textMeshPro.text = "Planets used: " + StatSystem.Instance.GetPlanetTotal();
    }
}
