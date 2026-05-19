using UnityEngine;


public class ButtonController : MonoBehaviour
{
   public GameObject Pointer;
   public GameObject Canvas;
   public Transform Cube;


   private float elapsedTime = 0f;
   private float duration = 2f;
   private bool isMoving = false;
   private Vector3 targetPosition;  // Фиксируем целевую позицию


   public static Vector3 startPosition;


   
   
   
   
   void Update()
   {
       if (isMoving)
       {
           PointMovement();
       }
   }


   public void RunButtonClick()
   {
       Debug.Log("Кнопка Run нажата");
       StartMovement();
       Canvas.SetActive(false);
   }


   public void StartMovement()
   {
       startPosition = Pointer.transform.position;
       targetPosition = ClickDetector.nextPosition;  // Сохраняем целевую позицию в момент старта
       elapsedTime = 0f;
       isMoving = true;
       Debug.Log("startPosition: " + startPosition);
       Debug.Log("targetPosition: " + targetPosition);
   }
  
   public void PointMovement()
   {
       elapsedTime += Time.deltaTime;
       float t = elapsedTime / duration;
       t = Mathf.Clamp01(t);
       float smoothT = Mathf.SmoothStep(0f, 1f, t);
       Pointer.transform.position = Vector3.Lerp(startPosition, targetPosition, smoothT);
      
       if (t >= 1f)
       {
           Pointer.transform.position = targetPosition;  // Используем сохраненную позицию
           isMoving = false;
           Debug.Log("Moving completed to: " + targetPosition);
       }
   }
}



/*using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject Pointer;
    public GameObject Canvas;
    public Transform Cube;

    public void Start()
    {
        ClickDetector.nextPosition = Cube.position;
        startPosition = Cube.position;
    }

    public Vector3 startPosition;

    private float speed = 2;
    
    void Update()
    {
        
    }

    public void RunButtonClick()
    {
        Debug.Log("Кнопка Run нажата");
        StartMovement();
        Canvas.SetActive(false);
        Moving();
    }

    public void StartMovement()
    {
        startPosition = Pointer.transform.position;
        Debug.Log(ClickDetector.nextPosition);
    }
    
    public void Moving()
    {
        Pointer.transform.position = Vector3.MoveTowards(startPosition, ClickDetector.nextPosition, speed * Time.deltaTime);
    }
    
}
*/
