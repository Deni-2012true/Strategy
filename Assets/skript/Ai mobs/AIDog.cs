using UnityEngine;
using UnityEngine.AI;

public class AIDog : MonoBehaviour
{
    public Transform Player;
    private NavMeshAgent agent;

    public Animator WolfAnimator;

    private Vector3 RandomDirection;
    private float changeDirectionTimer;
    private float maxChange = 14f;
    private float minChange = 12f;

    private float walkTime = 4f;
    private bool isWalking = true;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ChangeDirection();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, Player.position) <= 6 && Vector3.Distance(transform.position, Player.position) > agent.stoppingDistance)
        {
            isWalking = true; 
            agent.isStopped = false;

            agent.speed = 3.5f;
            agent.SetDestination(Player.position);
            WolfAnimator.SetBool("Run", true);
        }  
        else if (Vector3.Distance(transform.position, Player.position) <= agent.stoppingDistance && Vector3.Distance(transform.position, Player.position) >= 0)
        {
            WolfAnimator.SetBool("Walk", false);
            WolfAnimator.SetBool("Run", false);
            WolfAnimator.SetTrigger("Attack");
        }  
        else
        {
            WolfAnimator.SetBool("Run", false);
            agent.speed = 1.1f;
            
            changeDirectionTimer -= Time.deltaTime;

            if (isWalking)
            {
                if (changeDirectionTimer <= (Random.Range(minChange, maxChange) - walkTime))
                {
                    isWalking = false;
                    agent.isStopped = true;
                    WolfAnimator.SetBool("Walk", false);
                }
                else
                {
                    WolfAnimator.SetBool("Walk", true);
                    agent.SetDestination(transform.position + RandomDirection);
                }
            }

            if (changeDirectionTimer <= 0)
            {
                ChangeDirection();
            }
        }
    }

    void ChangeDirection()
    {
       RandomDirection = Random.insideUnitSphere * 10f;
       changeDirectionTimer = Random.Range(minChange, maxChange);
       isWalking = true;
       agent.isStopped = false;
    }
}
