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
    public GameObject FireBall;
    private float TimerShot = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ChangeDirection();
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerShot > 0)
        {
            //Time.deltaTime = Время одного кадра
            TimerShot -= Time.deltaTime;
            Debug.Log(TimerShot);
        }
            distance = Vector3.Distance(transform.position, player.position);
        if (distance <= 5f && distance >= 2f)
        {
            agent.SetDestination(player.position);
            skeletonAnimator.SetBool("Walk", true);
        }
        else if (distance <= agent.stoppingDistance && TimerShot <= 0f)
        {
            Debug.Log("FireStrart");
            Instantiate(FireBall, transform.position, transform.rotation);
            skeletonAnimator.SetTrigger("Attack");
            skeletonAnimator.SetBool("Walk", false);
            TimerShot = 2f;
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
