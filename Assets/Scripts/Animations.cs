using UnityEngine;

public class Animations : MonoBehaviour
{
    private Animator anim;
    public PlayerController controller;
    public Hp hp;
    public bool isPunching = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (controller.moveX != 0f)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        anim.SetBool("isJumping", !controller.grounded);

        anim.SetBool("isDashing", controller.dash);

        if (controller.hitCD && !isPunching && controller.moveX == 0f)
        {
            anim.SetBool("isPunching", true);
            isPunching = true;
            Invoke("StopPunch", 0.35f);
            controller.hitCD = false;
        }

        if(hp.HP <= 0)
        {
            anim.SetBool("isDied", true);
        }
    }

    void StopPunch()
    {
        isPunching = false;
        anim.SetBool("isPunching", false);
    }
}
