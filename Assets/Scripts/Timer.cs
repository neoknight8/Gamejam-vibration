using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void TimerHandler();
public class Timer : MonoBehaviour {
    int time;

    TimerHandler OnTimerStopped;

    public void SetOnTimerStopped(TimerHandler handler){
        OnTimerStopped += handler;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartCounting(int count){
        time = count;
        StartCoroutine("Count");
    }

    public void StopCounting(){
        StopCoroutine("Count");
        OnTimerStopped();
    }

    IEnumerator Count(){
        while(true){
            yield return new WaitForSeconds(1f);
            time--;
            if (time == 0)
            {
                StopCounting();
            }
        }
    }

    public int GetTime(){
        return time;
    }
}
