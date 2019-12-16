using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Killer : MonoBehaviour
{

    public AIPath path;
    private Spawner spawner;
    private float timer;
    // Update is called once per frame

    void Start()
    {
        spawner = GetComponentInParent<Spawner>();
    }

    void Update()
    {
        if (path.reachedDestination || timer >= 120)
        {
            spawner.ilosc--;
            Destroy(gameObject);
        }
        else
            timer += Time.deltaTime;
            
    }
}
