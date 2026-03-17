using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject Pointer;
    public GameObject Canvas;
    public Transform Cube;

    private float elapsedTime = 0f;
    private float duration = 2f;

    public static Vector3 startPosition;

    //void Start ()
    //{
        //startPosition = Cube.position;
        //ClickDetector.nextPosition = Cube.position;
    //}
    
    void Update()
    {
        PointMovement();
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
        elapsedTime = 0f;
    }
    
    public void PointMovement()
    {
        elapsedTime += Time.deltaTime;
        float t = elapsedTime / duration;
        t = Mathf.Clamp01(t);
        float smoothT = Mathf.SmoothStep(0f, 1f, t);
        Pointer.transform.position = Vector3.Lerp(startPosition, ClickDetector.nextPosition, smoothT);
        
        if (t >= 1f)
        {
            Pointer.transform.position = ClickDetector.nextPosition;
            //Debug.Log("Moving completed to: " + ClickDetector.nextPosition);
        }
    }


}
