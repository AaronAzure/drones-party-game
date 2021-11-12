using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathAutomator : MonoBehaviour
{
    public Node[] nodes;
    // Start is called before the first frame update
    void Start()
    {
        if (nodes == null)
        {
            nodes = this.GetComponentsInChildren<Node>();
        }

        for (int i=0 ; i<nodes.Length - 1 ; i++)
        {
            nodes[i].nextNode = nodes[i+1];
        }
    }
}
