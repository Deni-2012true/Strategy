using UnityEngine;

public class Mining : MonoBehaviour
{
    public GameObject Axe;
    public GameObject AxeIcon;
    public GameObject Pick;
    public GameObject PickIcon;
    public GameObject PickIcon2;

    public static bool Chopping = false;
    public static bool Mining1 = false;
    public static bool OreMining = false;
    public static bool HerbPick = false;

    public Animator Playercontroler;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("tree"))
        {
            Debug.Log("Игрок вошел в зону!");
            Axe.SetActive(true);
        } 
        if (other.gameObject.CompareTag("rock"))
        {
            Pick.SetActive(true);
        } 
        if (other.gameObject.CompareTag("Ore"))
        {
            Pick.SetActive(true);
        } 
    }
    
    private void OnTriggerExit(Collider other)
    {
        Axe.SetActive(false);
        AxeIcon.SetActive(false);
        Pick.SetActive(false);
        PickIcon.SetActive(false);
        PickIcon2.SetActive(false);
        Chopping = false;
        Mining1 = false;
        OreMining = false;
        HerbPick = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("tree"))
        {
            AxeIcon.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                Playercontroler.SetTrigger("Chopping");
                yield return new WaitForSeconds(1f);
                Chopping = true;
            
            }
            if (Chopping == true)
            {
                TreeCut.TreeHP -= 1;
                Chopping = false;
            }
        } 
        if (other.gameObject.CompareTag("rock"))
        {
            PickIcon.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                Playercontroler.SetTrigger("Chopping");
                yield return new WaitForSeconds(1f);
                Mining1 = true;
            
            }
            if (Mining1 == true)
            {
                RockMine.RockHP -= 1;
                Mining1 = false;
            }
        } 
        if (other.gameObject.CompareTag("Ore"))
        {
            PickIcon2.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                Playercontroler.SetTrigger("Chopping");
                yield return new WaitForSeconds(1f);
                OreMining = true;
               
            }
            if (OreMining == true)
            {
                OreMine.OreHP -= 1;
                OreMining = false;
            }
        } 
        if (other.gameObject.CompareTag("Herb"))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Playercontroler.SetTrigger("Chopping");
                yield return new WaitForSeconds(1f);
                HerbPick = true;
            }
            if (HerbPick == true)
            {
                picking.HerbHP -= 1;
                HerbPick = false;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Playercontroler.SetTrigger("Chopping");
            yield return new WaitForSeconds(1f);
            Chopping = true;
        }
    }

}