using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GRID grid;
    //public Transform End;
    //private Transform End2;
    public Vector3 target;
    private float x;
    private float y;
    // Start is called before the first frame update
    void Awake()
    {
        grid = GetComponentInParent<GRID>();
    }
    void Start()
    {
        grid = GetComponentInParent<GRID>();
        for (;;)
        {
            x = Random.Range(0, grid.iGridSizeX);
            y = Random.Range(0, grid.iGridSizeY);
           // Debug.Log("x: " + x + " y: " + y);
            if (grid.NodeArray[(int)x, (int)y].bIsWall)
                break;
        }
        Debug.Log(grid.NodeArray[(int)x, (int)y].vPosition);
        target = grid.NodeArray[(int)x,(int)y].vPosition + new Vector3(0, -9.6f, 0);

    }

    // Update is called once per frame
    void Update()
    {
        grid = GetComponentInParent<GRID>();
    }
}
