using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Update_Lights : MonoBehaviour
{
    // Start is called before the first frame update
    public Light Green;
    public Light Yellow;
    public Light Red;

    public Light Green_1;
    public Light Yellow_1;
    public Light Red_1;

    //Update_Lights_2 Object;

    //private int Green_Delay = 0; //useful
    //private int Yellow_Delay = 2; //yellow light delay
    //private int Red_Delay = 10; //red light delay

    //private bool change = false;
    //private float nextUpdate = 1.0f;
    //public enum TRAFFIC_LIGHT_COLOR
    //{
    //    GREEN = 0,
    //    YELLOW = 1,
    //    RED = 2
    //}
    //TRAFFIC_LIGHT_COLOR current_light;
   
    void Start()
    {
        //Yellow.intensity = 0;
        //Yellow_1.intensity = 0;
        //Red.intensity = 0;
        //Red_1.intensity = 0;
       // current_light = TRAFFIC_LIGHT_COLOR.GREEN;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.G))
        //{
        //    change = true;
        //}
        //if (Time.time >= nextUpdate)
        //{
        //    if (change == true)
        //    {
        //        if (Green.intensity > 0)
        //        {
        //            Green.intensity = 0;
        //            Green_1.intensity = 0;
        //            Yellow.intensity = 1.2f;
        //            Yellow_1.intensity = 1.2f;
        //            nextUpdate = Mathf.FloorToInt(Time.time) + Yellow_Delay;
        //            current_light = TRAFFIC_LIGHT_COLOR.YELLOW;
        //        }
        //        else if (Yellow.intensity > 0)
        //        {
        //            Yellow.intensity = 0;
        //            Yellow_1.intensity = 0;
        //            Red.intensity = 1.2f;
        //            Red_1.intensity = 1.2f;
        //            nextUpdate = Mathf.FloorToInt(Time.time) + Red_Delay;
        //            current_light = TRAFFIC_LIGHT_COLOR.RED;
        //           // Object.Change_Lights();
        //        }
        //        else if (Red.intensity > 0)
        //        {
        //            Red.intensity = 0;
        //            Red_1.intensity = 0;
        //            Green.intensity = 1.2f;
        //            Green_1.intensity = 1.2f;
        //            change = false;
        //            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
        //            current_light = TRAFFIC_LIGHT_COLOR.GREEN;
        //        }
        //    }
        //    //print(current_light);
        //}
    }

    //public TRAFFIC_LIGHT_COLOR Get_Current_Light()
    //{
    //    return current_light;
    //}
}