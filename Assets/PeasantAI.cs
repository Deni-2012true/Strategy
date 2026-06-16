using UnityEngine;
using UnityEngine.AI;

public class PeasentAI : MonoBehaviour
{
    public Transform Player;
    private NavMeshAgent agent;

    public Animator PeasentAnimator;

    private Vector3 RandomDirection;
    private float changeDirectionTimer;
    private float maxChange = 14f;
    private float minChange = 12f;

    private float walkTime = 4f;
    private bool isWalking = true;

    private AudioSource audioSource;
    public AudioClip ChopSound;

    private static bool isSummond = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ChangeDirection();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            isSummond = true;
        }
        if (isSummond)
        {
            isWalking = false;
            agent.isStopped = false;

            agent.speed = 3.5f;
            agent.SetDestination(Player.position);
            PeasentAnimator.SetBool("Run", true);
            if (Vector3.Distance(transform.position, Player.position) <= agent.stoppingDistance && Vector3.Distance(transform.position, Player.position) >= 0)
            {
                PeasentAnimator.SetBool("Walk", false);
                PeasentAnimator.SetBool("Run", false);
                isSummond = false;
            }
        }
        else if (Vector3.Distance(transform.position, Player.position) <= agent.stoppingDistance && Vector3.Distance(transform.position, Player.position) >= 0)
        {
            PeasentAnimator.SetBool("Walk", false);
            PeasentAnimator.SetBool("Run", false);
            isSummond = false;
        }
        else
        {
            PeasentAnimator.SetBool("Run", false);
            agent.speed = 1.1f;

            changeDirectionTimer -= Time.deltaTime;

            if (isWalking)
            {
                if (changeDirectionTimer <= (Random.Range(minChange, maxChange) - walkTime))
                {
                    isWalking = false;
                    agent.isStopped = true;
                    PeasentAnimator.SetBool("Walk", false);
                }
                else
                {
                    PeasentAnimator.SetBool("Walk", true);
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
