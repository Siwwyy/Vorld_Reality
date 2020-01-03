using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject ob;
    private GameObject randomTarget;
    private GameObject[] targets;
    public float spawnRate;
    public float timer;
    public int am;
    // Start is called before the first frame update
    void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("Pavement");
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        randomTarget = targets[Random.Range(0, targets.Length)];
        if (GlobalVariables.ilosc <= am)
        {
            if(timer >= spawnRate)
            {
                timer = 0;
                GameObject go = Instantiate(ob, randomTarget.transform.position, Quaternion.identity) as GameObject;
                go.transform.parent = transform;
                GlobalVariables.ilosc++;
            }
            else
                timer += Time.deltaTime;
        }
        
    }
}
