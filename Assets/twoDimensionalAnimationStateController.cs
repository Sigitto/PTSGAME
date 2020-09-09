using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class twoDimensionalAnimationStateController : MonoBehaviour
{
    Animator animator;
    float velocityX = 0.0f;
    float velocityZ = 0.0f;
    public float acceleration = 2.0f;
    public float decelarition = 2.0f;
    public float maxSpeed = 0.0f;
    public CapsuleCollider playerCollider;

    private GameObject enemy;
    private Enemy enemyScript;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        playerCollider = this.GetComponent<CapsuleCollider>();
        playerCollider.height = 1f;
        playerCollider.center = new Vector3(0f, 0.5f, 0f);

        //enemy = GameObject.Find("Enemy");
        //enemyScript = enemy.GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        //Move(x, y);

        bool forwardPressed = Input.GetKey("w");
        bool leftPressed = Input.GetKey("a");
        bool rightPressed = Input.GetKey("d");
        bool runPressed = Input.GetKey("left shift");

        if (forwardPressed && velocityZ < 0.5f && !runPressed)
        {
            velocityZ += Time.deltaTime * acceleration;
        }

        if (rightPressed && velocityX < 0.5f && !runPressed)
        {
            velocityX += Time.deltaTime * acceleration;
        }

        if (leftPressed && velocityX > -0.5f && !runPressed)
        {
            velocityX -= Time.deltaTime * acceleration;
        }


        if(!forwardPressed && velocityZ > 0.0f)
        {
            velocityZ -= Time.deltaTime * decelarition;
        }

        if(!forwardPressed && velocityZ < 0.0f)
        {
            velocityZ = 0.0f;
        }

        if (!leftPressed && velocityX < 0.0f)
        {
            velocityX += Time.deltaTime * decelarition;
        }

        if (!rightPressed && velocityZ > 0.0f)
        {
            velocityX -= Time.deltaTime * decelarition;
        }

        if(!leftPressed && !rightPressed && velocityX != 0.0f && (velocityX > -0.05f && velocityX < 0.05f))
        {
            velocityX = 0.0f;
        }
        animator.SetFloat("Velocity Z", velocityZ);
        animator.SetFloat("Velocity X", velocityX);

        transform.position += (Vector3.forward * maxSpeed) * y * Time.deltaTime;
        transform.position += (Vector3.right * maxSpeed) * x * Time.deltaTime;

    }

        void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            enemyScript = collision.gameObject.GetComponent<Enemy>();
            enemyScript.enemyHealth--;

            if (enemyScript.enemyHealth == 0)
            {
                Destroy(enemyScript.gameObject);
            }
        }
    }

    /*private void Move(float x, float y)
    {
        animator.SetFloat("Velocity Z", x);
        animator.SetFloat("Velocity X", y);

        transform.position += (Vector3.forward * maxSpeed) * y * Time.deltaTime;
        transform.position += (Vector3.right * maxSpeed)* x * Time.deltaTime;
    }*/
}
