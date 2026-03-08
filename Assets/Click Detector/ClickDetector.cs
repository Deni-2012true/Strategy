using UnityEngine;

public class ClickDetector : MonoBehaviour
{
    public Transform House;
    public Transform CoperMine;
    public Transform StonePlateau;
    public Transform Town;
    public Transform Forest;
    public GameObject Pointer;
    
    public Transform nextPosition;
    
    private float elapsedTime = 0f;
    private float duration = 2f;
    private Vector3 startPosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Kursor.Moving == false)
            {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform && !isMoving)
                {
                    if (gameObject.name == "House")
                    {
                        nextPosition.position = House.position;
                    }
                    if (gameObject.name == "Town")
                    {
                        nextPosition.position = Town.position; 
                    }
                    if (gameObject.name == "CopperMine")
                    {
                        nextPosition.position = CoperMine.position; 
                    }
                    if (gameObject.name == "TheStonePlateau")
                    {
                        nextPosition.position = StonePlateau.position; 
                    }
                    if (gameObject.name == "Forest")
                    {
                        nextPosition.position = Forest.position; 
                    }
                    
                    StartMovement();
                }
            }
            }
        }
        
        
        
            PointMovement();
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
        Pointer.transform.position = Vector3.Lerp(startPosition, nextPosition.position, smoothT);
        
        if (t >= 1f)
        {
            Pointer.transform.position = nextPosition.position;
            Debug.Log("Moving completed");
        }
    }
}