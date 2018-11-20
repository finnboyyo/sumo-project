using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour {

    float clock;
    float startTime;
    public Text grandfatherClock;
    public bool isTimerRunning = true;
    bool isPaused = false;
    // Use this for initialization
    void Stop() {


        if (Input.GetKeyDown("p"))
        {



            isPaused = !isPaused;
            if (isPaused == true)
            {

                Time.timeScale = 0.0f;


            }
            else
            {
                Time.timeScale = 1f;

            }
        }
    }



	void Start () {


        startTime = Time.time;

        StartCoroutine("DisplayClock"); 

	}
	
	// Update is called once per frame
	void Update () {

        Stop();
	}
    IEnumerator DisplayClock()
    {
        while (isTimerRunning) {
            clock = Time.time - startTime;

            grandfatherClock.text = clock.ToString("0.0");

            yield return null;
          

        }
    }


}

