using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseSpawner : MonoBehaviour
{
    public GameObject planetToSpawn;
    public float clickCooldown = 0.5f;
    private float lastClickTime = 0f;

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
        lastClickTime += Time.deltaTime;

        bool isCooldown = lastClickTime < clickCooldown;

        if (Input.GetMouseButtonDown(0))
        {
            if (IsPointerOverUI())
                return;

            if (isCooldown)
                return;

            if (IsPlanetThere())
                return;

            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(planetToSpawn, worldPosition, Quaternion.identity, parentHolder);

            lastClickTime = 0f;
        }

        // Destroy planet if it is there
        if (Input.GetMouseButtonDown(1))
        {
            GameObject planet = GetPlanetUnderMouse();
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

    private bool IsPlanetThere()
    {
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D hit = Physics2D.OverlapPoint(worldPoint);
        if (hit != null && hit.CompareTag("PlanetGravity"))
        {
            Debug.Log("Hit a planet, not spawning.");
            return true;
        }
        return false;
    }
    
    private GameObject GetPlanetUnderMouse()
    {
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D hit = Physics2D.OverlapPoint(worldPoint);
        if (hit != null && hit.CompareTag("Planet"))
        {
            return hit.gameObject;
        }
        return null;
    }
}
