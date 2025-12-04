using UnityEngine;

public class SFXManager_sc : MonoBehaviour
{
    public static SFXManager_sc instance;
    public AudioSource audioSource;

    public AudioClip jumpSFX;
    public AudioClip attackSFX;
    public AudioClip deathSFX;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        float sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);
        audioSource.volume = sfxVolume;
    }

    public void SetSFXVolume(float volume)
    {
        audioSource.volume = volume;
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    public void PlayJump() => audioSource.PlayOneShot(jumpSFX);
    public void PlayAttack() => audioSource.PlayOneShot(attackSFX);
    public void PlayDeath() => audioSource.PlayOneShot(deathSFX);


}
