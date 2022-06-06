using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{

    float maxLength;
    public float MIN_LENGTH = 1f; //Rules state must be reactanglular table - any less this wont really be a rectangle
    Renderer floor;
    float wall_depth; // check the depth of wall
    int SIDE_WALLS = 2;
    float CLIPPING = 0.01f;/// safe gaurd - to avoid z fighting - maybe Not needed?

    public float MaxLength
    {
        get { return maxLength; }

    }

    void Awake()
    {
        wall_depth = GameObject.FindGameObjectWithTag("Wall").GetComponent<Transform>().localScale.z;
        CalculateMaxTableBounds();
        
    }

    /// when bounds change, recaluate bounds - DYNAMIC ROOM SIZE - Make below a Listener
    public void CalculateMaxTableBounds()
    {
        floor = GameObject.FindGameObjectWithTag("Floor").GetComponent<Renderer>();
        
        maxLength = floor.bounds.size.x - ((wall_depth + CLIPPING) * SIDE_WALLS);
        Debug.Log("Max lenght " + maxLength);
    }
    public void ScaleTable(float scale)
    {
        if (scale == maxLength) { return; }
        transform.localScale = new Vector3(scale, transform.localScale.y, transform.localScale.z);
    }
}
