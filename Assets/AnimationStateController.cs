using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
   // float velocity = 0.0f;
    public float acceleration = 0.1f;
    public float deceleration = 0.5f;
    int VelocityHash;
    int isWalkingHash;
    int isRunningHash;
    public CapsuleCollider playerCollider;
    //public float moveSpeed = 5;
    //public static int movespeed = 1;
    //public Vector3 userDirection = Vector3.right;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        VelocityHash = Animator.StringToHash("Velocity");

        playerCollider = this.GetComponent<CapsuleCollider>();
        playerCollider.height = 1f;
        playerCollider.center = new Vector3(0f, 0.5f, 0f);

    }

    // Update is called once per frame
    void Update()
    {
        bool isRunning = animator.GetBool("isRunning"); //false
        bool isWalking = animator.GetBool("isWalking"); //false
        bool forwardPressed = Input.GetKey("w");
        bool runningPressed = Input.GetKey("left shift");

        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");
        

        if (forwardPressed && !isWalking )
        {
            animator.SetBool(isWalkingHash, true);
         

        }

        if (!forwardPressed && isWalking)
        {
            animator.SetBool(isWalkingHash, false);
        }

        if ((forwardPressed && runningPressed) && !isRunning)
        {
            animator.SetBool(isRunningHash, true);
        }

        if ((!forwardPressed || !runningPressed) && isRunning)
        {
            animator.SetBool(isRunningHash, false);
        }
    }
}
