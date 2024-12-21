using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator playerAnimator;
    public Rigidbody playerRigid;
    public float speed = 120f, w_speed = 120f, rn_speed = 160f, ro_speed = 90f;
    
    public bool walking;
    public bool walkingBackwards;

    public Transform playerTransform;

    public KeyCode moveForward = KeyCode.W;
    public KeyCode moveBackwards = KeyCode.S;

    public KeyCode turnLeft = KeyCode.A;
    public KeyCode turnRight = KeyCode.D;

    public KeyCode sprintKey = KeyCode.LeftShift;

    void FixedUpdate()
    {
        if (Input.GetKey(moveForward))
        {
            playerRigid.velocity = transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(moveBackwards))
        {
            playerRigid.velocity = -transform.forward * ((speed/4)*3) * Time.deltaTime;
        }
    }

    void Update()
    {
//      Forward/Backward movement
        if (Input.GetKeyDown(moveForward))
        {
            playerAnimator.SetTrigger("jog");
            playerAnimator.ResetTrigger("idle");
            walking = true;
        }
        if (Input.GetKeyUp(moveForward))
        {
            playerAnimator.ResetTrigger("jog");
            playerAnimator.SetTrigger("idle");
            walking = false;
        }
        if (Input.GetKeyDown(moveBackwards))
        {
            playerAnimator.SetTrigger("backjog");
            playerAnimator.ResetTrigger("idle");
            walking = true;
            walkingBackwards = true;
        }
        if (Input.GetKeyUp(moveBackwards))
        {
            playerAnimator.ResetTrigger("backjog");
            playerAnimator.SetTrigger("idle");
            walking = false;
            walkingBackwards = false;
        }

//      Rotation
        if (Input.GetKey(turnLeft))
        {
            playerTransform.Rotate(0, -ro_speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(turnRight))
        {
            playerTransform.Rotate(0, ro_speed * Time.deltaTime, 0);
        }

//      Sprint/Jog Cycle
        if (Input.GetKeyDown(sprintKey) && !walkingBackwards && walking)
        {
            speed = rn_speed;
            playerAnimator.SetTrigger("sprint");
            playerAnimator.ResetTrigger("jog");
        }
        if (Input.GetKeyUp(sprintKey) && !walkingBackwards && walking)
        {
            speed = w_speed;
            playerAnimator.ResetTrigger("sprint");
            playerAnimator.SetTrigger("jog");
        }
    }
}