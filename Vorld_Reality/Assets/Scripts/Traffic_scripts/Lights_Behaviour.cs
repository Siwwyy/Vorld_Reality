using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

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
    public AstarPath Path;
    //////////////////////////////////////////////////////////
    public enum TRAFFIC_LIGHT_COLOR
    {
        GREEN = 0,
        YELLOW = 1,
        RED = 2
    }

    TRAFFIC_LIGHT_COLOR current_light_first;
    TRAFFIC_LIGHT_COLOR current_light_second;
    public GameObject Car1;
    public GameObject Bus;
    private GameObject Car1_Clone;
    private GameObject Bus_Clone;
    public GameObject Point_Car1;
    public GameObject Point_Bus;
    public GameObject Car2;
    private GameObject Car2_Clone;
    public GameObject Point_Car2;

    /*
      SPAWNING
    */
    public GameObject Spawn_Car1;
    public GameObject Spawn_Car2;
    public GameObject Spawn_Bus;
    /*
      DESTROYING
    */
    public GameObject Destroy_Car1;
    public GameObject Destroy_Car2;
    public GameObject Destroy_Bus;

    public Update_Lights Object_First;
    public Update_Lights_2 Object_Second;
    // Start is called before the first frame update
    void Start()
    {
        Path.Scan();
        if (mode == false)
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

            current_light_first = TRAFFIC_LIGHT_COLOR.GREEN;
            current_light_second = TRAFFIC_LIGHT_COLOR.RED;
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

            current_light_first = TRAFFIC_LIGHT_COLOR.RED;
            current_light_second = TRAFFIC_LIGHT_COLOR.GREEN;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //CARS BEHAVIOR
        //Limanowskiego
        if (current_light_first == TRAFFIC_LIGHT_COLOR.GREEN)
        {
            Car1.transform.position = new Vector3(Car1.transform.position.x, Car1.transform.position.y, Car1.transform.position.z + 0.1f);
            Bus.transform.position = new Vector3(Bus.transform.position.x, Bus.transform.position.y, Bus.transform.position.z - 0.1f);
        }
        else if(current_light_first == TRAFFIC_LIGHT_COLOR.RED)
        {
            if (Car1.transform.position.z == Point_Car1.transform.position.z)
            {
                Car1.transform.position = new Vector3(Car1.transform.position.x, Car1.transform.position.y, Point_Car1.transform.position.z);
            }
            else if (Car1.transform.position.z > Point_Car1.transform.position.z)
            {
                Car1.transform.position = new Vector3(Car1.transform.position.x, Car1.transform.position.y, Car1.transform.position.z + 0.1f);
            }
            else if (Car1.transform.position.z < Point_Car1.transform.position.z - 1.0f)
            {
                Car1.transform.position = new Vector3(Car1.transform.position.x, Car1.transform.position.y, Car1.transform.position.z + 0.1f);
            }

            //BUS
            if (Bus.transform.position.z == Point_Bus.transform.position.z)
            {
                Bus.transform.position = new Vector3(Bus.transform.position.x, Bus.transform.position.y, Point_Bus.transform.position.z);
            }
            else if (Bus.transform.position.z < Point_Bus.transform.position.z)
            {
                Bus.transform.position = new Vector3(Bus.transform.position.x, Bus.transform.position.y, Bus.transform.position.z - 0.1f);
            }
            else if (Bus.transform.position.z > Point_Bus.transform.position.z + 1.0f)
            {
                Bus.transform.position = new Vector3(Bus.transform.position.x, Bus.transform.position.y, Bus.transform.position.z - 0.1f);
            }
        }
        //Debug.Log("First: "+current_light_first + " " + '\n');
        //Debug.Log("Second: " + current_light_second + " " + '\n');
        //Pomorska
        if (current_light_second == TRAFFIC_LIGHT_COLOR.GREEN)
        {
            Car2.transform.position = new Vector3(Car2.transform.position.x + 0.1f, Car2.transform.position.y, Car2.transform.position.z);
        }
        else if (current_light_second == TRAFFIC_LIGHT_COLOR.RED)
        {
            if (Car2.transform.position.x == Point_Car2.transform.position.x)
            {
                Car2.transform.position = new Vector3(Point_Car2.transform.position.x, Car2.transform.position.y, Car2.transform.position.z);
            }
            else if (Car2.transform.position.x > Point_Car2.transform.position.x)
            {
                Car2.transform.position = new Vector3(Car2.transform.position.x + 0.1f, Car2.transform.position.y, Car2.transform.position.z);
            }
            else if (Car2.transform.position.x <= Point_Car2.transform.position.x - 1.0f)
            {
                Car2.transform.position = new Vector3(Car2.transform.position.x + 0.1f, Car2.transform.position.y, Car2.transform.position.z);
            }
        }
        else
        {
            if (Car2.transform.position.x == Point_Car2.transform.position.x)
            {
                Car2.transform.position = new Vector3(Point_Car2.transform.position.x, Car2.transform.position.y, Car2.transform.position.z);
            }
            else if (Car2.transform.position.x > Point_Car2.transform.position.x)
            {
                Car2.transform.position = new Vector3(Car2.transform.position.x + 0.1f, Car2.transform.position.y, Car2.transform.position.z);
            }
            else if (Car2.transform.position.x < Point_Car2.transform.position.x - 1.0f)
            {
                Car2.transform.position = new Vector3(Car2.transform.position.x + 0.1f, Car2.transform.position.y, Car2.transform.position.z);
            }
        }


        if (Car1.transform.position.z >= Destroy_Car1.transform.position.z)
        {        
            //Initialize clones first
            Car1_Clone = Instantiate(Car1, Spawn_Car1.transform.position, Quaternion.identity) as GameObject;
            ///////////////////////////////////////
            Destroy(Car1);
            Car1 = Instantiate(Car1_Clone, Spawn_Car1.transform.position, Quaternion.identity) as GameObject;
            Destroy(Car1_Clone);
        }
        if(Car2.transform.position.x >= Destroy_Car2.transform.position.x)
        {
            //Initialize clones first
            Car2_Clone = Instantiate(Car2, Spawn_Car2.transform.position, Quaternion.identity) as GameObject;
            ///////////////////////////////////////
            Destroy(Car2);
            Car2 = Instantiate(Car2_Clone, Spawn_Car2.transform.position, Quaternion.Euler(0,90,0)) as GameObject;
            Destroy(Car2_Clone);
        }
        if (Bus.transform.position.z <= Destroy_Bus.transform.position.z)
        {
            //Initialize clones first
            Bus_Clone = Instantiate(Bus, Spawn_Bus.transform.position, Quaternion.identity) as GameObject;
            ///////////////////////////////////////
            Destroy(Bus);
            Bus = Instantiate(Bus_Clone, Spawn_Bus.transform.position, Quaternion.identity) as GameObject;
            Destroy(Bus_Clone);
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //Normal Traffic Lights System
        if (Input.GetKeyDown(KeyCode.G))
        {
            change = true;
            mode = false;
            Path.Scan();

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
            Path.Scan();
            if (mode == true)
            {
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
            }
            else
            {
                mode = true;
                change = false;

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
           
            nextUpdate = Mathf.FloorToInt(Time.time) + 2;
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        if (Time.time >= nextUpdate && mode == false)
        {
            if (change == true)
            {
                Path.Scan();
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

                    current_light_first = TRAFFIC_LIGHT_COLOR.YELLOW;
                    current_light_second = TRAFFIC_LIGHT_COLOR.YELLOW;

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

                    current_light_first = TRAFFIC_LIGHT_COLOR.RED;
                    current_light_second = TRAFFIC_LIGHT_COLOR.GREEN;

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

                    current_light_first = TRAFFIC_LIGHT_COLOR.YELLOW;
                    current_light_second = TRAFFIC_LIGHT_COLOR.YELLOW;

                    change = false;
                    nextUpdate = Mathf.FloorToInt(Time.time) + Green_Delay;
                }
            }
            else if(change == false && mode == false)
            {
                if (Object_Second.Yellow.intensity > 0)
                {
                    Object_First.Yellow.intensity = 0;
                    Object_First.Yellow_1.intensity = 0;
                    Object_First.Green.intensity = 1.2f;
                    Object_First.Green_1.intensity = 1.2f;

                    Object_Second.Yellow.intensity = 0;
                    Object_Second.Yellow_1.intensity = 0;
                    Object_Second.Red.intensity = 1.2f;
                    Object_Second.Red_1.intensity = 1.2f;

                    current_light_first = TRAFFIC_LIGHT_COLOR.GREEN;
                    current_light_second = TRAFFIC_LIGHT_COLOR.RED;

                    nextUpdate = Mathf.FloorToInt(Time.time) + Green_Delay;
                }
            }



        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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
                current_light_first = TRAFFIC_LIGHT_COLOR.YELLOW;
                current_light_second = TRAFFIC_LIGHT_COLOR.YELLOW;
            }
        }       
    }

    public TRAFFIC_LIGHT_COLOR Get_Current_Light_First()
    {
        return current_light_first;
    }

    public TRAFFIC_LIGHT_COLOR Get_Current_Light_Second()
    {
        return current_light_second;
    }
}
