using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class skeleton : MonoBehaviour
{
    public Animator skeletonAnimator;
    public Transform player;
    private NavMeshAgent agent;
    private Vector3 randomDirection;
    private float changeDirectionTimer;
    private float minChange = 3f;
    private float maxChange = 8f;
    private float distance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ChangeDirection();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.position);
        if (distance <= 5f && distance >= 2f)
        {
            agent.SetDestination(player.position);
            skeletonAnimator.SetBool("Walk", true);
        }
        else if (distance < 2f && distance >= 0f)
        {
            skeletonAnimator.SetTrigger("Attack");
            skeletonAnimator.SetBool("Walk", false);
        }
        else
        {
            changeDirectionTimer -= Time.deltaTime;
            if (changeDirectionTimer <= 0f)
            {
                ChangeDirection();
            }
            agent.SetDestination(transform.position + randomDirection);
        }
    }

    void ChangeDirection()
    {
        randomDirection = Random.insideUnitSphere * 10f;
        changeDirectionTimer = Random.Range(minChange, maxChange);
    }
}
