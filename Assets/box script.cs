using UnityEngine;

public class boxscript : MonoBehaviour
{
    public GameObject Gun;
    private StartBullet startbullet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startbullet = Gun.GetComponent<StartBullet>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            startbullet.Bullets = 15;
            startbullet.PistolTimer = 1f;
            Destroy(gameObject);
        }
    }
}

