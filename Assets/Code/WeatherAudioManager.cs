using UnityEngine;

public class WeatherAudioManager : MonoBehaviour
{
    public AudioClip rainOutsideClip;
    public AudioClip rainInsideClip;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayOutsideRain();
    }

    public void PlayOutsideRain()
    {
        if (audioSource.clip != rainOutsideClip)
        {
            audioSource.Stop(); // 🔹 stop current audio
            audioSource.clip = rainOutsideClip;
            audioSource.Play();
        }
    }

    public void PlayInsideRain()
    {
        if (audioSource.clip != rainInsideClip)
        {
            audioSource.Stop(); // 🔹 stop current audio
            audioSource.clip = rainInsideClip;
            audioSource.Play();
        }
    }
}

