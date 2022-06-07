using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
{
    //apply hex colours to newly spawned objects since Cant edit prefabs on run time || or add a new button to update colors <- better performance 
    Table tableColour;
    Color currentColour;
   


    private void Start()
    {
        tableColour = GameObject.FindObjectOfType<Table>();
        Color currentColour = tableColour.GetComponent<MeshRenderer>().material.color;
        GetComponent<MeshRenderer>().material.color = currentColour;
    }

}
