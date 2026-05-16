/*using UnityEngine;

public class PlatueDetector : MonoBehaviour
{
    public Transform House;
    public Transform CoperMine;
    public Transform StonePlatue;
    public Transform Town;
    public Transform Forest;
    public GameObject Pointer;
    
    
    public Transform nextPosition;


    public float duration;
    private float elapsedTime = 0f;








void Update()
{

    if (Input.GetMouseButtonDown(0))
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                    
                    {
                    

                    Debug.Log("Клик по объекту: " + gameObject.name);
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
                       nextPosition.position = StonePlatue.position; 
                       
                    }
                    if (gameObject.name == "Forest")
                    {
                       nextPosition.position = Forest.position; 
                       
                    }
                    
                    }
            }
    }
   
    
            PointMovement();
        
}

public void PointMovement()
{
    elapsedTime += Time.deltaTime;
    float t = elapsedTime / duration;
    t = Mathf.SmoothStep(0f, 1f, t);
    Pointer.transform.position = Vector3.Lerp(Pointer.transform.position, nextPosition.position, t);
    
    if (elapsedTime >= duration)
        {
            {
                this.enabled = false;
            }
        }
}

}
*/