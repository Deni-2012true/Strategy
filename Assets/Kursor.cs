using UnityEngine;

public class Kursor : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float duration;
    public bool loopMovement = true;
    private float elapsedTime = 0f;
    private bool movingForward = true;

    void Update()
    {
        elapsedTime += Time.deltaTime;
        float t = elapsedTime / duration;
        t = Mathf.SmoothStep(0f, 1f, t);
        
        if (movingForward)
        {
            transform.position = Vector3.Lerp(startPoint.position, endPoint.position, t);
        }
        else
        {
            transform.position = Vector3.Lerp(endPoint.position, startPoint.position, t);
        }
        if (elapsedTime >= duration)
        {
            if (loopMovement)
            {
                movingForward = !movingForward;
                elapsedTime = 0f;
            }
            else
            {
                this.enabled = false;
            }
        }
    } 
}

