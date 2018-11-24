using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : SingletonMonoBehaviour<BoardController> {
    float rotation_direction_x, rotation_direction_z;
    public bool isRotatingX, isRotatingZ;
    const float ROTATION_SPEED = 0.2f;
    const int MAX_ANGLE = 30;

    public enum ROTATION_DIRECTION{
        X,
        Z
    }

	// Use this for initialization
	void Start () {
        rotation_direction_x = 1;
        rotation_direction_z = 1;
        isRotatingX = false;
        isRotatingZ = false;
	}
	
	// Update is called once per frame
	void Update () {
        Rotate();
	}

    public void StartRotation(ROTATION_DIRECTION dir){
        switch(dir){
            case ROTATION_DIRECTION.X:
                isRotatingX = true;
                break;
            case ROTATION_DIRECTION.Z:
                isRotatingZ = true;
                break;
        }
    }

    public void StopRotation(ROTATION_DIRECTION dir)
    {
        switch (dir)
        {
            case ROTATION_DIRECTION.X:
                isRotatingX = false;
                break;
            case ROTATION_DIRECTION.Z:
                isRotatingZ = false;
                break;
        }
    }

    void Rotate(){
        Vector3 current_rotation = AngleUtil.ConvertAngle(gameObject.transform.localEulerAngles);
        if(isRotatingX){
            if(current_rotation.x < -MAX_ANGLE){
                rotation_direction_x = 1;
            }
            if(current_rotation.x > MAX_ANGLE){
                rotation_direction_x = -1;
            }
            current_rotation += new Vector3(ROTATION_SPEED * rotation_direction_x, 0, 0);
        }
        
        if(isRotatingZ){
            if (current_rotation.z < -MAX_ANGLE)
            {
                rotation_direction_z = 1;
            }
            if (current_rotation.z > MAX_ANGLE)
            {
                rotation_direction_z = -1;
            }
            current_rotation += new Vector3(0, 0, ROTATION_SPEED * rotation_direction_z);
        }
        gameObject.transform.localEulerAngles = current_rotation;
    }

    public void SwitchRotation(ROTATION_DIRECTION dir){
        switch(dir){
            case ROTATION_DIRECTION.X:
                if(isRotatingX){
                    StopRotation(ROTATION_DIRECTION.X);
                }else{
                    StartRotation(ROTATION_DIRECTION.X);
                }
                break;
            case ROTATION_DIRECTION.Z:
                if (isRotatingZ)
                {
                    StopRotation(ROTATION_DIRECTION.Z);
                }
                else
                {
                    StartRotation(ROTATION_DIRECTION.Z);
                }
                break;
        }
    }

}
