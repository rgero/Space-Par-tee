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
            if (IsPlanetThere())
                return;

            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(planetToSpawn, worldPosition, Quaternion.identity, parentHolder);
        }

        // Destroy planet if it is there
        if (Input.GetMouseButtonDown(1))
        {
            // Check to see if there's something already there
            GameObject planet = IsPlanetThere();
            if (planet != null)
            {
                Debug.Log("Destroying planet.");
                Destroy(planet);
            }
        } 
    }

    private bool IsPointerOverUI()
    {
        return EventSystem.current != null && EventSystem.current.IsPointerOverGameObject();
    }

    private GameObject IsPlanetThere()
    {
        // Check to see if there's something already there
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            // If the object is not null and has a tag, return
            if (hit.collider.gameObject.CompareTag("Planet"))
            {
                Debug.Log("Hit a planet, not spawning.");
                return hit.collider.gameObject;
            }
        }
        return null;
    }
}
