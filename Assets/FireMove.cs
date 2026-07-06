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
    private Vector3 FireStart;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FixedTarget = target.position;
        FireStart = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, FixedTarget, speed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Столкновение с игроком");
            Health.health -= 10;
            Debug.Log(Health.health);
            HPslider.value = Health.health;
            gameObject.SetActive(false);
            if (Health.health <= 0f)
            {
                GameOver.SetActive(true);
            }
            transform.position = FireStart;
        }
    }
}