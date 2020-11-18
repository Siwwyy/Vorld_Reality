using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class CrossRoad : MonoBehaviour
{
    private AIPath Path;
    public Lights_Behaviour Lights;

    // Start is called before the first frame update
    void Start()
    {
        Path = GetComponent<AIPath>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Lights.Get_Current_Light_First() == Lights_Behaviour.TRAFFIC_LIGHT_COLOR.RED)
        {
            gameObject.layer = 9;
            foreach (Transform child in gameObject.GetComponentsInChildren<Transform>(true))
            {
                child.gameObject.layer = 9;
            }
        }
        else if (Lights.Get_Current_Light_First() == Lights_Behaviour.TRAFFIC_LIGHT_COLOR.GREEN)
        {
            gameObject.layer = 0;
            foreach (Transform child in gameObject.GetComponentsInChildren<Transform>(true))
            {
                child.gameObject.layer = 0;
            }
        }
    }
}
