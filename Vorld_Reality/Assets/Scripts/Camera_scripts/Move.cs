using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    float input_X, input_Z;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        input_X = Input.GetAxis("Horizontal");
        input_Z = Input.GetAxis("Vertical");

        if (input_X != 0)
        {
            Rotate_Camere();
        }
        if (input_Z != 0)
        {
            Move_Camera();
        }
    }

    private void Move_Camera()
    {
        transform.position += transform.forward * input_Z * Time.deltaTime * 100;
    }

    private void Rotate_Camere()
    {
        transform.Rotate(new Vector3(0f, input_X * Time.deltaTime * 100, 0f));
    }
}
