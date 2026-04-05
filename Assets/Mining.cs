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
        Player.Chopping = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("tree"))
        {
            if (Player.Chopping == true)
            {
                TreeCut.HP -= 1;
                Player.Chopping = false;
            }
        } 
    }

}


//OnTriggerStay