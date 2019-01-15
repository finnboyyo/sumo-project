using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour {
	[SerializeField] float matchLength = 60f;
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

	void RoundOver () {winner.MatchOver ();
	}
	void InitializePlayers (){
	}
	void Start () {

		clock = matchLength;
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
			clock = matchLength - (Time.time - startTime);

            grandfatherClock.text = clock.ToString("0.0");

            yield return null;
          
			if (clock < 0f) {
				isTimerRunning = false;
				RoundOver ();
			}
        }
    }


}

