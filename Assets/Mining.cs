using UnityEngine;

public class Mining : MonoBehaviour
{
    public GameObject Axe;
    public GameObject AxeIcon;
    public GameObject Pick;
    public GameObject PickIcon;
    public GameObject PickIcon2;


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
        Player.Chopping = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("tree"))
        {
            AxeIcon.SetActive(true);
            if (Player.Chopping == true)
            {
                TreeCut.HP -= 1;
                Player.Chopping = false;
            }
        } 
        if (other.gameObject.CompareTag("rock"))
        {
            PickIcon.SetActive(true);
            if (Player.Mining == true)
            {
                RockMine.RockHP -= 1;
                Player.Mining = false;
            }
        } 
        if (other.gameObject.CompareTag("Ore"))
        {
            PickIcon2.SetActive(true);
            if (Player.OreMining == true)
            {
                OreMine.OreHP -= 1;
                Player.OreMining = false;
            }
        } 
        if (other.gameObject.CompareTag("Herb"))
        {
            if (Player.HerbPick == true)
            {
                picking.HerbHP -= 1;
                Player.HerbPick = false;
            }
        }
    }

}