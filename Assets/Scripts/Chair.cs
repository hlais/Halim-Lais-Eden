using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
{
    //apply hex colours to newly spawned objects since Cant edit prefabs on run time || or add a new button to update colors <- better performance? 
    Color selectedColor;
 

    //on enable as we are using pooling 
    private void OnEnable()
    {
        selectedColor = FindObjectOfType<HexToColour>().CurrentColor;
        GetComponent<MeshRenderer>().material.color = selectedColor;
    }

}
