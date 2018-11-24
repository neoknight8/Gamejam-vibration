using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    int[] score;
    [SerializeField]
    TextMeshProUGUI[] scoreTexts;
    [SerializeField]
    TextMeshProUGUI timerText;
    Timer timer;

    [SerializeField]
    Animator timeUpAnimator;

    // Use this for initialization
    void Start()
    {
        timer = GetComponent<Timer>();
        timer.SetOnTimerStopped(
            () =>
            {
                foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Ball"))
                {
                    Destroy(obj);
                    timeUpAnimator.SetBool("Show", true);
                }
            });
        timer.StartCounting(60);
        score = new int[2];
        for (int i = 1; i <= 2; i++)
        {
            int id = i;
            score[id - 1] = 0;
            SetScoreText(id);
            GoalManager.Instance.GetGoal(id).SetOnGoalHandler(
                id,
                () =>
                {
                    Debug.Log(id);
                    score[id - 1]++;
                    SetScoreText(id);
                });
        }
    }

    // Update is called once per frame
    void Update()
    {
        SetTimerText();
        if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene("Main");
        }
    }

    void SetScoreText(int id)
    {
        scoreTexts[id - 1].text = "Player " + id.ToString() + ": " + score[id - 1].ToString();
    }

    void SetTimerText()
    {
        timerText.text = timer.GetTime().ToString();
    }

}
