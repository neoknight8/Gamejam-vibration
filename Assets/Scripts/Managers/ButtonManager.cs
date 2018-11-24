using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : SingletonMonoBehaviour<ButtonManager>
{
    [SerializeField]
    Button[] buttons;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool CanSwitch(int id, BoardController.ROTATION_DIRECTION dir)
    {
        bool canSwitch = false;
        for (int i = (int)dir * 2; i < (int)dir * 2 + 2; i++)
        {
            if (buttons[i].CanSwitch(id))
            {
                canSwitch = true;
            }
        }
        return canSwitch;
    }

    public void Switch(BoardController.ROTATION_DIRECTION dir){
        BoardController.Instance.SwitchRotation(dir);
        for (int i = (int)dir * 2; i < (int)dir * 2 + 2; i++)
        {
            buttons[i].Switch();
        }
    }
}
