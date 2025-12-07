using UnityEngine;

public class AmbientSound : MonoBehaviour
{
    public Collider Area;
    public GameObject Player;


    void Update()
    {
        //locate closest point on the collider to the player
        Vector3 closestPoint = Area.ClosestPoint(Player.transform.position);
        //Set position to closest point to the player
        transform.position = closestPoint;
    }
}
