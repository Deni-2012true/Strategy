using UnityEngine;

public class Mining : MonoBehaviour
{
    public GameObject Axe;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("tree"))
        {
            Debug.Log("Игрок вошел в зону!");
            Axe.SetActive(true);
        } 
        
    }
    
    private void OnTriggerExit(Collider other)
    {
        Axe.SetActive(false);
    }
}

