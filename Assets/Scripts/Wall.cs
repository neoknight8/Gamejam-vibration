using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {
    int id;

	// Use this for initialization
	void Start () {
        StartCoroutine("CountDown");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int GetId(){
        return id;
    }

    public void SetId(int _id){
        id = _id;
    }

    private IEnumerator CountDown(){
        yield return new WaitForSeconds(10f);
        WallManager.Instance.ReduceCount(id);
        Destroy(gameObject);
    }
}
