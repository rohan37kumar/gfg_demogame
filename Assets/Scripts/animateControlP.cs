using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animateControlP : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool forP = Input.GetKey("w");
        bool backP = Input.GetKey("s");
        bool leftP = Input.GetKey("a");
        bool rightP = Input.GetKey("d");
        bool isWalk = animator.GetBool("isWalking");
        bool runP = Input.GetKey("left shift");
        bool atk = Input.GetKey("right shift");
        bool isRun = animator.GetBool("isRunning");

        if (atk)
        {
            animator.SetBool("isatk", true);
        }
        if (!atk)
        {
            animator.SetBool("isatk", false);
        }

        if (!isWalk && (forP||backP||leftP||rightP))
        {
            animator.SetBool("isWalking", true);
        }
        if (isWalk && !(forP || backP || leftP || rightP))
        {
            animator.SetBool("isWalking", false);
        }

        if(!isRun && (forP && runP))
        {
            animator.SetBool("isRunning", true);
        }
        if(isRun && (!forP || !runP))
        {
            animator.SetBool("isRunning", false);
        }

        
    }
}
