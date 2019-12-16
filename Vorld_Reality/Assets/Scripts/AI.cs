using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    private Rigidbody rb;
    public Spawner s;
    public List<Node> Path;
    public PathFinding p;
    public Target Target;

    public float speed;
    public bool pathEnded;
    public float nextWaypointDistance = 3f;
    private Node currentNode;
    private int i;

    void Awake()
    {
        s = GetComponentInParent<Spawner>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        s = GetComponentInParent<Spawner>();
        i = 0;
        speed = Random.Range(400, 600);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(currentNode.vPosition.x + " " + currentNode.vPosition.y +  Path[Path.Count - 1].vPosition.x + " " + Path[Path.Count - 1].vPosition.y);
        if (Path == null)
            return;
        if (i == Path.Count)
            return;
        currentNode = Path[i];
        if (currentNode == Path[Path.Count - 1])
        {
            pathEnded = true;
            Destroy(gameObject);
            s.ilosc--;
            return;
        }
        else
            pathEnded = false;

        Vector3 Direction = (currentNode.vPosition - rb.position).normalized;
        Vector3 Force = Direction * speed * Time.deltaTime;
        rb.AddForce(Force);

        float distance = Vector3.Distance(rb.position, currentNode.vPosition);

        if(distance < nextWaypointDistance)
        {
            i++;
            currentNode = Path[i];
        }
            
    }
}
