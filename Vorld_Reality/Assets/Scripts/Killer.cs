using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Killer : MonoBehaviour
{

    public AIPath path;
    public float timer;
    // Update is called once per frame


    void Update()
    {
        if (path.reachedEndOfPath || timer >= 120)
        {
            GlobalVariables.ilosc--;
            Destroy(gameObject);
        }
        else
            timer += Time.deltaTime;
            
    }
}
