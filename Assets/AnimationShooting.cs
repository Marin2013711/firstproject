using UnityEngine;

public class AnimationShooting : MonoBehaviour
{
    public Animator monsterAnimator;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            monsterAnimator.SetBool("walking", true);
        }else if (Input.GetKeyDown(KeyCode.E))
        {
            monsterAnimator.SetTrigger("shooting");
        }
        else
        {
            monsterAnimator.SetBool("walking", false);
        }
    }
}