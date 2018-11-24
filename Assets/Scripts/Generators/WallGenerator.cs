using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : SingletonMonoBehaviour<WallGenerator> {
    [SerializeField]
    GameObject prehab, parent;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject Generate(int id, Vector3 position, Vector3 rotation){
        GameObject obj = Instantiate(prehab, position, Quaternion.Euler(rotation.x, rotation.y, 90));
        obj.GetComponent<Wall>().SetId(id);
        WallManager.Instance.AddCount(id);
        return obj;
    }
}
