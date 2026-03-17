using UnityEngine;

public class ClickDetector : MonoBehaviour
{
    public Transform House;
    public Transform CoperMine;
    public Transform StonePlateau;
    public Transform Town;
    public Transform Forest;
    
    public GameObject Canvas;

    public static Vector3 nextPosition;
   


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
                    nextPosition = House.position;
                    Canvas.SetActive(true);
                }
                else if (hitObjectName == "Town")
                {
                    nextPosition = Town.position; 
                    Canvas.SetActive(true);
                }
                else if (hitObjectName == "CopperMine")
                {
                    nextPosition = CoperMine.position; 
                    Canvas.SetActive(true);
                }
                else if (hitObjectName == "TheStonePlateau")
                {
                    nextPosition = StonePlateau.position; 
                    Canvas.SetActive(true);
                }
                else if (hitObjectName == "Forest")
                {
                    nextPosition = Forest.position;
                    Canvas.SetActive(true);
                }
                
                
            }
        }
        
        
            
    }
    
    
}