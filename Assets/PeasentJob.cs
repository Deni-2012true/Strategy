using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class PeasentJob : MonoBehaviour
{
    public NavMeshAgent AIPeasent;
    public float Timer;

    public GameObject Axe;
    public GameObject Pick;
    public Animator Playercontroler;

    private AudioSource audioSource;

    public AudioClip PickMiningSound;
    public AudioClip AxeCutSound;
    public AudioClip PickingSound;

    private bool isActionInProgress = false;

    public float TreeTime = 4f;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        AIPeasent = GetComponent<NavMeshAgent>();
    }

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
        //AIPeasent.enabled = true;
        if (Axe != null) Axe.SetActive(false);
        if (Pick != null) Pick.SetActive(false);
        isActionInProgress = false;
        Debug.Log("Вышел из зоны!");
    }

    private void OnTriggerStay(Collider other)
    {
        //TreeTimer();
        if (other == null || other.gameObject == null) return;
        //AIPeasent.enabled = false;
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
        if (isActionInProgress)
        {
            AIPeasent.enabled = false;
        }
        else
        {
            AIPeasent.enabled = true;
        }

        //    public void TreeTimer()
        //   {
        //     if (Timer > 0)
        //    {
        //          Timer -= Time.deltaTime;

        //      }
        //       else if (Timer <= 0)
        //       {
        //          Timer = 4f;
        //           AIPeasent.enabled = true;
        //       }
        //      Debug.Log(Timer);
        //  }
    }
}