using UnityEngine;

public class RainZoneTrigger : MonoBehaviour
{
    public WeatherAudioManager weatherAudioManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            weatherAudioManager.PlayInsideRain();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            weatherAudioManager.PlayOutsideRain();
        }
    }
}
