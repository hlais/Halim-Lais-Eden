using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this script dynamically finds the centre of the room, usefull for scaling? 
/// </summary>
public class PlacedInCentre : MonoBehaviour
{
    Renderer plane;
    Vector3 centre;
    float yOffset;
    private void Awake()
    {
        if (GameObject.FindGameObjectWithTag("Floor") != null)
        {
            plane = GameObject.FindGameObjectWithTag("Floor").GetComponent<Renderer>();
            centre = plane.GetComponent<Renderer>().bounds.center;
        }
        else
            Debug.LogWarning("Add plane to scene and tagged as Floor");

        yOffset = transform.localScale.y * 0.5f; // to allow object to sit on plane, assuming plane is 0,0,0
    }


    void Start()
    {
        this.gameObject.transform.position = new Vector3(centre.x,yOffset,centre.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
