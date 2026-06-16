using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public enum SavageProfession
{
    Woodcutter,
    StoneMason,
    HerbGatherer
}

public class SavageWorker : MonoBehaviour
{
    public SavageProfession profession = SavageProfession.Woodcutter;
    public float attackRange = 2.5f;
    public float attackDelay = 1f;
    public float searchRadius = 30f;
    public LayerMask resourceLayer;
    public Animator animator;
    public NavMeshAgent agent;
    public AudioSource audioSource;
    public AudioClip attackSound;

    private Transform currentTarget;
    private bool isAttacking = false;
    private string[] targetTags;

    void Start()
    {
        if (agent == null) agent = GetComponent<NavMeshAgent>();
        if (animator == null) animator = GetComponent<Animator>();
        if (audioSource == null) audioSource = GetComponent<AudioSource>();

        switch (profession)
        {
            case SavageProfession.Woodcutter:
                targetTags = new string[] { "tree" };
                break;
            case SavageProfession.StoneMason:
                targetTags = new string[] { "rock", "Ore" };
                break;
            case SavageProfession.HerbGatherer:
                targetTags = new string[] { "Herb" };
                break;
        }

        StartCoroutine(BehaviorLoop());
    }

    void Update()
    {
        if (currentTarget != null && !isAttacking)
        {
            float distance = Vector3.Distance(transform.position, currentTarget.position);
            if (distance <= attackRange)
            {
                StartCoroutine(PerformAttack());
            }
            else
            {
                agent.isStopped = false;
                agent.SetDestination(currentTarget.position);
            }
        }
    }

    IEnumerator BehaviorLoop()
    {
        while (true)
        {
            if (currentTarget == null && !isAttacking)
            {
                FindClosestResource();
            }

            if (currentTarget != null && (currentTarget.gameObject == null || !currentTarget.gameObject.activeSelf))
            {
                currentTarget = null;
                agent.ResetPath();
            }

            yield return new WaitForSeconds(0.5f);
        }
    }

    void FindClosestResource()
    {
        GameObject[] allResources = null;
        foreach (string tag in targetTags)
        {
            GameObject[] tagged = GameObject.FindGameObjectsWithTag(tag);
            if (allResources == null)
                allResources = tagged;
            else
            {
                GameObject[] combined = new GameObject[allResources.Length + tagged.Length];
                allResources.CopyTo(combined, 0);
                tagged.CopyTo(combined, allResources.Length);
                allResources = combined;
            }
        }

        if (allResources == null || allResources.Length == 0) return;

        Transform closest = null;
        float closestDistance = searchRadius + 1f;

        foreach (GameObject res in allResources)
        {
            if (res == null) continue;
            float dist = Vector3.Distance(transform.position, res.transform.position);
            if (dist < closestDistance)
            {
                closestDistance = dist;
                closest = res.transform;
            }
        }

        if (closest != null && closestDistance <= searchRadius)
        {
            currentTarget = closest;
        }
    }

    IEnumerator PerformAttack()
    {
        if (isAttacking) yield break;
        isAttacking = true;

        agent.isStopped = true;
        agent.ResetPath();

        Vector3 direction = (currentTarget.position - transform.position).normalized;
        direction.y = 0;
        if (direction != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(direction);

        if (animator != null)
        {
            switch (profession)
            {
                case SavageProfession.Woodcutter:
                    animator.SetTrigger("Chopping");
                    break;
                case SavageProfession.StoneMason:
                    animator.SetTrigger("Mining");
                    break;
                case SavageProfession.HerbGatherer:
                    animator.SetTrigger("Picking");
                    break;
            }
        }

        if (audioSource != null && attackSound != null)
            audioSource.PlayOneShot(attackSound);

        yield return new WaitForSeconds(attackDelay);

        if (currentTarget != null && currentTarget.gameObject != null)
        {
            var damageable = currentTarget.GetComponent<IMineable>();
            if (damageable != null)
            {
                damageable.TakeDamage(1);
            }
            else
            {
                var method = currentTarget.GetComponent<System.Type>().GetMethod("TakeDamage");
                if (method != null)
                    method.Invoke(currentTarget.GetComponent<Component>(), new object[] { 1 });
            }

            if (currentTarget.gameObject == null || !currentTarget.gameObject.activeSelf)
            {
                currentTarget = null;
            }
        }

        yield return new WaitForSeconds(0.2f);

        agent.isStopped = false;
        isAttacking = false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, searchRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}

public interface IMineable
{
    void TakeDamage(int damage);
}