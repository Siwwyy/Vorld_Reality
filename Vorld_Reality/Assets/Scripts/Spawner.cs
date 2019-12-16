using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject GO;
    public GRID grid;
    public int ilosc;
    public float timeBetweenSpawn;
    private float timer;
    private int x;
    private int y;
    public int am;

    // Start is called before the first frame update
    void Start()
    {
        ilosc = 0;
        am = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(ilosc <= am)
        {
            if (timer >= timeBetweenSpawn)
            {
                x = Random.Range(0, grid.iGridSizeX);
                y = Random.Range(0, grid.iGridSizeY);
               // Debug.Log(x + " " + y);
                if(grid.NodeArray[x,y].bIsWall)
                {
                    timer = 0;
                    ilosc++;
                    GameObject go = Instantiate(GO, grid.NodeArray[x,y].vPosition + new Vector3(0, -9.5f, 0), Quaternion.identity) as GameObject;
                    go.transform.parent = transform;
                    grid.CreateGrid();
                }
            }
            else
                timer += Time.deltaTime;
        }
            
    }
}
