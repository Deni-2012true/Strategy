using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class PeasentJob : MonoBehaviour
{
    public NavMeshAgent agent;
    public Radar radar;
    public PeasentAI AIPeasent;
    public float Timer;

    public GameObject Axe;
    public GameObject Pick;
    public Animator Playercontroler;

    private bool isActionInProgress = false;

    public float TreeTime = 4f;

    void Start()
    {
        AIPeasent = GetComponent<PeasentAI>();
        radar = GetComponent<Radar>();
        agent = GetComponent<NavMeshAgent>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other == null || other.gameObject == null) return;

        if (other.CompareTag("tree") && Axe != null)
            Axe.SetActive(true);

        if ((other.CompareTag("rock") || other.CompareTag("Ore")) && Pick != null)
            Pick.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
        if (Axe != null) Axe.SetActive(false);
        if (Pick != null) Pick.SetActive(false);
        isActionInProgress = false;
        //Debug.Log("Вышел из зоны!");
    }

    void OnTriggerStay(Collider other)
    {
        if (radar == null) return;

        if (radar.inFind == false && Vector3.Distance(transform.position, radar.treePosition) <= 2f)
        {
            if (other == null || other.gameObject == null) return;

            if (isActionInProgress) return;

            if (other.CompareTag("tree") && other.enabled)
            {
                StartCoroutine(ChopTree(other.gameObject));
            }
            else if (other.CompareTag("rock") && other.enabled)
            {
                StartCoroutine(MineRock(other.gameObject));
            }
            else if (other.CompareTag("Ore") && other.enabled)
            {
                StartCoroutine(MineOre(other.gameObject));
            }
            else if (other.CompareTag("Herb") && other.enabled)
            {
                StartCoroutine(PickHerb(other.gameObject));
            }
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
        yield return new WaitForSeconds(1.2f);
        isActionInProgress = false;
    }

    private IEnumerator MineRock(GameObject rockObj)
    {
        isActionInProgress = true;
        if (Playercontroler != null) Playercontroler.SetTrigger("Mining");
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
        if (Playercontroler != null) Playercontroler.SetTrigger("Mining");
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
        if (Playercontroler != null) Playercontroler.SetTrigger("Picking");
        yield return new WaitForSeconds(1f);
        if (herbObj != null)
        {
            HerbPick herb = herbObj.GetComponent<HerbPick>();
            if (herb != null) herb.TakeDamage(1);
        }
        isActionInProgress = false;
    }

    public void Update()
    {
        if (AIPeasent == null) AIPeasent = GetComponent<PeasentAI>();
        if (radar == null) radar = GetComponentInChildren<Radar>();
        if (agent == null) agent = GetComponent<NavMeshAgent>();

        if (agent == null || radar == null || AIPeasent == null) return;

        AIPeasent.enabled = !isActionInProgress;

        if (radar.inFind) return;

        if (radar.currentTarget == null || !radar.currentTarget.activeInHierarchy)
        {
            radar.ResetRadar();
            return;
        }


        agent.SetDestination(radar.treePosition);
        Debug.Log("Игрок идёт к дереву.");
    }
}