﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    const int SIDE_WALLS = 2;
    const float CLIPPING = 0.01f;/// safe gaurd - to avoid z fighting - maybe Not needed?
    const float MIN_LENGTH = 1f; //Rules state must be reactanglular table - any less this wont really be a rectangle

    Renderer floor;
    float wall_depth; // check the depth of wall
    float maxLength;


    public float MaxLength{   get { return maxLength; } }
    public float MinLength { get { return MIN_LENGTH; } }

    void Awake()
    {
        wall_depth = GameObject.FindGameObjectWithTag("Wall").GetComponent<Transform>().localScale.z;
        CalculateMaxTableBounds();
        
    }

    /// when bounds change, recaluate bounds - TODO DYNAMIC ROOM SIZE - Make below a Listener
    void CalculateMaxTableBounds()
    {
        floor = GameObject.FindGameObjectWithTag("Floor").GetComponent<Renderer>();
        maxLength = floor.bounds.size.x - ((wall_depth/2 + CLIPPING) * SIDE_WALLS);
        Debug.Log("Max lenght " + maxLength);
    }
    public void ScaleTable(float scale)
    {
       //limit already set from UI slider
        transform.localScale = new Vector3(scale, transform.localScale.y, transform.localScale.z);
    }
}
