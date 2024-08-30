using UnityEngine;
//using UnityEngine.InputSystem;

public class cameraMovement : MonoBehaviour
{
    [Header("Bools")]
    public bool alwCamMovement = true;
    public bool pauseMenuOpen = false;
    public bool ps4_active = false;

    [Header("Other")]
    public float mouseSensetivity = 200f;
    public Transform playerBody;
    float xRotation = 0f;

    [Header("MouseAxis")]
    float MouseX;
    float MouseY;

  void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;

        //for (int i = 0; i < Gamepad.all.Count; i++)
        //{
        //Debug.Log(Gamepad.all[i].name);
        //}
    }

  void Update()
    {
        pauseMenuOpen = playerMovement.isPaused;
        //if(Input.GetButtonDown("Cancel") && alwCamMovement)
        //{
        //    pauseMenuOpen = true;
            //Debug.Log("Set to true");
        //} else if(Input.GetButtonDown("Cancel")) {
        //    pauseMenuOpen = false;
            //Debug.Log("Set to false");
        //}

        if(pauseMenuOpen) {
            alwCamMovement = false;
        } else {
            alwCamMovement = true;
        }

        if (alwCamMovement)
        {
            if (!ps4_active)
            {
                MouseX = Input.GetAxis("Mouse X") * mouseSensetivity * Time.deltaTime;
                MouseY = Input.GetAxis("Mouse Y") * mouseSensetivity * Time.deltaTime;
            } else
            {
                //MouseX = Gamepad.all[0].rightStick.value.x * mouseSensetivity * Time.deltaTime;
                //MouseY = Gamepad.all[0].rightStick.value.y * mouseSensetivity * Time.deltaTime;

                Debug.Log("Joystick X" + MouseX);
                Debug.Log("Joystick Y" + MouseY);
            }
                

            xRotation -= MouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * MouseX);
        }
    }
}
