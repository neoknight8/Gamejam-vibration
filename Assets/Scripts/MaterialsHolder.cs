using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialsHolder : SingletonMonoBehaviour<MaterialsHolder> {
    [SerializeField]
    Material[] materials;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Material GetMaterial(BoardController.ROTATION_DIRECTION dir, bool isOn){
        return materials[(int)dir * 2 + (isOn ? 0 : 1)];
    }

}
