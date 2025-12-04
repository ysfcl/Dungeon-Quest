using UnityEngine;

public class MusicManager_sc : MonoBehaviour
{
    public static MusicManager_sc instance;
    AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = GetComponent<AudioSource>();

        
        float volume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        audioSource.volume = volume;
    }

    public void SetVolume(float volume)
    {
        audioSource.volume=volume;
        PlayerPrefs.SetFloat("MusicVolume",volume);
    }

    
}
