using TMPro;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.ProBuilder.Shapes;

public class LockedDoor : MonoBehaviour
{
    public Transform teleportTarget;
    public TextMeshProUGUI messageText;
    public float messageDuration =2f;

    public AudioClip lockedSound;
    public AudioClip doorOpenSound;
    private AudioSource playerAudio;
    private bool playerInRange = false;
    private float messageTimer = 0f;

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

        //message timer
        if (messageText != null && messageText.gameObject.activeSelf)
        {
            messageTimer -= Time.deltaTime;
            if(messageTimer <= 0)
                messageText.gameObject.SetActive(false);
        }

        //interaction from player
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (KeyPickup.hasKey)
            {
                //Audio Plays
                if (playerAudio != null && doorOpenSound != null)
                playerAudio.PlayOneShot(doorOpenSound);


                GameObject player = GameObject.FindGameObjectWithTag("Player");
                CharacterController cc = player.GetComponent<CharacterController>();
                if (cc != null) cc.enabled = false;

                // Teleport
                player.transform.position = teleportTarget.position;
                player.transform.rotation = teleportTarget.rotation;

                playerInRange = false;

                Physics.SyncTransforms();

                      
                if (cc != null) cc.enabled = true;
            }
            else
            {
                if (playerAudio != null && lockedSound != null)
                playerAudio.PlayOneShot(lockedSound);
                ShowMessage("The door is locked.");
            }
        }
    }
}
