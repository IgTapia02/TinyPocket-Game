using UnityEngine;
using UnityEngine.AI;

public class Enemy_Slime : MonoBehaviour
{
    [SerializeField]
    Transform player;
    [SerializeField]
    float detectionRadius = 0.01f;
    [SerializeField]
    bool patrol;
    [SerializeField]
    Vector3[] patrolPoints;
    [SerializeField]
    float waitTime = 2f;

    Vector3 initialPosition;
    NavMeshAgent agent;
    bool isPlayerInRange;

    int currentPatrolIndex;
    float patrolWaitTimer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        initialPosition = transform.position;

        currentPatrolIndex = 0;
        patrolWaitTimer = waitTime;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceToPlayer <= detectionRadius)
        {       
            if (!isPlayerInRange)
            {
                isPlayerInRange = true;
                agent.isStopped = false;
            }
            agent.SetDestination(player.position);
        }
        else
        {
            if (isPlayerInRange)
            {
                isPlayerInRange = false;
            }

            if (patrol)
            {
                Patrol();
            }
            else
            {
                agent.SetDestination(initialPosition);
            }

            
        }
    }

    void Patrol()
    {
        if (patrolPoints.Length == 0)
        {
            patrol = false;
            return;
        }

        if (agent.remainingDistance < 0.001f && !agent.pathPending)
        {
            patrolWaitTimer -= Time.deltaTime;
            if (patrolWaitTimer <= 0f)
            {
                currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
                agent.SetDestination(patrolPoints[currentPatrolIndex]);
                patrolWaitTimer = waitTime;
            }
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
