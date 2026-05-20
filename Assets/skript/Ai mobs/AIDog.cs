using UnityEngine;
using UnityEngine.AI;

public class AIDog : MonoBehaviour
{
    public Transform Player;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.SetDestination(Player.position);
    }
}
