using System;
using UnityEngine;
using UnityEngine.UI;

public class CurrentlySelected : MonoBehaviour
{
    private Sprite targetSprite;
    void Start()
    {
        SelectionSystem.Instance.OnSelectionChange += HandleSelectionChange;
        GetSprite();
    }

    private void HandleSelectionChange(object sender, EventArgs e)
    {
        GetSprite();
    }

    private void GetSprite()
    {
        GameObject selectedPlanet = SelectionSystem.Instance.GetSelectedPlanet();
        if (selectedPlanet != null)
        {
            targetSprite = selectedPlanet.GetComponent<SpriteRenderer>().sprite;
            RawImage image = GetComponent<RawImage>();
            image.texture = targetSprite.texture;
            image.color = selectedPlanet.GetComponent<SpriteRenderer>().color;
            Debug.Log("Currently selected planet: " + selectedPlanet.name);
        }
    }
}
