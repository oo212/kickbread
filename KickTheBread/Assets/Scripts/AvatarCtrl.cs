using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarCtrl : MonoBehaviour
{

    private Animator animator;

    private MoveAvatar moveAvatar;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        moveAvatar = transform.parent.GetComponent<MoveAvatar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveAvatar.animationState == MoveAvatar.AvatarAnimationState.Idle)
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                animator.SetTrigger("Idle");
            }
        }
        else if (moveAvatar.animationState == MoveAvatar.AvatarAnimationState.Walk)
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
            {
                animator.SetTrigger("Walk");
            }
        }
        else if (moveAvatar.animationState == MoveAvatar.AvatarAnimationState.Run)
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Run"))
            {
                animator.SetTrigger("Run");
            }
        }
    }
}
