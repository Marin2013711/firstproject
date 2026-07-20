using UnityEngine;
using UnityEngine.UI;

public class FireMove : MonoBehaviour
{
    public float speed = 5f;
    public Transform target;
    public Slider HPslider;
    public GameObject GameOver;
    public Transform Skeleton;
    private Vector3 FixedTarget;
    private float DestroyTimer = 2f;
    public GameObject Fire;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FixedTarget = target.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (DestroyTimer == 2)
        {
            FixedTarget = target.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, FixedTarget, speed * Time.deltaTime);
        DestroyTimer -= Time.deltaTime;
        if (DestroyTimer <= 0)
        {
            transform.position = Skeleton.position;
            DestroyTimer = 2;
            Fire.SetActive(false);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FixedTarget = target.position;
            Debug.Log("Столкновение с игроком");
            Health.health -= 10;
            Debug.Log(Health.health);
            HPslider.value = Health.health;
            //Destroy(gameObject);
            transform.position = Skeleton.position;
            if (Health.health <= 0f)
            {
                GameOver.SetActive(true);
            }
        }
    }
}