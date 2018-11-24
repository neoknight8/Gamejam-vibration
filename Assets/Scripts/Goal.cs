using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void GoalHandler();
public class Goal : MonoBehaviour
{
    [SerializeField]
    int id;

    public Dictionary<int, GoalHandler> onGoals;

    public void SetOnGoalHandler(int id, GoalHandler handler)
    {
        if (onGoals == null)
        {
            onGoals = new Dictionary<int, GoalHandler>();
        }
        if (onGoals.ContainsKey(id))
        {
            onGoals[id] += handler;
        }
        else
        {
            onGoals.Add(id, handler);
        }
    }


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball == null)
        {
            return;
        }
        if (id == ball.getId())
        {
            Debug.Log("Goal by " + id.ToString());
            onGoals[id]();
            BallGenerator.Instance.Generate(id);
        }
    }
}
