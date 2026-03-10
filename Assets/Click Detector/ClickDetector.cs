using UnityEngine;

public class ClickDetector : MonoBehaviour
{
    public Transform House;
    public Transform CoperMine;
    public Transform StonePlateau;
    public Transform Town;
    public Transform Forest;

    public Transform Cube;

    public GameObject Pointer;
    
    public Transform nextPosition;
    
    private float elapsedTime = 0f;
    private float duration = 2f;
    private Vector3 startPosition;

    void Start ()
    {
        startPosition = Cube.position;
        nextPosition.position = Cube.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                string hitObjectName = hit.transform.gameObject.name;
                
                if (hitObjectName == "House")
                {
                    nextPosition.position = House.position;
                    StartMovement();
                }
                else if (hitObjectName == "Town")
                {
                    nextPosition.position = Town.position; 
                    StartMovement();
                }
                else if (hitObjectName == "CopperMine")
                {
                    nextPosition.position = CoperMine.position; 
                    StartMovement();
                }
                else if (hitObjectName == "TheStonePlateau")
                {
                    nextPosition.position = StonePlateau.position; 
                    StartMovement();
                }
                else if (hitObjectName == "Forest")
                {
                    nextPosition.position = Forest.position; 
                    StartMovement();
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
            //Debug.Log("Moving completed to: " + nextPosition.position);
        }
    }
}