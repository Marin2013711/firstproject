using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 1, 0) * Speed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Skeleton"))
        {
            Destroy(gameObject);
        }
    }
}