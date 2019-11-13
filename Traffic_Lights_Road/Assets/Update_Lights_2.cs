using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Update_Lights_2 : MonoBehaviour
{

    public Light Green;
    public Light Yellow;
    public Light Red;

    public Light Green_1;
    public Light Yellow_1;
    public Light Red_1;
    private float nextUpdate = 1.0f;
    //private int Green_Delay = 0; //useful
    private int Yellow_Delay = 2; //yellow light delay
    private int Red_Delay = 10; //red light delay
    // Start is called before the first frame update
    void Start()
    {
        Green.intensity = 0;
        Yellow.intensity = 0;
        Red.intensity = 1.2f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Change_Lights()
    {
        if (Time.time >= nextUpdate)
        {
            if (Green.intensity > 0)
            {
                Green.intensity = 0;
                Green_1.intensity = 0;
                Yellow.intensity = 1.2f;
                Yellow_1.intensity = 1.2f;
                nextUpdate = Mathf.FloorToInt(Time.time) + Yellow_Delay;
            }
            else if (Yellow.intensity > 0)
            {
                Yellow.intensity = 0;
                Yellow_1.intensity = 0;
                Red.intensity = 1.2f;
                Red_1.intensity = 1.2f;
                nextUpdate = Mathf.FloorToInt(Time.time) + Red_Delay;
            }
            else if (Red.intensity > 0)
            {
                Red.intensity = 0;
                Red_1.intensity = 0;
                Green.intensity = 1.2f;
                Green_1.intensity = 1.2f;
                nextUpdate = Mathf.FloorToInt(Time.time) + 1;
            }
        }
    }
}
