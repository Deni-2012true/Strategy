using UnityEngine;

public class Kursor : MonoBehaviour
{
    private Transform startPoint;
    private Transform endPoint;
    public float duration;
    public bool loopMovement = true;
    private float elapsedTime = 0f;
    private bool movingForward = true;

    public static int curentPosition = 1;
    public static Transform nextPosition;

    public static Transform House;
    public static Transform CoperMine;
    public static Transform StonePlatue;
    public static Transform Town;
    public static Transform Forest;

    void Start()
    {
        startPoint.position = House.position;
    //    nextPosition.position = Town.position;
    }
    
    void Update()
    {           

      //  endPoint.position = nextPosition.position;

        elapsedTime += Time.deltaTime;
        float t = elapsedTime / duration;
        t = Mathf.SmoothStep(0f, 1f, t);
        
        if (movingForward)
        {
            transform.position = Vector3.Lerp(startPoint.position, endPoint.position, t);
        }
        //else
        //{
           // transform.position = Vector3.Lerp(endPoint.position, startPoint.position, t);
        //}
        if (elapsedTime >= duration)
        {
 //           if (loopMovement)
  //          {
  //              movingForward = !movingForward;
   //             elapsedTime = 0f;
   //         }
   //         else
            {
                this.enabled = false;
            }
        }
    } 
}

