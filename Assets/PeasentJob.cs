using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class PeasentJob : MonoBehaviour
{
    public enum Profession
    {
        Woodcutter,
        Mason,
        Herbalist,
        Hunter
    }
    public Profession profession = Profession.Woodcutter;

    public bool Woodcutter = false;
    public bool Mason = false;
    public bool Hanter = false;
    public bool Herbalist = false;

    public NavMeshAgent agent;
    public Radar radar;
    public PeasentAI AIPeasent;
    public float Timer;

    public GameObject Axe;
    public GameObject Pick;
    public Animator Playercontroler;

    private bool isActionInProgress = false;

    void Start()
    {
        AIPeasent = GetComponent<PeasentAI>();
        radar = GetComponentInChildren<Radar>();
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
    }

    void OnTriggerStay(Collider other) { }

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
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Woodcutter = true;
            Mason = false;
            Hanter = false;
            Herbalist = false;
            Debug.Log("Дровосек");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Woodcutter = false;
            Mason = true;
            Hanter = false;
            Herbalist = false;
            Debug.Log("Шахтёр");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Woodcutter = false;
            Mason = false;
            Hanter = true;
            Herbalist = false;
            Debug.Log("Охотник");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Woodcutter = false;
            Mason = false;
            Hanter = false;
            Herbalist = true;
            Debug.Log("Собиратель трав");
        }

        if (AIPeasent == null) AIPeasent = GetComponent<PeasentAI>();
        if (radar == null) radar = GetComponentInChildren<Radar>();
        if (agent == null) agent = GetComponent<NavMeshAgent>();

        if (agent == null || radar == null || AIPeasent == null) return;

        AIPeasent.enabled = false;

        if (Woodcutter) radar.targetTag = "tree";
        else if (Mason) radar.targetTag = "rock";
        else if (Hanter) radar.targetTag = "Animal";
        else if (Herbalist) radar.targetTag = "Herb";
        else radar.targetTag = "tree";

        if (radar.inFind)
        {
            isActionInProgress = true;
            return;
        }

        if (radar.currentTarget == null || !radar.currentTarget.activeInHierarchy)
        {
            radar.ResetRadar();
            return;
        }

        if (agent.remainingDistance > agent.stoppingDistance + 0.1f || agent.pathPending)
        {
            Debug.Log(radar.targetPosition);
            agent.SetDestination(radar.targetPosition);
            return;
        }

        if (!isActionInProgress)
        {
            string tag = radar.currentTarget.tag;
            switch (tag)
            {
                case "tree":
                    StartCoroutine(ChopTree(radar.currentTarget));
                    break;
                case "rock":
                    StartCoroutine(MineRock(radar.currentTarget));
                    break;
                case "Ore":
                    StartCoroutine(MineOre(radar.currentTarget));
                    break;
                case "Herb":
                    StartCoroutine(PickHerb(radar.currentTarget));
                    break;
                default:
                    Debug.LogWarning("Неизвестный ресурс: " + tag);
                    radar.ResetRadar();
                    break;
            }
        }
    }
}