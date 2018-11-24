using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class Player : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    int id;

    private GamePad.Index gamepadIndex;

    // Use this for initialization
    void Start()
    {
        if (id == 1)
        {
            gamepadIndex = GamePad.Index.One;
        }
        else if (id == 2)
        {
            gamepadIndex = GamePad.Index.Two;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        SwitchRotation();
        PutWall();
    }

    void Move()
    {
        Vector2 axis = GamePad.GetAxis(GamePad.Axis.LeftStick, gamepadIndex);
        gameObject.transform.position += new Vector3(speed * axis.x, 0, speed * axis.y);
        gameObject.transform.forward = new Vector3(speed * axis.x, 0, speed * axis.y);
    }

    public int GetId()
    {
        return id;
    }

    void SwitchRotation()
    {
        if (GamePad.GetButtonDown(GamePad.Button.B, gamepadIndex))
        {
            for (int i = 0; i < 2; i++)
            {
                if(ButtonManager.Instance.CanSwitch(id, (BoardController.ROTATION_DIRECTION)i)){
                    ButtonManager.Instance.Switch((BoardController.ROTATION_DIRECTION)i);
                }
            }
        }
    }

    void PutWall(){
        if(GamePad.GetButtonDown(GamePad.Button.X, gamepadIndex)){
            if(WallManager.Instance.CanGenerate(id)){
                GameObject wall = WallGenerator.Instance.Generate(id, transform.position + transform.forward * 0.4f + new Vector3(0, 0.2f, 0), transform.eulerAngles);
            }
        }
    }
}
