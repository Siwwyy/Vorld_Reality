using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Scan : MonoBehaviour
{

    public AstarPath Path;
    // Start is called before the first frame update
    void Start()
    {
       // Path.Scan();
    }

    void Awake()
    {
        Path.Scan();
    }

}
