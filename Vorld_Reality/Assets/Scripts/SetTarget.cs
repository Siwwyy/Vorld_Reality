using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class SetTarget : MonoBehaviour
{
    private AIDestinationSetter t;
    // Update is called once per frame
    void Start()
    {
        t = GetComponent<AIDestinationSetter>();
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Pavement");
        GameObject randomTarget = targets[Random.Range(0, targets.Length)];
        t.target = randomTarget.transform;
    }
}
