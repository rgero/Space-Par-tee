using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer Instance { get; private set; }

    public AudioClip[] musicClips;
    private AudioSource audioSource;
    private int currentClipIndex = 0;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.LogError("There's more than one MusicPlayer! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = false;

        float savedVolume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        audioSource.volume = savedVolume;

        PlayNextClip();
    }

    void Update()
    {
        if (!audioSource.isPlaying && audioSource.time == 0f)
        {
            PlayNextClip();
        }
    }

    void PlayNextClip()
    {
        if (musicClips.Length == 0) return;

        audioSource.clip = musicClips[currentClipIndex];
        audioSource.Play();
        currentClipIndex = (currentClipIndex + 1) % musicClips.Length;
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume);
        PlayerPrefs.Save();
    }

    public float GetVolume()
    {
        return audioSource.volume;
    }
}
