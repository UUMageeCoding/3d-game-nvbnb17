using UnityEngine;
using TMPro;

public class KeyPickup : MonoBehaviour
{
    public static bool hasKey = false;
    private bool playerInRange = false;

    public TextMeshProUGUI messageText;
    public float messageDuration = 2f;
    private float messageTimer = 0f;

    public AudioClip keyPickupSound;
    private AudioSource playerAudio;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            playerAudio = player.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInRange = false;
    }

    private void ShowMessage(string text)
    {
        if (messageText != null)
        {
            messageText.text = text;
            messageText.gameObject.SetActive(true);
            messageTimer = messageDuration; 
        }
    }

    private void Update()
    {
        if (messageText != null && messageText.gameObject.activeSelf)
        {
            messageTimer -= Time.deltaTime;
            if (messageTimer <= 0)
                messageText.gameObject.SetActive(false);
        }

        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            KeyPickup.hasKey = true;

            if (playerAudio != null && keyPickupSound != null)
                playerAudio.PlayOneShot(keyPickupSound);
            ShowMessage("You found the key.");
            if (TryGetComponent<MeshRenderer>(out var mr)) mr.enabled = false;
            if (TryGetComponent<Collider>(out var col)) col.enabled = false;
            Destroy(gameObject, messageDuration + 0.1f);
        }
    }
}
