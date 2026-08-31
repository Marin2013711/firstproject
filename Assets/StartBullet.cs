using UnityEngine;
using TMPro;

public class StartBullet : MonoBehaviour
{
    public GameObject Bullet;
    public Transform Gun;
    public float PistolTimer = 0f;
    public int MaxBullet = 15;
    public int Bullets = 15;
    public TextMeshProUGUI BulletText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BulletText.text = Bullets.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Bullets <= 0)
        {
            PistolTimer = 999999999999999f;
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            PistolTimer = 1f;
            Bullets = 15;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (PistolTimer <= 0)
            {
                Instantiate(Bullet, Gun.position, Gun.rotation);
                PistolTimer = 1f;
                Bullets -= 1;
            }
        }
        if (PistolTimer > 0)
        {
            BulletText.text = Bullets.ToString();
            PistolTimer -= Time.deltaTime; 
        }
    }
}