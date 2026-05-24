using UnityEngine;
using UnityEngine.AI;

public class AIDog : MonoBehaviour
{
    public Transform Player;
    private NavMeshAgent agent;

    public Animator WolfAnimator;

    private Vector3 RandomDirection;
    private float changeDirectionTimer;
    private float maxChange = 8f;
    private float minChange = 6f;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ChangeDirection();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, Player.position) <= 6)
        {
            agent.SetDestination(Player.position);
            WolfAnimator.SetBool("Walk", true);
        } 
        else
        {
            changeDirectionTimer -= Time.deltaTime;
            if (changeDirectionTimer <= 0)
            {
                ChangeDirection();
            }
            agent.SetDestination(transform.position + RandomDirection);
        }
    }

    void ChangeDirection()
    {
       RandomDirection = Random.insideUnitSphere * 10f;
       changeDirectionTimer = Random.Range(minChange, maxChange);
    }
}
