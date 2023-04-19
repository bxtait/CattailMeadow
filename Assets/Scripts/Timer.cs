using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    float currentTime;
    public float startingTime = 10f;
    private Animator anim;
    private Rigidbody2D rb;

    [SerializeField] Text countdownText;
    void Start()
    {
        currentTime = startingTime;


    }
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
            countdownText.text = "Time Left: " + currentTime;
            RestartLevel();
        }
        
       

    }

   
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
