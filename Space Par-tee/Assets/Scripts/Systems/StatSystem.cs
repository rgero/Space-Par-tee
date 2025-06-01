using UnityEngine;

public class StatSystem : MonoBehaviour
{
    public static StatSystem Instance { get; private set; }
    int PlanetTotal { get; set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.LogError("There's more than one StatSystem! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        PlanetTotal = 0;
    }

    public void AddPlanet()
    {
        PlanetTotal++;
    }

    public void RemovePlanet()
    {
        if (PlanetTotal > 0)
        {
            PlanetTotal--;
        }
        else
        {
            Debug.LogWarning("PlanetTotal is already zero. Cannot remove a planet.");
        }
    }

    public int GetPlanetTotal()
    {
        return PlanetTotal;
    }

    public void ResetScore()
    {
        PlanetTotal = 0;
    }

}
