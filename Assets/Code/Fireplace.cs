using UnityEngine;

public class FireplaceAudio : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop(); // 🔹 ensure it starts off
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            audioSource.Play(); // play when player enters
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            audioSource.Stop(); // stop when player leaves
    }
}
