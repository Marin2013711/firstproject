using UnityEngine;
using UnityEngine.UI;

public class FireMove : MonoBehaviour
{
    public float speed = 1f;
    public Transform target;
    public Slider HPslider;
    public GameObject GameOver;
    public Transform Skeleton;
    private Vector3 FixedTarget;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FixedTarget = target.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, FixedTarget, speed * Time.deltaTime);
    }
    void OnCollisionEnter(Collision collision)
    { 
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Столкновение с игроком");
                Health.health -= 10;
                Debug.Log(Health.health);
                HPslider.value = Health.health;
            if (Health.health <= 0f)
            {
                GameOver.SetActive(true);
            }
            transform.position = Skeleton.position;
        }
    }
}
