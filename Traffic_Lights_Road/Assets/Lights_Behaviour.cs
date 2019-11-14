using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights_Behaviour : MonoBehaviour
{
    /*
     Private case
     */
    private int Yellow_Delay = 2; //yellow light delay
    private int Red_Delay = 10; //red light delay
    private int Green_Delay = 2; //red light delay
    private bool change = false;
    private float nextUpdate = 1.0f;
    private bool mode = false;
    //////////////////////////////////////////////////////////
    public enum TRAFFIC_LIGHT_COLOR
    {
        GREEN = 0,
        YELLOW = 1,
        RED = 2
    }
    //TRAFFIC_LIGHT_COLOR current_light;
    public Update_Lights Object_First;
    public Update_Lights_2 Object_Second;
    // Start is called before the first frame update
    void Start()
    {
        if(mode == false)
        {
            Object_First.Green.intensity = 1.2f;
            Object_First.Green_1.intensity = 1.2f;
            Object_First.Yellow.intensity = 0;
            Object_First.Yellow_1.intensity = 0;
            Object_First.Red.intensity = 0;
            Object_First.Red_1.intensity = 0;

            Object_Second.Green.intensity = 0;
            Object_Second.Green_1.intensity = 0;
            Object_Second.Yellow.intensity = 0;
            Object_Second.Yellow_1.intensity = 0;
            Object_Second.Red.intensity = 1.2f;
            Object_Second.Red_1.intensity = 1.2f;
        }
        else 
        {
            Object_First.Green.intensity = 0;
            Object_First.Green_1.intensity = 0;
            Object_First.Yellow.intensity = 1.2f;
            Object_First.Yellow_1.intensity = 1.2f;
            Object_First.Red.intensity = 0;
            Object_First.Red_1.intensity = 0;

            Object_Second.Green.intensity = 0;
            Object_Second.Green_1.intensity = 0;
            Object_Second.Yellow.intensity = 1.2f;
            Object_Second.Yellow_1.intensity = 1.2f;
            Object_Second.Red.intensity = 0;
            Object_Second.Red_1.intensity = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Normal Traffic Lights System
        if (Input.GetKeyDown(KeyCode.G))
        {
            change = true;
            mode = false;

            Object_First.Green.intensity = 1.2f;
            Object_First.Green_1.intensity = 1.2f;
            Object_First.Yellow.intensity = 0;
            Object_First.Yellow_1.intensity = 0;
            Object_First.Red.intensity = 0;
            Object_First.Red_1.intensity = 0;

            Object_Second.Green.intensity = 0;
            Object_Second.Green_1.intensity = 0;
            Object_Second.Yellow.intensity = 0;
            Object_Second.Yellow_1.intensity = 0;
            Object_Second.Red.intensity = 1.2f;
            Object_Second.Red_1.intensity = 1.2f;

            nextUpdate = Mathf.FloorToInt(Time.time) + 2;
        }

        //Nightly Traffic Lights System
        if(Input.GetKeyDown(KeyCode.H))
        {
            mode = true;

            Object_First.Green.intensity = 0;
            Object_First.Green_1.intensity = 0;
            Object_First.Yellow.intensity = 1.2f;
            Object_First.Yellow_1.intensity = 1.2f;
            Object_First.Red.intensity = 0;
            Object_First.Red_1.intensity = 0;

            Object_Second.Green.intensity = 0;
            Object_Second.Green_1.intensity = 0;
            Object_Second.Yellow.intensity = 1.2f;
            Object_Second.Yellow_1.intensity = 1.2f;
            Object_Second.Red.intensity = 0;
            Object_Second.Red_1.intensity = 0;

            nextUpdate = Mathf.FloorToInt(Time.time) + 2;
        }
        if (Time.time >= nextUpdate && mode == false)
        {
            if (change == true)
            {
                if (Object_First.Green.intensity > 0)
                {
                    Object_First.Green.intensity = 0;
                    Object_First.Green_1.intensity = 0;
                    Object_First.Yellow.intensity = 1.2f;
                    Object_First.Yellow_1.intensity = 1.2f;

                    Object_Second.Red.intensity = 0;
                    Object_Second.Red_1.intensity = 0;
                    Object_Second.Yellow.intensity = 1.2f;
                    Object_Second.Yellow_1.intensity = 1.2f;

                    nextUpdate = Mathf.FloorToInt(Time.time) + Yellow_Delay;
                }
                else if (Object_First.Yellow.intensity > 0)
                {
                    Object_First.Yellow.intensity = 0;
                    Object_First.Yellow_1.intensity = 0;
                    Object_First.Red.intensity = 1.2f;
                    Object_First.Red_1.intensity = 1.2f;

                    Object_Second.Yellow.intensity = 0;
                    Object_Second.Yellow_1.intensity = 0;
                    Object_Second.Green.intensity = 1.2f;
                    Object_Second.Green_1.intensity = 1.2f;

                    nextUpdate = Mathf.FloorToInt(Time.time) + Red_Delay;
                }
                else if (Object_First.Red.intensity > 0)
                {
                    Object_First.Red.intensity = 0;
                    Object_First.Red_1.intensity = 0;
                    Object_First.Yellow.intensity = 1.2f;
                    Object_First.Yellow_1.intensity = 1.2f;

                    Object_Second.Green.intensity = 0;
                    Object_Second.Green_1.intensity = 0;
                    Object_Second.Yellow.intensity = 1.2f;
                    Object_Second.Yellow_1.intensity = 1.2f;

                    change = false;
                    nextUpdate = Mathf.FloorToInt(Time.time) + Green_Delay;
                }
            }
            else if(change == false && mode == false)
            {
                if(Object_Second.Yellow.intensity > 0)
                {
                    Object_First.Yellow.intensity = 0;
                    Object_First.Yellow_1.intensity = 0;
                    Object_First.Green.intensity = 1.2f;
                    Object_First.Green_1.intensity = 1.2f;

                    Object_Second.Yellow.intensity = 0;
                    Object_Second.Yellow_1.intensity = 0;
                    Object_Second.Red.intensity = 1.2f;
                    Object_Second.Red_1.intensity = 1.2f;

                    nextUpdate = Mathf.FloorToInt(Time.time) + Green_Delay;
                }
            }
        }

        //Yellow Lights Blinking
        if (mode == true)
        {
            if (Time.time >= nextUpdate)
            {
                if (Object_Second.Yellow.intensity > 0)
                {
                    Object_First.Yellow.intensity = 0;
                    Object_First.Yellow_1.intensity = 0;

                    Object_Second.Yellow.intensity = 0;
                    Object_Second.Yellow_1.intensity = 0;

                    nextUpdate = Mathf.FloorToInt(Time.time) + 1;
                }
                else
                {
                    Object_First.Yellow.intensity = 1.2f;
                    Object_First.Yellow_1.intensity = 1.2f;

                    Object_Second.Yellow.intensity = 1.2f;
                    Object_Second.Yellow_1.intensity = 1.2f;

                    nextUpdate = Mathf.FloorToInt(Time.time) + 1;
                }
            }
        }


    }
}
