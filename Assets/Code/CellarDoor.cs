using UnityEngine;
using System.Collections;

public class CellarTeleport : MonoBehaviour
{
    public Transform teleportPoint;   
    private bool playerInRange = false;

    private bool teleportCooldown = false;
    public float teleportCooldownTime = 0.3f;

    void Update()
    {
        if (playerInRange && !teleportCooldown && Input.GetKeyDown(KeyCode.E))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = teleportPoint.position;

            playerInRange = false;

            Physics.SyncTransforms();

            StartCoroutine(TeleportDelay());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private IEnumerator TeleportDelay()
    {
        teleportCooldown = true;
        yield return new WaitForSeconds(teleportCooldownTime);
        teleportCooldown = false;
    }
}
