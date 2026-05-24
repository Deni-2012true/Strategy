using UnityEngine;

public class Camera1 : MonoBehaviour
{
   public Transform playerTarget; 
   public Vector3 offset = new Vector3(0f, 10f, -5f);
   public float FollowSmoothness = 5f;

    void LateUpdate()
    {
      Vector3 targetPosition = playerTarget.position + offset;
      transform.position = Vector3.Lerp(transform.position, targetPosition, FollowSmoothness * Time.deltaTime);
    }
}
