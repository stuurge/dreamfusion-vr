using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    public GameObject obj;
    public GameObject objSpawn;
    
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (obj == null)
        {
            obj = GameObject.Find("MyObject");

            obj.transform.position = objSpawn.transform.position;
        }
        else
        {
            obj.transform.position = objSpawn.transform.position;
        }
    }
}
