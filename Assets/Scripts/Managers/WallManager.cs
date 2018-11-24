using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : SingletonMonoBehaviour<WallManager>
{
    ArrayList walls;
    int[] wallCounts;

    // Use this for initialization
    void Start()
    {
        walls = new ArrayList();
        wallCounts = new int[] { 0, 0 };

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool CanGenerate(int id)
    {
        return wallCounts[id - 1] < 3;
    }

    public void AddCount(int id)
    {
        wallCounts[id - 1]++;
    }

    public void ReduceCount(int id)
    {
        wallCounts[id - 1]--;
    }
}
