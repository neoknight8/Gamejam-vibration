using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : SingletonMonoBehaviour<GoalManager>{
    [SerializeField]
    Goal[] goals;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Goal GetGoal(int id){
        return goals[id - 1];
    }

}
