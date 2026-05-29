using UnityEngine;
using System.Collections;

public class Mining : MonoBehaviour
{
    public GameObject Axe;
    public GameObject AxeIcon;
    public GameObject Pick;
    public GameObject PickIcon;
    public GameObject PickIcon2;

    public Animator Playercontroler;

    private bool isActionInProgress = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("tree"))
        {
            Axe.SetActive(true);
        }
        if (other.CompareTag("rock") || other.CompareTag("Ore"))
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
        isActionInProgress = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (isActionInProgress) return;

        if (other.CompareTag("tree"))
        {
            AxeIcon.SetActive(true);
            if (Input.GetMouseButtonDown(0))
                StartCoroutine(ChopTree());
        }
        else if (other.CompareTag("rock"))
        {
            PickIcon.SetActive(true);
            if (Input.GetMouseButtonDown(0))
                StartCoroutine(MineRock());
        }
        else if (other.CompareTag("Ore"))
        {
            PickIcon2.SetActive(true);
            if (Input.GetMouseButtonDown(0))
                StartCoroutine(MineOre());
        }
        else if (other.CompareTag("Herb"))
        {
            //добавить иконку травы
            if (Input.GetMouseButtonDown(0))
                StartCoroutine(PickHerb());
        }
    }

    private IEnumerator ChopTree()
    {
        isActionInProgress = true;
        Playercontroler.SetTrigger("Chopping");
        yield return new WaitForSeconds(2.8f);
        TreeCut.TreeHP -= 1;
        isActionInProgress = false;
    }

    private IEnumerator MineRock()
    {
        isActionInProgress = true;
        Playercontroler.SetTrigger("Mining");
        yield return new WaitForSeconds(1f);
        RockMine.RockHP -= 1;
        isActionInProgress = false;
    }

    private IEnumerator MineOre()
    {
        isActionInProgress = true;
        Playercontroler.SetTrigger("Mining");
        yield return new WaitForSeconds(1f);
        OreMine.OreHP -= 1;
        isActionInProgress = false;
    }

    private IEnumerator PickHerb()
    {
        isActionInProgress = true;
        Playercontroler.SetTrigger("Picking");
        yield return new WaitForSeconds(1f);
        picking.HerbHP -= 1;
        isActionInProgress = false;
    }
}