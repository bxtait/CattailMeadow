using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    // The amount of time the timer should start with
    public float timeRemaining = 60.0f;

    // A reference to the Text component that will display the timer
    [SerializeField] private Text TimeLeft;


    // Update is called once per frame
    void Update()
    {
        // Decrement the time remaining by the amount of time since the last frame
        timeRemaining -= Time.deltaTime;

        // If the timer has run out, do something (in this case, just print a message)
        if (timeRemaining <= 0.0f)
        {
            Debug.Log("Time's up!");
        }

        // Update the Text component to display the current time remaining
        TimeLeft.text = "Time: " + timeRemaining.ToString("0.00");
    }
}

