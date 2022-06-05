using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{

    float maxLength;
    public float MIN_LENGTH = 1.5f; //Rules state must be reactanglular table
    Renderer floor;
    float WALL_DEPTH = 0.5f; // check the depth of the prefab wall 

    public float MaxLength
    {
        get { return maxLength; }

    }


    void Awake()
    {

        CalculateMaxTableBounds();
   
    }

    /// when bounds change, recaluate bounds - DYNAMIC ROOM SIZE - Make below a Listener
    public void CalculateMaxTableBounds()
    {
        floor = GameObject.FindGameObjectWithTag("Floor").GetComponent<Renderer>();
        maxLength = (floor.bounds.size.z - (WALL_DEPTH * 2));
        Debug.Log("Max lenght " + maxLength);
    }

    

}
