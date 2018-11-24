using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : SingletonMonoBehaviour<BallGenerator>
{

    [SerializeField]
    GameObject[] balls;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Generate(int id)
    {
        Instantiate(balls[id - 1], new Vector3(0, 1, 0), Quaternion.Euler(0,0,0));
    }
}
