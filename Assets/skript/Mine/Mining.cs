using UnityEngine;
using System.Collections;

public class Mining : MonoBehaviour
{
    public GameObject Axe;      
    public GameObject Pick;     
    public Animator Playercontroler;

    private bool isActionInProgress = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other == null || other.gameObject == null) return;

        if (other.CompareTag("tree") && Axe != null)
            Axe.SetActive(true);

        if ((other.CompareTag("rock") || other.CompareTag("Ore")) && Pick != null)
            Pick.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (Axe != null) Axe.SetActive(false);
        if (Pick != null) Pick.SetActive(false);
        isActionInProgress = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other == null || other.gameObject == null) return;
        if (isActionInProgress) return;

        if (other.CompareTag("tree") && other.enabled)
        {
            if (Input.GetMouseButtonDown(0))
                StartCoroutine(ChopTree(other.gameObject));
        }
        else if (other.CompareTag("rock") && other.enabled)
        {
            if (Input.GetMouseButtonDown(0))
                StartCoroutine(MineRock(other.gameObject));
        }
        else if (other.CompareTag("Ore") && other.enabled)
        {
            if (Input.GetMouseButtonDown(0))
                StartCoroutine(MineOre(other.gameObject));
        }
        else if (other.CompareTag("Herb") && other.enabled)
        {
            if (Input.GetMouseButtonDown(0))
                StartCoroutine(PickHerb(other.gameObject));
        }
    }

    private IEnumerator ChopTree(GameObject treeObj)
    {
        isActionInProgress = true;
        if (Playercontroler != null) Playercontroler.SetTrigger("Chopping");
        yield return new WaitForSeconds(1f);
        if (treeObj != null)
        {
            TreeCut tree = treeObj.GetComponent<TreeCut>();
            if (tree != null) tree.TakeDamage(1);
        }
        isActionInProgress = false;
    }

    private IEnumerator MineRock(GameObject rockObj)
    {
        isActionInProgress = true;
        if (Playercontroler != null) Playercontroler.SetTrigger("Chopping");
        yield return new WaitForSeconds(1f);
        if (rockObj != null)
        {
            RockMine rock = rockObj.GetComponent<RockMine>();
            if (rock != null) rock.TakeDamage(1);
        }
        isActionInProgress = false;
    }

    private IEnumerator MineOre(GameObject oreObj)
    {
        isActionInProgress = true;
        if (Playercontroler != null) Playercontroler.SetTrigger("Chopping");
        yield return new WaitForSeconds(1f);
        if (oreObj != null)
        {
            OreMine ore = oreObj.GetComponent<OreMine>();
            if (ore != null) ore.TakeDamage(1);
        }
        isActionInProgress = false;
    }

    private IEnumerator PickHerb(GameObject herbObj)
    {
        isActionInProgress = true;
        if (Playercontroler != null) Playercontroler.SetTrigger("Chopping");
        yield return new WaitForSeconds(1f);
        if (herbObj != null)
        {
            HerbPick herb = herbObj.GetComponent<HerbPick>();
            if (herb != null) herb.TakeDamage(1);
        }
        isActionInProgress = false;
    }
}