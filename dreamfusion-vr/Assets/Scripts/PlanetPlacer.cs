using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlanetPlacer : MonoBehaviour
{
    public GameObject obj;
    public GameObject objSpawn;

    public GameObject spawn;

    // Start is called before the first frame update
    void Start()
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
            if (obj.GetComponent<MeshRenderer>() != null && obj.GetComponent<MeshCollider>() == null)
            {
                obj.AddComponent<MeshCollider>();
            }
            if (obj.GetComponent<TeleportationArea>() == null)
            {
                obj.AddComponent<TeleportationArea>();
            }    
            
            obj.transform.localScale = new Vector3(100f, 100f, 100f);

            if (obj.GetComponent<MeshCollider>() != null && obj.GetComponent<TeleportationArea>() != null)
            {
                spawn.SetActive(false);
            }
        }
    }
}
