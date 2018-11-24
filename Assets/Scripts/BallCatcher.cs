using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCatcher : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        Wall wall = collision.gameObject.GetComponent<Wall>();
        if(ball != null){
            BallGenerator.Instance.Generate(collision.gameObject.GetComponent<Ball>().getId());
        }

        if(wall != null){
            WallManager.Instance.ReduceCount(wall.GetId());
        }
        Destroy(collision.gameObject);
    }
}
