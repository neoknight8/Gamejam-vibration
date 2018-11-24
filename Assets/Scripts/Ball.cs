using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    [SerializeField]
    int id;
	// Use this for initialization
	void Start () {
        Goal goal = GoalManager.Instance.GetGoal(id);
        goal.SetOnGoalHandler(
            id,
            () => {
            try{
                Destroy(gameObject);
            }catch(MissingReferenceException e){
            }
        });
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int getId(){
        return id;
    }
}
