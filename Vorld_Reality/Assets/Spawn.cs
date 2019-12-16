using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject ob;
    private GameObject randomTarget;
    private GameObject[] targets;
    public int ilosc;
    public int spawnRate;
    private float timer;
    public int am;
    // Start is called before the first frame update
    void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("Pavement");
    }

    // Update is called once per frame
    void Update()
    {
        randomTarget = targets[Random.Range(0, targets.Length)];
        if (ilosc <= am)
        {
            if(timer <= spawnRate)
            {
                timer = 0;
                GameObject go = Instantiate(ob, randomTarget.transform.position, Quaternion.identity) as GameObject;
                go.transform.parent = transform;
                ilosc++;
            }
            else
                timer += Time.deltaTime;
        }
        
    }
}
