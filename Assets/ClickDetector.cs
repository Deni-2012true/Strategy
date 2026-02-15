using UnityEngine;

public class ClickDetector : MonoBehaviour
{
   public static Transform END_POSITION;
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
                        Kursor.nextPosition.position = Kursor.House.position;
                    }
                    if (gameObject.name == "Town")
                    {
                       Kursor.nextPosition.position = Kursor.Town.position; 
                    }
                    if (gameObject.name == "CopperMine")
                    {
                       Kursor.nextPosition.position = Kursor.CoperMine.position; 
                    }
                  if (gameObject.name == "TheStonePlateau")
                    {
                       Kursor.nextPosition.position = Kursor.StonePlatue.position; 
                   }
                    if (gameObject.name == "Forest")
                   {
                       Kursor.nextPosition.position = Kursor.Forest.position; 
                    }
                    
                    }
            }
    }
}
}
