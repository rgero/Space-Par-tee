using System;
using UnityEngine;
using UnityEngine.UI;

public class CurrentlySelected : MonoBehaviour
{
    private GameObject selectionBox;
    public int planetIndex;

    void Start()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(() => SelectionSystem.Instance.SetSelectedPlanet(planetIndex));

        selectionBox = gameObject.transform.GetChild(0).gameObject;
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
            if (selectedPlanet.gameObject.name == gameObject.name)
            {
                selectionBox.SetActive(true);
            }
            else
            {
                selectionBox.SetActive(false);
            }
        }
    }
}
