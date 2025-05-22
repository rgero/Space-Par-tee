using System;
using UnityEngine;

public class SelectionSystem : MonoBehaviour
{
    public static SelectionSystem Instance { get; private set; }

    public event EventHandler OnSelectionChange;

    public GameObject selectedPlanet;
    public GameObject[] planets;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than one TurnSystem! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void SetSelectedPlanet(int prefabIndex)
    {
        selectedPlanet = planets[prefabIndex];
        Debug.Log("Selected prefab: " + selectedPlanet.name);
        OnSelectionChange?.Invoke(this, EventArgs.Empty);
    }

    public GameObject GetSelectedPlanet()
    {
        return selectedPlanet;
    }
}
