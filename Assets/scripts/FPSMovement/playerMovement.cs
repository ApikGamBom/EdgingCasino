using UnityEngine;

public class playerMovement : MonoBehaviour
{

    #region Variables

    [Header("Movement")]
    public Transform playerPosition;
    public CharacterController controller;
    public float speed = 4f;
    public float sprint = 1.5f;

    [Header("KeyCodes")]
    public KeyCode SprintKey = KeyCode.LeftShift;
    public KeyCode PauseKey = KeyCode.Escape;

    public static bool isPaused;

    //==Removed Crouching==
    //[Header("Crouching")]
    //public Transform defaultState;
    //public Transform ctrlState;
    //public Camera ctrlCam;
    //public Transform Player;
    //public float playerHeigth;
    //public float halfPlayerHeigth;

    [Header("Gravity")]
    public float gravity = -3f * 2f;
    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;
    public bool isGrounded;

    #endregion

    Vector3 velocity;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (Input.GetKey(SprintKey))
        {
            controller.Move(move * speed * Time.deltaTime * sprint); // Sprinting
        } else {
            controller.Move(move * speed * Time.deltaTime); // Walking
            
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(PauseKey))
        {
            isPaused = !isPaused;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.transform.position, groundDistance);
    }
}
