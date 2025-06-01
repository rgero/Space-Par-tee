using UnityEngine;

public class OptionsPanelController : MonoBehaviour
{
    public static OptionsPanelController Instance { get; private set; }

    public GameObject optionsPanel;
    public KeyCode toggleKey = KeyCode.Escape;

    private bool isOpen = false;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        if (optionsPanel != null)
            optionsPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            ToggleOptionsPanel();
        }
    }

    public void ToggleOptionsPanel()
    {
        if (optionsPanel == null) return;

        isOpen = !isOpen;
        optionsPanel.SetActive(isOpen);

        Time.timeScale = isOpen ? 0 : 1;
    }
}
