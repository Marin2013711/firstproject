using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float SpeedWalk = 5f;
    public Animator monsterAnimator;
    private float TimerStop = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && TimerStop <= 0)
        {
            transform.Translate(new Vector3(0, 0, 1) * SpeedWalk * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) && TimerStop <= 0)
        {
            transform.Translate(new Vector3(0, 0, -1) * SpeedWalk * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) && TimerStop <= 0)
        {
            transform.Translate(new Vector3(1, 0, 0) * SpeedWalk * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) && TimerStop <= 0)
        {
            transform.Translate(new Vector3(-1, 0, 0) * SpeedWalk * Time.deltaTime);
        }
        if ((Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.E)) || (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.E)) ||
            (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.E)) || (Input.GetKey(KeyCode.D)) && Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.E))
        {
            SpeedWalk = 0;
            TimerStop = 1;
        }
        else
        {
            SpeedWalk = 5;
        }
        if (TimerStop > 0)
        {
            TimerStop -= Time.deltaTime;
        }
    }
}
