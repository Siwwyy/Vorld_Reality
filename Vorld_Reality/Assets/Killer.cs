using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Killer : MonoBehaviour
{

    public AIPath path;
    private Spawner spawner;
    // Update is called once per frame

    void Start()
    {
        spawner = GetComponentInParent<Spawner>();
    }

    void Update()
    {
        if (path.reachedDestination)
        {
            spawner.ilosc--;
            Destroy(gameObject);
        }
            
    }
}
