using System.Collections;  // Required for IEnumerator
using UnityEngine;  // Required for Unity components

public class SlotMachine : MonoBehaviour
{
    public Transform[] wheels;  // Array of the three wheels
    public float spinDuration = 3f;  // Time duration for how long the wheels spin
    private bool isSpinning = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !isSpinning)
        {
            StartCoroutine(SpinWheels());
        }
    }

    IEnumerator SpinWheels()
    {
        isSpinning = true;

        // Start all wheels spinning
        for (int i = 0; i < wheels.Length; i++)
        {
            StartCoroutine(SpinWheel(wheels[i], spinDuration + i * 0.5f));
        }

        // Wait until all wheels have stopped spinning
        yield return new WaitForSeconds(spinDuration + 1.5f);
        isSpinning = false;
    }

    IEnumerator SpinWheel(Transform wheel, float duration)
    {
        float time = 0f;
        float speed = 720f; // Set your desired rotation speed
        while (time < duration)
        {
            time += Time.deltaTime;
            // Rotate the wheel around the Y-axis only
            wheel.Rotate(Vector3.up * speed * Time.deltaTime);
            yield return null;
        }

        // Stop the wheel and align it to the nearest face
        AlignWheelToFace(wheel);
    }

    void AlignWheelToFace(Transform wheel)
    {
        // Get the current Y-axis rotation
        float yAngle = wheel.eulerAngles.y;

        // Calculate the angle per face based on 11 faces
        float anglePerFace = 360f / 11f;

        // Find the closest face's angle (multiple of anglePerFace)
        float closestAngle = Mathf.Round(yAngle / anglePerFace) * anglePerFace;

        // Apply the closest face angle while locking X and Z axes to their original values (likely 0f)
        wheel.eulerAngles = new Vector3(0f, closestAngle, 90f);  // Only modify the Y-axis
    }
}
