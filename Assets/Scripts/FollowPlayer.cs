using UnityEngine;
using FishNet.Object;

public class FollowPlayer : MonoBehaviour
{
    
    [Header("Target")]
    public Transform player;
   //  private Vector3 offset = new Vector3(0, 5, -15);

   [Header("Offset")]
   public float distance = 15f;
   public float height = 5f;

   [Header("Camera State")]
   public bool lookingBehind = false;





    // Update is called once per frame
    void LateUpdate()
    {
        if (!player) return;
        // Distance behind for camera
        Vector3 targetPos;

        if (!lookingBehind)
        {
            targetPos = player.position - (player.forward * distance);
        }
        else
        {
            targetPos = player.position + (player.forward * distance);
        }

        // Height offset
        targetPos.y += height;

        // Move to position
        transform.position = targetPos;

        // Force look direction
        transform.LookAt(player.position);
    }
}
