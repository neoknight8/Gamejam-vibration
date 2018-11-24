using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField]
    BoardController.ROTATION_DIRECTION type;
    bool isOn;
    bool[] canSwitch;

    // Use this for initialization
    void Start()
    {
        isOn = false;
        canSwitch = new bool[2] { false, false };
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Switch()
    {
        isOn = !isOn;
        gameObject.GetComponent<MeshRenderer>().material = MaterialsHolder.Instance.GetMaterial(type, isOn);
    }

    void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player == null)
        {
            return;
        }
        canSwitch[player.GetId() - 1] = true;
    }

    void OnTriggerExit(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player == null)
        {
            return;
        }
        canSwitch[player.GetId() - 1] = false;
    }

    public bool CanSwitch(int id)
    {
        return canSwitch[id - 1];
    }

}
