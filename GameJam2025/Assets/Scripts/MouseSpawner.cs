using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseSpawner : MonoBehaviour
{
    public GameObject planetToSpawn;

    public Transform parentHolder;

    void Start()
    {
        SelectionSystem.Instance.OnSelectionChange += HandleSelectionChange;
        planetToSpawn = SelectionSystem.Instance.GetSelectedPlanet();
    }

    private void HandleSelectionChange(object sender, EventArgs e)
    {
        planetToSpawn = SelectionSystem.Instance.GetSelectedPlanet();
    }

    void Update()
    {
        if (IsPointerOverUI())
            return;

        if (Input.GetMouseButtonDown(0)) // Left mouse click
        {
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(planetToSpawn, worldPosition, Quaternion.identity, parentHolder);
        }
    }

    private bool IsPointerOverUI()
    {
        return EventSystem.current != null && EventSystem.current.IsPointerOverGameObject();
    }
}
