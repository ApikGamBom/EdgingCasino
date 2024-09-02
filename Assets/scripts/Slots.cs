using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
    public Text wheel1Text;  // UI Text element for Wheel 1
    public Text wheel2Text;  // UI Text element for Wheel 2
    public Text wheel3Text;  // UI Text element for Wheel 3

    public int numberOfSides = 11; // Number of sides on each wheel (0 to 10)
    public float spinTime = 2.0f;  // Duration for the spin animation

    private int wheel1Result;
    private int wheel2Result;
    private int wheel3Result;

    // Called when the "Spin" button is clicked
    public void Spin()
    {
        // Start the coroutine to spin the wheels
        StartCoroutine(SpinWheels());
    }

    private IEnumerator SpinWheels()
    {
        // Get random results for each wheel
        wheel1Result = Random.Range(0, numberOfSides);
        wheel2Result = Random.Range(0, numberOfSides);
        wheel3Result = Random.Range(0, numberOfSides);

        float elapsedTime = 0f;

        // Perform the spin animation over 'spinTime' seconds
        while (elapsedTime < spinTime)
        {
            elapsedTime += Time.deltaTime;

            // Animate by updating wheel texts to random values during the spin
            wheel1Text.text = Random.Range(0, numberOfSides).ToString();
            wheel2Text.text = Random.Range(0, numberOfSides).ToString();
            wheel3Text.text = Random.Range(0, numberOfSides).ToString();

            yield return null; // Wait for the next frame
        }

        // After the spin ends, display the final results
        wheel1Text.text = wheel1Result.ToString();
        wheel2Text.text = wheel2Result.ToString();
        wheel3Text.text = wheel3Result.ToString();

        // Check for any winning conditions
        CheckWin();
    }

    // Add logic for winning conditions
    private void CheckWin()
    {
        if (wheel1Result == wheel2Result && wheel2Result == wheel3Result)
        {
            Debug.Log("Jackpot! All wheels match!");
        }
        else
        {
            Debug.Log("Try again!");
        }
    }
}
