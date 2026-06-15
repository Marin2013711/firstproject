using UnityEngine;

public class FireMove : MonoBehaviour
{
    public float speed = 1f;
    public Transform target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
    void OnCollisionEnter(Collision collision)    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Столкновение с игроком");
        }
    }
}
