using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorCtrl : MonoBehaviour {

    private Animator Ator;
    private MoveAvatar moveAvatar;

    // Use this for initialization
    void Start () {
        Ator = gameObject.GetComponent<Animator>();
        moveAvatar = transform.parent.GetComponent<MoveAvatar>();
        
	}

    // Update is called once per frame
    void Update()
    {
        if (moveAvatar.animationState == MoveAvatar.AvatarAnimationState.Idle)
        {
            if (!Ator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                Ator.SetTrigger("Idle");
            }
        }
        else if (moveAvatar.animationState == MoveAvatar.AvatarAnimationState.Walk)
        {
            if (!Ator.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
            {
                Ator.SetTrigger("Walk");
            }
        }
        else if (moveAvatar.animationState == MoveAvatar.AvatarAnimationState.Run)
        {
            if (!Ator.GetCurrentAnimatorStateInfo(0).IsName("Run"))
            {
                Ator.SetTrigger("Run");
            }
        }
    }

}
