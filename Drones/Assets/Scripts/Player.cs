using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public bool hasJumped;
    public float speed = 500f;
    private float moveSpeed = 7.5f;

    [SerializeField] private int playerID = 0;
    [SerializeField] private Player player;

    // [SerializeField] private GameObject[] path;
    public Node nextNode;
    [SerializeField] private int ind = 0;


    [Header("Sound effects")]
    [SerializeField] private AudioSource nodeEffect;


    // Start is called before the first frame update
    void Start()
    {
        // if (path != null && path.Length > 0)
        // {
        //     nextNode = path[0].transform;
        //     Debug.Log(path.Length);
        // }
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x != nextNode.transform.position.x && this.transform.position.z != nextNode.transform.position.z)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, 
                new Vector3(nextNode.transform.position.x, transform.position.y, nextNode.transform.position.z), moveSpeed * Time.deltaTime);
        }
        else if (nextNode != null)
        {
            nextNode = nextNode.nextNode;
            if (nodeEffect != null)
                nodeEffect.Play();
        }

        // if (rb != null)
        // {
        //     // Forward
        //     if (Input.GetKey(KeyCode.W))
        //     {
        //         rb.AddForce(0,0,speed*Time.deltaTime);
        //     }
        //     // Right
        //     if (Input.GetKey(KeyCode.D))
        //     {
        //         rb.AddForce(speed*Time.deltaTime,0,0);
        //     }
        //     // Down
        //     if (Input.GetKey(KeyCode.S))
        //     {
        //         rb.AddForce(0,0,-speed*Time.deltaTime);
        //     }
        //     // Left
        //     if (Input.GetKey(KeyCode.A))
        //     {
        //         rb.AddForce(-speed*Time.deltaTime,0,0);
        //     }

        //     // Jump
        //     if (!hasJumped && Input.GetKey(KeyCode.Space))
        //     {
        //         hasJumped = true;
        //         rb.AddForce(0,1000,0);
        //     }
        // }
    }


    private void OnCollisionEnter(Collision other) 
    {
        if (other.collider.tag.Equals("Untagged"))
        {
            hasJumped = false;
        }
        Debug.Log(other.collider.tag);    
    }

}
