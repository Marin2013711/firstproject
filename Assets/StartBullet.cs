using UnityEngine;

public class StartBullet : MonoBehaviour
{
    public GameObject Bullet;
    public Transform Gun;
    public float PistolTimer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PistolTimer = 0.5f;
        }
        if (PistolTimer > 0)
        {
            PistolTimer -= Time.deltaTime; 
        }
        if (PistolTimer <= 0)
        {
            Instantiate(Bullet, Gun.position, Gun.rotation);
        }
    }
}